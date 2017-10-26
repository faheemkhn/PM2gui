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
            int sampleCount = BUFFER_SIZE;
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

        /****************************************************************************
        * GetFFT
        *  Get the raw FFT of an array
        ****************************************************************************/
        private FFTData GetFFT(int[] amp)
        {
            FFTData fftData = new FFTData();
            double[] fft = new double[amp.Length];
            double[] freq = new double[amp.Length / 2];
            Complex[] fftComplex = new Complex[amp.Length];
            for (int i = 0; i < amp.Length; i++)
            {
                fftComplex[i] = new Complex(amp[i], 0);
            }
            AForge.Math.FourierTransform.FFT(fftComplex, AForge.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < amp.Length / 2; i++)
            {
                try
                {
                    //fft[i] = fftComplex[i].Magnitude;
                    fft[i] = 20 * Math.Log10(Math.Abs(fftComplex[i].Magnitude));
                }
                catch (Exception)
                {

                    throw;
                }
                if (i % 2 == 0)
                {
                    freq[i/2] = (i / 2 - 0.221) / 1.3072;
                }
            }

            fft = fft.Take(fft.Length / 2).ToArray();
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
        public PlottableData GetPlottableData(short handle, Pico.ChannelSettings[] channelSettings)
        {
            // Get block of waveform data from pico
            WaveFormData waveFormData = new WaveFormData();

            // Method that communicates with Pico to get blocked data
            waveFormData = HandlePicoBlockData(0, channelSettings, handle);

            return new PlottableData { fftData = GetFFT(waveFormData.amp), WaveFormData = waveFormData };
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
