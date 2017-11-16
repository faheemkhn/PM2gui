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
        //public Pico.ChannelSettings[] channelSettings;
        public Pico.PicoInterfacer pi = new Pico.PicoInterfacer(handle);
        //Tek tek = new Tek();

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
            public FFTData fftData;
            public WaveFormData WaveFormData;
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
            public bool isPeakGuess;
            public int nIter;
            public double trimStartFreq;
            public double trimStopFreq;
            public double PeakGuess;
        }
        public class FittingMetrics
        {
            public double f0;
            public double f1;
            public double f2;
            public double amplitude;
            public double Q;
        }


        /****************************************************************************
         * adc_to_mv
         * Convert an 16-bit ADC count into millivolts
         ****************************************************************************/
        private int adc_to_mv(int raw, int ch)
        {
            return (raw * inputRanges[ch]) / Imports.PS2000_MAX_VALUE;
        }

        /****************************************************************************
            * HandlePicoBlockData
            * - acquires data 
            * Export:
            *  - exports times and voltage readings of CHA as an array.
            * Input :
            * - offset : the offset into the data buffer to start the display's slice.
            ****************************************************************************/
        private WaveFormData HandlePicoBlockData(int offset, Pico.ChannelSettings[] channelSettings, short handle)
        {
            int sampleCount = 1024;// BUFFER_SIZE;
            short timeUnit = 0;
            int timeIndisposed;
            short status = 0;

            WaveFormData waveFormData = new WaveFormData();
            int[] time = new int[sampleCount];
            int[] amp = new int[sampleCount];
            PinnedArray<int> pinnedTimes = new PinnedArray<int>(time);
            PinnedArray<short>[] pinned = new PinnedArray<short>[1];

            // Channel buffers
            for (int i = 0; i < channelCount; i++)
            {
                short[] buffer = new short[sampleCount];
                pinned[i] = new PinnedArray<short>(buffer);
            }

            /* Find the maximum number of samples, the time interval (in nanoseconds),
                * the most suitable time units (ReportedTimeUnits), and the maximum oversample at the current timebase*/
            int timeInterval = 0;
            int maxSamples;
            do
            {
                status = Imports.GetTimebase(handle, timebase, sampleCount, out timeInterval, out timeUnit, oversample, out maxSamples);

                if (status != 1)
                {
                    timebase++;
                }

                if (timebase > 23)
                {
                    MessageBox.Show("Cannot connect to Picoscope: Check the USB Connection and Restart");
                    break;
                }
                    

            }
            while (status == 0);

            /* Start the device collecting, then wait for completion*/

            Imports.RunBlock(handle, sampleCount, timebase, oversample, out timeIndisposed);
            int timer = 1;
            bool isMessageDisconnect = false;
            short ready = 0;
            while (ready == 0)
            {
                ready = Imports.Isready(handle);
                Thread.Sleep(1);
                timer++;
                if (timer > 1e2 & !isMessageDisconnect)
                {
                    isMessageDisconnect = true;
                    MessageBox.Show("Cannot connect to Picoscope: Check the USB Connection and Restart");
                }

               // break;
            }

            if (ready > 0)
            {
                short overflow;

                Imports.GetTimesAndValues(handle, pinnedTimes, pinned[0], null, null, null, out overflow, timeUnit, sampleCount);

                for (int i = 0; i < sampleCount; i++)
                {
                    amp[i] = adc_to_mv(pinned[0].Target[i], (int)channelSettings[0].range);
                }
            }
            waveFormData.time = time;
            waveFormData.amp = amp;

            Imports.Stop(handle);
            return waveFormData;

        }

        /****************************************************************************
        * GetFFT
        *  Get the raw FFT of an array
        ****************************************************************************/
        private FFTData GetFFT(int[] amp, int[] time, FFTSettings fftSettings, double[] lastfft)
        {
            FFTData fftData = new FFTData();
            double[] fft = new double[amp.Length];
            double[] freq = new double[amp.Length / 2];
            Complex[] fftComplex = new Complex[amp.Length];

            // if FFT style has changed, reset the averaging by making last FFT null.
            if (fftSettings.isFftStyleChange)
            {
                lastfft = null;
            }

            //calculate fft
            for (int i = 0; i < amp.Length; i++)
            {
                fftComplex[i] = new Complex(amp[i], 0);
            }
            AForge.Math.FourierTransform.FFT(fftComplex, AForge.Math.FourierTransform.Direction.Forward);

            // transform fft based on user selected style
            for (int i = 0; i < amp.Length; i++)
            {
                time[i] = time[i] - time.Min();
                switch (fftSettings.Fftstyle)
                {
                    case 0: //Log
                        fft[i] = 20 * Math.Log10(fftComplex[i].Magnitude);
                        if (fft[i] == Double.NegativeInfinity || fft[i] == Double.NaN)
                        {
                            fft[i] = 0;
                        }
                        break;
                    case 1: // Log - Complex Conjugate
                        fft[i] = 20 * Math.Log10(Complex.Conjugate(fftComplex[i]).Magnitude*fftComplex[i].Magnitude);
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
                    freq[i / 2] = Convert.ToDouble(i/2) / (time[9] - time[8]) * 1e3;
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
        * Startup
        *  startup the device, get device info, and set channel settings
        ****************************************************************************/
        public Pico.ChannelSettings[] InitPico(short handle)
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

        public  void ChangePicoVoltage(short handle, Pico.ChannelSettings[] channelSettings)
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
        * GetBlockData
        *  this function demonstrates how to collect a single block of data
        *  from the unit (start collecting immediately)
        ****************************************************************************/
        public PlottableData GetPlottableData(short handle, Pico.ChannelSettings[] channelSettings, FFTSettings fftSettings, double[] lastfft)
        {
            // Get block of waveform data from pico
            WaveFormData waveFormData = new WaveFormData();

            // Method that communicates with Pico to get blocked data
            waveFormData = HandlePicoBlockData(0, channelSettings, handle);

            return new PlottableData { fftData = GetFFT(waveFormData.amp, waveFormData.time, fftSettings, lastfft), WaveFormData = waveFormData };
        }

        public LorentzParams GetLorentzParams(FFTData fftData, LorentzSettings lorentzSettings)
        {
            LorentzParams lp = new LorentzParams();
            double[][] dataPoints = new double[][] { fftData.freq, fftData.fft };
            double[] startPoint = { 10, 25, 1, 1 };

            if (lorentzSettings.isPeakGuess)
                startPoint[1] = lorentzSettings.PeakGuess;

            LMA algorithm;

            if (lorentzSettings.isYShiftLorentz)
            {
                LMAFunction lorentzShift = new LorenzianFunctionShift();

                algorithm = new LMA(lorentzShift, new double[] { 10, 24, 1,1 },
                dataPoints, null, new GeneralMatrix(4, 4), 1d - 20, lorentzSettings.nIter);

                algorithm.Fit();

                lp.A = algorithm.Parameters[0];
                lp.gamma = algorithm.Parameters[2];
                lp.f0 = algorithm.Parameters[1];
                lp.up = algorithm.Parameters[3];

            }
            else
            {
                LMAFunction lorentz = new LorenzianFunction();

                algorithm = new LMA(lorentz, new double[] { 10, 24, 1 },
                dataPoints, null, new GeneralMatrix(3, 3), 1d - 20, lorentzSettings.nIter);

                algorithm.Fit();

                lp.A = algorithm.Parameters[0];
                lp.gamma = algorithm.Parameters[2];
                lp.f0 = algorithm.Parameters[1];
                lp.up = 0;

            }



            return lp;

        }

        public FFTData TrimFFT(FFTData fftData, LorentzSettings lorentzSettings)
        {
            FFTData fftTrimData = new FFTData();

            int startIndex = Array.FindIndex(fftData.freq, x => x >= lorentzSettings.trimStartFreq);
            int stopIndex = Array.FindIndex(fftData.freq, x => x >= lorentzSettings.trimStopFreq);

            fftTrimData.fft = fftData.fft.ToList().Skip(startIndex + 1).Take(stopIndex - startIndex).ToArray();
            fftTrimData.freq = fftData.freq.ToList().ToList().Skip(startIndex + 1).Take(stopIndex - startIndex).ToArray();

            return fftTrimData;
        }

        public FittingMetrics GetFittingMetrics(LorentzParams lp, FFTSettings fftSettings)
        {
            FittingMetrics fm = new FittingMetrics();

            fm.amplitude = lp.A / lp.gamma / lp.gamma + lp.up;
            fm.f0 = lp.f0;

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

        public class LorenzianFunctionShift : LMAFunction
        {

            public override double GetY(double x, double[] a)
            {
                double result = a[3] + a[0] / (((x - a[1]) * (x - a[1]) + a[2] * a[2]));
                return result;
            }

        }

        public class LorenzianFunction : LMAFunction
        {

            public override double GetY(double x, double[] a)
            {
                double result = a[0] / (((x - a[1]) * (x - a[1]) + a[2] * a[2]));
                return result;
            }

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
