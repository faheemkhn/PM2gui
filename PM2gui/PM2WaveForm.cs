using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoPinnedArray;
using PS2000Imports;
using PM2gui;
using System.Threading;
using System.Numerics;
using DotNetMatrix;
using Net.Kniaz.LMA;
using System.Windows.Forms;
using Accord.Audio.Filters;
using System.IO;
using System.Diagnostics;


namespace PM2Waveform
{
    class PM2WaveForm
    {
        //define parameters based on Pico.Pico
        static short handle;
        ushort[] inputRanges = Pico.PicoInterfacer.inputRanges;
        public const int BUFFER_SIZE = Pico.PicoInterfacer.BUFFER_SIZE;
        public const int SINGLE_SCOPE = Pico.PicoInterfacer.SINGLE_SCOPE;
        public const int DUAL_SCOPE = Pico.PicoInterfacer.DUAL_SCOPE;
        public short timebase = Pico.PicoInterfacer.timebase;
        public short oversample = Pico.PicoInterfacer.oversample;
        public short MAX_CHANNELS = Pico.PicoInterfacer.MAX_CHANNELS;
        private int channelCount = SINGLE_SCOPE; //DUAL_SCOPE;

        //instantiate classes and structures
        public Pico.PicoInterfacer pi = new Pico.PicoInterfacer(handle);


        //define class to handle time and amplitude arrays
        public class WaveFormData
        {
            public int[] time { get; set; }
            public int[] amp { get; set; }

        }
        public class FFTData
        {
            public double[] freq { get; set; }
            public double[] fft { get; set; }
        }
        public class LorentzParams
        {
            public double A;
            public double f0;
            public double gamma;
            public double up;
        }
        public class PlottableData
        {
            public FFTData lorentzFftData;
            public FFTData fftData;
            public WaveFormData WaveFormData;
            public List<double> DeflectionList = new List<double>(100);
            
        }
        public class FFTSettings
        {
            public int Fftstyle;
            public int nFftMovAvg;
            public int nFftContAvg = 1;
            public bool isFftMovAvg;
            public bool isFftStyleChange;
            public bool isFftContAvg;
        }
        public class LorentzSettings
        {
            public bool isYShiftLorentz;
            public bool isTrimFft;
            public bool isStartingPointGuess;
            public int nIter;
            public double trimStartFreq;
            public double trimStopFreq;
            public LorentzParams startPointLP;
        }
        public class FittingMetrics
        {
            public double f0;
            public double f1;
            public double f2;
            public double amplitude;
            public double Q;
        }
        public class FilterSettings
        {
            public enum FilterType { lowPass, highPass, bandPass };
            public double highFreq;
            public double lowFreq;
            public double sampleRate;
        }
        public class ExportSettings
        {
            public bool isWaveForm = false;
            public bool isDeflection = false;
            public bool isFFT = false;
            public bool isPeakValue = false;
            public bool isLorentzian = false;
            public string fileNamePrefix;
            public string fileSavePath;
        }
        public class ProcessTimes
        {
            public TimeSpan samplingTime;
            public TimeSpan fftTime;
            public TimeSpan wavePlottingTime;
            public TimeSpan freqPlottingTime;
            public TimeSpan fittingTime;
            public TimeSpan microViewingTime;
            public TimeSpan ardunioComTime;
            public TimeSpan exportTime;

            public TimeSpan sumAllProcessTimes()
            {
                return samplingTime + fftTime + wavePlottingTime + freqPlottingTime + fittingTime + microViewingTime + ardunioComTime + exportTime; 
            }
        }
        
        //PICO INTERFACING AND DATA COLLECTION//

        /****************************************************************************
         * adc_to_mv
         * Convert an 16-bit ADC count into millivolts
         ****************************************************************************/
        private int adc_to_mv(int raw, int ch)
        {
            return (raw * inputRanges[ch]) / Imports.PS2000_MAX_VALUE;
        }

        /****************************************************************************
        * StartPico
        *  startup the device, get device info, and set channel settings
        ****************************************************************************/
        public Pico.ChannelSettings[] StartPico(short handle)
        {
            

            Pico.ChannelSettings[] channelSettings = new Pico.ChannelSettings[MAX_CHANNELS];
            for (int i = 0; i < channelCount; i++)
            {
                channelSettings[i].enabled = 1;
                channelSettings[i].DCcoupled = 1; //DC coupled
                channelSettings[i].range = Imports.Range.Range_20V;
            }

            pi.SetDefaults(handle, channelSettings);

            // disable trigger
            pi.SetTrigger(null, 0, null, 0, null, null, 0, 0);

            return channelSettings;
        }

        /****************************************************************************
        * ChangePicoVoltage
        *  change the voltage of the channel settings to what the user specifies
        ****************************************************************************/
        public void ChangePicoVoltage(short handle, Pico.ChannelSettings[] channelSettings)
        {


            pi.SetDefaults(handle, channelSettings);

            // disable trigger
            pi.SetTrigger(null, 0, null, 0, null, null, 0, 0);

        }

        /****************************************************************************
        * ShutDowm
        * Disconnects from device
        ****************************************************************************/
        public void ShutDown(short handle)
        {
            Imports.CloseUnit(handle);
        }

        /****************************************************************************
        * GetPlottableData
        *  this function demonstrates how to collect a single block of data
        *  from the unit (start collecting immediately)
        ****************************************************************************/
        public PlottableData GetPlottableData(short handle, Pico.ChannelSettings[] channelSettings, FFTSettings fftSettings, double[] lastfft, ref ProcessTimes processTimes, ref System.Windows.Forms.Timer WaveFormTimer, int SampleCount)
        {
            Stopwatch sw = new Stopwatch();


            //sw.Start();
            WaveFormData waveFormData = new WaveFormData();

            // Method that communicates with Pico to get blocked data
            HandlePicoBlockData(0, channelSettings, handle, ref waveFormData, ref processTimes, ref WaveFormTimer, SampleCount);
            //sw.Stop();

            //processTimes.samplingTime = sw.Elapsed;

            sw.Restart();
            PlottableData plottableData = new PlottableData { fftData = GetFFT(waveFormData.amp, waveFormData.time, fftSettings, lastfft), WaveFormData = waveFormData };
            sw.Stop();

            processTimes.fftTime = sw.Elapsed;

            return plottableData;
        }

        /****************************************************************************
         * HandlePicoBlockData
         * - acquires data 
         * Output:
         *  - exports times and voltage readings of Channel A as an array.
         * Input :
         * - offset : the offset into the data buffer to start the display's slice.
        ****************************************************************************/
        private void HandlePicoBlockData(int offset, Pico.ChannelSettings[] channelSettings, short handle, ref WaveFormData waveFormData, ref ProcessTimes processTimes, ref System.Windows.Forms.Timer WaveformTimer, int SampleCount)
        {
            Stopwatch sw = new Stopwatch();
            int sampleCount = SampleCount;//*2*2*2*2; // BUFFER_SIZE;
            short timeUnit = 0;
            short status = 0;

            int[] time = new int[sampleCount];
            int[] amp = new int[sampleCount];
            PinnedArray<int> pinnedTimes = new PinnedArray<int>(time);
            PinnedArray<short>[] pinned = new PinnedArray<short>[channelCount];

            // Channel buffers
            for (int i = 0; i < channelCount; i++)
            {
                short[] buffer = new short[sampleCount];
                pinned[i] = new PinnedArray<short>(buffer);
            }

            /* Find the maximum number of samples, the time interval (in nanoseconds),
                * the most suitable time units (ReportedTimeUnits), and the maximum oversample at the current timebase*/
            int timeInterval = 0;
            do
            {
                status = Imports.GetTimebase(handle, timebase, sampleCount, out timeInterval, out timeUnit, oversample, out int maxSamples);

                if (status != 1)
                {
                    timebase++;
                }

                if (timebase > 250)
                {
                    break;
                }


            }
            while (status == 0);

            /* Start the device collecting, then wait for completion*/
            sw.Start();
            Imports.RunBlock(handle, sampleCount, timebase, oversample, out int timeIndisposed);
            
            int timer = 1;
            bool isMessageDisconnect = false;
            short ready = 0;
            while (ready == 0)
            {
                ready = Imports.Isready(handle);
                Thread.Sleep(1);
                timer++;
                if (timer > 25 & !isMessageDisconnect)
                {
                    isMessageDisconnect = true;
                    ready = -1;
                    //MessageBox.Show("Cannot connect to Picoscope: Check the USB Connection and Restart");
                    //MessageBox.Show("Test");
                }

                // break;
            }

            if (ready == -1)
            {
                WaveformTimer.Stop();
                MessageBox.Show("Cannot connect to Picoscope: Check the USB Connection and Restart");
            }
                
            

            sw.Stop();

            if (ready > 0)
            {
                
                Imports.GetTimesAndValues(handle, pinnedTimes, pinned[0], null, null, null, out short overflow, timeUnit, sampleCount);
                
                for (int i = 0; i < sampleCount; i++)
                {
                    amp[i] = adc_to_mv(pinned[0].Target[i], (int)channelSettings[0].range);
                }
            }
            
            waveFormData.time = time;
            waveFormData.amp = amp;
            processTimes.samplingTime = sw.Elapsed;
            Imports.Stop(handle);

        }

        // FFT CALCULATIONS //
        /****************************************************************************
            * GetFFT
            *  Get the raw FFT of an array
        ****************************************************************************/
        private FFTData GetFFT(int[] amp, int[] time, FFTSettings fftSettings, double[] lastfft)
        {
            FFTData fftData = new FFTData();
            double[] fft = new double[amp.Length];
            double[] freq = new double[amp.Length / 2];
            //AForge.Math.Complex[] fftComplex = new AForge.Math.Complex[amp.Length];
            Complex[] fftComplex = new Complex[amp.Length];


            // if FFT style has changed, reset the averaging by making last FFT null.
            if (fftSettings.isFftStyleChange)
            {
                lastfft = null;
            }

            //calculate fft
            for (int i = 0; i < amp.Length; i++)
            {
                //fftComplex[i] = new AForge.Math.Complex();
                fftComplex[i] = new Complex(amp[i], 0);
            }
            //AForge.Math.FourierTransform.FFT(fftComplex, AForge.Math.FourierTransform.Direction.Forward);
            Accord.Math.Transforms.FourierTransform2.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);


            // transform fft based on user selected style
            for (int i = 0; i < amp.Length; i++)
            {
                time[i] = time[i] - time.Min();
                switch (fftSettings.Fftstyle)
                {
                    case 0: //Log
                        fft[i] = 20 * Math.Log10(fftComplex[i].Magnitude); // decibels=20Log,  http://www.arrl.org/files/file/Instructor%20resources/A%20Tutorial%20on%20the%20Dec-N0AX.pdf
                        if (fft[i] == Double.NegativeInfinity || fft[i] == Double.NaN)
                        {
                            fft[i] = 0;
                        }
                        break;
                    case 1: // Log - Complex Conjugate
                        fft[i] = 20 * Math.Log10(Complex.Conjugate(fftComplex[i]).Magnitude * fftComplex[i].Magnitude);
                        if (fft[i] == Double.NegativeInfinity || fft[i] == Double.NaN)
                        {
                            fft[i] = 0;
                        }
                        break;
                    case 2: // Magnitude
                        fft[i] = fftComplex[i].Magnitude;
                        break;
                    case 3: // Magnitude - Complex Conjugate
                        fft[i] = Complex.Conjugate(fftComplex[i]).Magnitude * fftComplex[i].Magnitude;
                        break;
                    default:
                        break;
                }

                if (i % 2 == 0)
                {
                    freq[i / 2] = Convert.ToDouble(i / 2) / (time[9] - time[8]) * 1e3;
                }
            }

            fft = fft.Take(fft.Length / 2).ToArray();

            // transform FFT based on user selected averaging technique- New Average = (New Spectrum • 1/N) + (Old Average) • (N−1)/N
            if (lastfft == null)
            {
                fftSettings.isFftMovAvg = false;
                fftSettings.isFftContAvg = false;
            }
            if (fftSettings.isFftMovAvg)
            {
                for (int i = 0; i < fft.Length; i++)
                    fft[i] = fft[i] * 1 / fftSettings.nFftMovAvg + lastfft[i] * (fftSettings.nFftMovAvg - 1) / fftSettings.nFftMovAvg;
            }
            if (fftSettings.isFftContAvg)
            {
                for (int i = 0; i < fft.Length; i++)
                    fft[i] = fft[i] * 1 / fftSettings.nFftContAvg + lastfft[i] * (fftSettings.nFftContAvg - 1) / fftSettings.nFftContAvg;
                fftSettings.nFftContAvg++;
            }

            fftData.fft = fft;
            fftData.freq = freq;

            return fftData;
        }

        /****************************************************************************
            *  TrimFFT
            *  Trim FFT array prior to Lorentzian fitting based on user specifications
        ****************************************************************************/
        public FFTData TrimFFT(FFTData fftData, LorentzSettings lorentzSettings)
        {
            FFTData fftTrimData = new FFTData();

            int startIndex = Array.FindIndex(fftData.freq, x => x >= lorentzSettings.trimStartFreq);
            int stopIndex = Array.FindIndex(fftData.freq, x => x >= lorentzSettings.trimStopFreq);

            fftTrimData.fft = fftData.fft.ToList().Skip(startIndex + 1).Take(stopIndex - startIndex).ToArray();
            fftTrimData.freq = fftData.freq.ToList().ToList().Skip(startIndex + 1).Take(stopIndex - startIndex).ToArray();

            return fftTrimData;
        }

        // LORENTZIAN FITTING //

        /****************************************************************************
            *  GetLorentzParams
            *  Get lorentzian fitting parameters
        ****************************************************************************/
        public void GetLorentzParams(FFTData fftData, LorentzSettings lorentzSettings, ref LorentzParams lorentzParams)
        {
            double[][] dataPoints = new double[][] { fftData.freq, fftData.fft };


            LMA algorithm;

            if (lorentzSettings.isYShiftLorentz)
            {
                LMAFunction lorentzShift = new LorenzianFunctionShift();

                double[] startPoint = new double[4];

                try
                {
                    startPoint[0] = lorentzSettings.startPointLP.A;
                }
                catch (Exception)
                {
                    startPoint[0] = 10;
                }

                try
                {
                    startPoint[1] = lorentzSettings.startPointLP.f0;
                }
                catch (Exception)
                {
                    startPoint[1] = 25;
                }

                try
                {
                    startPoint[2] = lorentzSettings.startPointLP.gamma;
                }
                catch (Exception)
                {
                    startPoint[2] = 1;
                }

                try
                {

                    startPoint[3] = lorentzSettings.startPointLP.up;
                }
                catch (Exception)
                {
                    startPoint[3] = 1;
                }




                algorithm = new LMA(lorentzShift, startPoint,
                dataPoints, null, new GeneralMatrix(4, 4), 1d - 20, lorentzSettings.nIter);

                algorithm.Fit(); 

                lorentzParams.A = algorithm.Parameters[0];
                lorentzParams.gamma = algorithm.Parameters[2];
                lorentzParams.f0 = algorithm.Parameters[1];
                lorentzParams.up = algorithm.Parameters[3];


            }
            else
            {
                LMAFunction lorentz = new LorenzianFunction();

                double[] startPoint = new double[3];

                try
                {
                    startPoint[0] = lorentzSettings.startPointLP.A;
                }
                catch (Exception)
                {
                    startPoint[0] = 10;
                }

                try
                {
                    startPoint[1] = lorentzSettings.startPointLP.f0;
                }
                catch (Exception)
                {
                    startPoint[1] = 25;
                }

                try
                {
                    startPoint[2] = lorentzSettings.startPointLP.gamma;
                }
                catch (Exception)
                {
                    startPoint[2] = 1;
                }

                algorithm = new LMA(lorentz, startPoint,
                dataPoints, null, new GeneralMatrix(3, 3), 1d - 20, lorentzSettings.nIter);

                algorithm.Fit();

                lorentzParams.A = algorithm.Parameters[0];
                lorentzParams.gamma = algorithm.Parameters[2];
                lorentzParams.f0 = algorithm.Parameters[1];
                lorentzParams.up = 0;

            }

        }

        /****************************************************************************
            *  GetfittingMetrics
            *  calculate the fitting parameters that the user is interested in
        ****************************************************************************/
        public FittingMetrics GetFittingMetrics(LorentzParams lp, FFTSettings fftSettings)
        {
            FittingMetrics fm = new FittingMetrics
            {
                amplitude = lp.A / lp.gamma / lp.gamma + lp.up,
                f0 = lp.f0
            };

            double ampPrime = 0;
            switch (fftSettings.Fftstyle)
            {
                case 0: //Log (dB)
                    ampPrime = fm.amplitude - 3;
                    break;
                case 1: // Log - Complex Conjugate (dB)
                    ampPrime = fm.amplitude - 3;
                    break;
                case 2: // Magnitude (V)
                    ampPrime = fm.amplitude * 0.5;
                    break;
                case 3: // Magnitude - Complex Conjugate (V)
                    ampPrime = fm.amplitude * 0.5;
                    break;
            }
            try
            {
                fm.f1 = fm.f0 + Math.Sqrt((lp.A + lp.gamma * lp.gamma * (lp.up - ampPrime)) / (ampPrime - lp.up));
                fm.f2 = fm.f0 - Math.Sqrt((lp.A + lp.gamma * lp.gamma * (lp.up - ampPrime)) / (ampPrime - lp.up));
            }
            catch (Exception)
            {

                fm.f1 = 0;
                fm.f2 = 0;
            }
            
            if (fm.f1 - fm.f2 > 0)
            {
                fm.Q = fm.f0 / (fm.f1 - fm.f2);
            }
            else
            {
                fm.Q = 0;
            }

            return fm;


        }

        /****************************************************************************
           *  LorentzianFunction
           *  defines the lorentzian function
       ****************************************************************************/
        public class LorenzianFunction : LMAFunction
        {

            public override double GetY(double x, double[] a)
            {
                double result = a[0] / (((x - a[1]) * (x - a[1]) + a[2] * a[2]));
                return result;
            }

        }

        /****************************************************************************
           *  LorentzianFunctionShift
           *  defines the lorentzian function with an additional vertical shift
       ****************************************************************************/
        public class LorenzianFunctionShift : LMAFunction
        {

            public override double GetY(double x, double[] a)
            {
                double result = a[3] + a[0] / (((x - a[1]) * (x - a[1]) + a[2] * a[2]));
                return result;
            }

        }

        // DATA EXPORTING //
        /****************************************************************************
           *  ExportWaveForm
           *  defines the lorentzian function with an additional vertical shift
       ****************************************************************************/
        public void ExportWaveForm(ref PlottableData plottableData, ExportSettings exportSettings)
        {

            //string contFileName = GetFileName(exportSettings.fileSavePath + exportSettings.fileNamePrefix + "cont_");
            string waveFileName = GetFileName(exportSettings.fileNamePrefix + exportSettings.fileNamePrefix + "wave_");

            TextWriter waveWriter = new StreamWriter(waveFileName, false);
            //TextWriter contWriter = new StreamWriter(contFileName, false);

            //wave export
            if (exportSettings.isWaveForm)
            {
                waveWriter.Write("Time,");
                waveWriter.Write("Amplitude,");
            }

            if (exportSettings.isFFT)
            {
                waveWriter.Write("FFT_frequency,");
                waveWriter.Write("FFT_mag,");
            }

            if (exportSettings.isLorentzian)
            {
                waveWriter.Write("Lorentz_frequency,");
                waveWriter.Write("Lorentz_mag,");
            }



            waveWriter.WriteLine();

            for (int i = 0; i < plottableData.WaveFormData.time.Length; i++)
            {
                
                if (exportSettings.isWaveForm)
                {
                    waveWriter.Write(plottableData.WaveFormData.time[i].ToString() + ",");
                    waveWriter.Write(plottableData.WaveFormData.amp[i].ToString() + ",");
                }
                    
                if (exportSettings.isFFT & i < plottableData.fftData.freq.Length)
                {
                    waveWriter.Write(plottableData.fftData.freq[i].ToString() + ",");
                    waveWriter.Write(plottableData.fftData.fft[i].ToString() + ",");
                }

                if (exportSettings.isLorentzian & (plottableData.lorentzFftData == null || i < plottableData.lorentzFftData.freq.Length))
                {
                    waveWriter.Write(plottableData.lorentzFftData.freq[i].ToString() + ",");
                    waveWriter.Write(plottableData.lorentzFftData.fft[i].ToString() + ",");
                }
                 
                waveWriter.WriteLine();
                
                
                //cont writer
            }

            waveWriter.Close();
        }

        /****************************************************************************
           *  GetFileName()
           *  get file export name based on current time 
       ****************************************************************************/
       private string GetFileName(string prefix)
        {
            DateTime dateTime = DateTime.Now;
            int dateTimeMiliSeconds = DateTime.Now.Millisecond;
            string fileName = prefix + dateTime.ToString() + ":" + dateTimeMiliSeconds + ".txt";
            return fileName.Replace(" ", "_").Replace("/","-").Replace(":","-");
        }



        // WAVEFORM FILTERING //
        public void FilterWave(ref WaveFormData waveFormData, FilterSettings filterSettings)
        {
            LowPassFilter lpf = new LowPassFilter(filterSettings.lowFreq, filterSettings.sampleRate);

        }

        public class FilterButterworth
        {
            /// <summary>
            /// rez amount, from sqrt(2) to ~ 0.1
            /// </summary>
            private readonly float resonance;

            private readonly float frequency;
            private readonly int sampleRate;
            private readonly PassType passType;

            private readonly float c, a1, a2, a3, b1, b2;

            /// <summary>
            /// Array of input values, latest are in front
            /// </summary>
            private float[] inputHistory = new float[2];

            /// <summary>
            /// Array of output values, latest are in front
            /// </summary>
            private float[] outputHistory = new float[3];

            public FilterButterworth(float frequency, int sampleRate, PassType passType, float resonance)
            {
                this.resonance = resonance;
                this.frequency = frequency;
                this.sampleRate = sampleRate;
                this.passType = passType;

                switch (passType)
                {
                    case PassType.Lowpass:
                        c = 1.0f / (float)Math.Tan(Math.PI * frequency / sampleRate);
                        a1 = 1.0f / (1.0f + resonance * c + c * c);
                        a2 = 2f * a1;
                        a3 = a1;
                        b1 = 2.0f * (1.0f - c * c) * a1;
                        b2 = (1.0f - resonance * c + c * c) * a1;
                        break;
                    case PassType.Highpass:
                        c = (float)Math.Tan(Math.PI * frequency / sampleRate);
                        a1 = 1.0f / (1.0f + resonance * c + c * c);
                        a2 = -2f * a1;
                        a3 = a1;
                        b1 = 2.0f * (c * c - 1.0f) * a1;
                        b2 = (1.0f - resonance * c + c * c) * a1;
                        break;
                }
            }

            public enum PassType
            {
                Highpass,
                Lowpass,
            }

            public void Update(float newInput)
            {
                float newOutput = a1 * newInput + a2 * this.inputHistory[0] + a3 * this.inputHistory[1] - b1 * this.outputHistory[0] - b2 * this.outputHistory[1];

                this.inputHistory[1] = this.inputHistory[0];
                this.inputHistory[0] = newInput;

                this.outputHistory[2] = this.outputHistory[1];
                this.outputHistory[1] = this.outputHistory[0];
                this.outputHistory[0] = newOutput;
            }

            public float Value
            {
                get { return this.outputHistory[0]; }
            }
        }
    }
}
