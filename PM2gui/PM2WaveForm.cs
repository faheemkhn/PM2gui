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
using Accord.Extensions;
using AForge;
using MathNet.Numerics.Optimization;
using NationalInstruments.Visa;
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
        public short _timebase = Pico.PicoInterfacer.timebase;
        public short _oversample = Pico.PicoInterfacer.oversample;
        public short MAX_CHANNELS = Pico.PicoInterfacer.MAX_CHANNELS;
        private int _channelCount = SINGLE_SCOPE; //DUAL_SCOPE;

        //instantiate classes and structures
        //public Pico.ChannelSettings[] channelSettings;
        public Pico.PicoInterfacer pi = new Pico.PicoInterfacer(handle);
        Tek tek = new Tek();

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
            public double xO;
            public double gam;
            public double A;
        }
        public class PlottableData
        {
            public FFTData fftData;
            public WaveFormData WaveFormData;
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
            for (int i = 0; i < _channelCount; i++)
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
                status = Imports.GetTimebase(handle, _timebase, sampleCount, out timeInterval, out timeUnit, _oversample, out maxSamples);

                if (status != 1)
                {
                    //Console.WriteLine("Selected timebase {0} could not be used\n", timebase);
                    _timebase++;
                }

            }
            while (status == 0);

            /* Start the device collecting, then wait for completion*/

            Imports.RunBlock(handle, sampleCount, _timebase, _oversample, out timeIndisposed);

            short ready = 0;
            while (ready == 0 /*&& !Console.KeyAvailable*/)
            {
                ready = Imports.Isready(handle);
                Thread.Sleep(1);
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

        private WaveFormData HandleTekBlockData(MessageBasedSession mbSession)
        {
            WaveFormData waveFormData = new WaveFormData();

            //get voltage and time interval information ("wfmpre?)
            //tek.tekWrite(mbSession, "rem");
            string settings;
            try
            {
                mbSession.RawIO.Write("wfmpre:wfid?");
                settings = mbSession.RawIO.ReadString();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                settings = "";
            }



            //string settings = tek.TekQuery(mbSession, "wfmpre?");

            // parse tek settings to get the time and voltage intervals based on the current tek settings
            double dvolt = double.Parse(settings.Split(',')[2].Split(' ')[1]);
            double dtime = double.Parse(settings.Split(',')[3].Split(' ')[1]);

            //get datapoints at a given point in time ("curve?")
            //tek.tekWrite(mbSession, "rem");

            //make time and amp arrays
            //int[] amp = Array.ConvertAll(tek.TekQuery(mbSession, "curve?").Split(','), int.Parse);

            List<int> test = new List<int>() ;
            bool tooShort = true;
            while (tooShort)
            {
                List<int> ampRaw = new List<int>();
                mbSession.RawIO.Write("data:encdg ascii;");
                //mbSession.RawIO.Write("curve?");
                //string[] rawz = mbSession.RawIO.ReadString().Split(',');
                try
                {
                    mbSession.RawIO.Write("curve?");
                    List<string> rawList = mbSession.RawIO.ReadString().Split(' ')[1].Split(',').ToList();
                    //ampRaw = Array.ConvertAll(raw, int.Parse).ToList();
                    ampRaw = rawList.Take(rawList.Count() - 1).Select(int.Parse).ToList();
                    test.AddRange(ampRaw);
                }
                catch (Exception exp)
                {
                    ampRaw = null;
                }
                //List<int> ampRaw = Array.ConvertAll(tek.TekQuery(mbSession, "curve?").Split(','), int.Parse).ToList();

                /*mbSession.RawIO.Write("curve?");
                List<string> rawList = mbSession.RawIO.ReadString().Split(' ')[1].Split(',').ToList();
                //ampRaw = Array.ConvertAll(raw, int.Parse).ToList();
                ampRaw = rawList.Take(rawList.Count() - 1).Select(int.Parse).ToList();
                test.AddRange(ampRaw);*/

                if (test.Count >= 1024)
                {
                    test = test.Take(1024).ToList();
                    tooShort = false;
                }
                    
            }

            int[] amp = test.ToArray();
            
            int[] time = new int[amp.Length];
            for (int i = 0; i < amp.Length; i++)
            {
                time[i] = Convert.ToInt32(i * dtime * 1000000); // convert to nanoseconds
            }

            waveFormData.amp = amp;
            waveFormData.time = time;

            return waveFormData;
        }


        /****************************************************************************
        * GetFFT
        *  Get the raw FFT of an array
        ****************************************************************************/
        private FFTData GetFFT(int[] amp, int[] time, int FFTstyle, int nFFTavg, bool isFFTavg, bool isFFTstyleChange, double[] lastfft)
        {
            FFTData fftData = new FFTData();
            double[] fft = new double[amp.Length];
            double[] freq = new double[amp.Length / 2];
            Complex[] fftComplex = new Complex[amp.Length];


            // if FFT style has changed, reset the averaging by making last FFT null.
            if (isFFTstyleChange)
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
            for (int i = 0; i < amp.Length / 2; i++)
            {
                time[i] = time[i] - time.Min();
                switch (FFTstyle)
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
                    /*switch (i/2)
                    {
                        case 0:
                            freq[i / 2] = i / amp.Length / (time[1] - time[0]) / 10 ^ -9;
                            break;
                        case 512:
                            freq[i / 2] = 1 / amp.Length / (time[1] - time[0]) / 10 ^ -9;
                            break;
                        default:
                            //freq[i / 2] = (i / 2 - 0.221) / 1.3072;
                            freq[i / 2] = 1 / amp.Length / (time[1] - time[0]) / 10 ^ -9;
                            break;
                    }*/
                    freq[i / 2] = (i / 2 - 0.221) / 1.3072;
                    //freq[i / 2] = 1 / amp.Length / (time[1] - time[0]) / 10 ^ -3;
                }
            }

            fft = fft.Take(fft.Length / 2).ToArray();

            // transform FFT based on user selected averaging technique- New Average = (New Spectrum • 1/N) + (Old Average) • (N−1)/N
            if (lastfft == null)
            {
                isFFTavg = false;
            }
            if (isFFTavg)
            {
                for (int i = 0; i < fft.Length; i++)
                    fft[i] = fft[i] * 1 / nFFTavg + lastfft[i] * (nFFTavg - 1) / nFFTavg;
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
            for (int i = 0; i < _channelCount; i++)
            {
                channelSettings[i].enabled = 1;
                channelSettings[i].DCcoupled = 1; //DC coupled
                channelSettings[i].range = Imports.Range.Range_5V;
            }

            pi.SetDefaults(handle, channelSettings);

            // disable trigger
            pi.SetTrigger(null, 0, null, 0, null, null, 0, 0);

            return channelSettings;
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
        public PlottableData GetPlottableData(short handle, Pico.ChannelSettings[] channelSettings, int FFTstyle, int nFFTavg, bool isFFTavg, bool isFFTstyleChange, double[] lastfft)
        {
            // Get block of waveform data from pico
            WaveFormData waveFormData = new WaveFormData();

            // Method that communicates with Pico to get blocked data
            waveFormData = HandlePicoBlockData(0, channelSettings, handle);

            return new PlottableData { fftData = GetFFT(waveFormData.amp, waveFormData.time, FFTstyle, nFFTavg, isFFTavg, isFFTstyleChange, lastfft), WaveFormData = waveFormData };
        }

        public PlottableData GetTekPlottableData(MessageBasedSession mbSession,  int FFTstyle, int nFFTavg, bool isFFTavg, bool isFFTstyleChange, double[] lastfft)
        {
            // Get block of waveform data from pico
            WaveFormData waveFormData = new WaveFormData();

            // Method that communicates with Pico to get blocked data
            waveFormData = HandleTekBlockData(mbSession);

            return new PlottableData { fftData = GetFFT(waveFormData.amp, waveFormData.time, FFTstyle, nFFTavg, isFFTavg, isFFTstyleChange, lastfft), WaveFormData = waveFormData };
        }


        public LorentzParams GetLorentzParams(FFTData fftData)
        {
            LorentzParams lp = new LorentzParams();

            //double[] soln1 = QuadFit(fftData);
            for (int i = 1; i < fftData.fft.Length; i++)
            {
                fftData.fft[i] = 1 / fftData.fft[i];
            }
            double[] soln = MathNet.Numerics.Fit.Polynomial(fftData.freq, fftData.fft, 2);
            lp.xO = -soln[1] / 2 / soln[0];
            lp.gam = Math.Sqrt(soln[2] / soln[0] - lp.xO * lp.xO);
            lp.A = 1 / soln[0] / lp.gam;

            return lp;
            

        }

        private double[] QuadFit(FFTData fftData)
        {
            LstSquQuadRegr solvr = new LstSquQuadRegr();
            double[] soln = new double[3];

            for (int i = 0; i < fftData.fft.Length; i++)
            {
                solvr.AddPoints(fftData.freq[i], 1 / fftData.fft[i]);
            }

            soln[0] = solvr.aTerm();
            soln[1] = solvr.bTerm();
            soln[2] = solvr.cTerm();

            return soln;
        }
    }
}
