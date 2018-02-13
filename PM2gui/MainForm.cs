using AForge.Video;
using AForge.Video.DirectShow;
using Net.Kniaz.LMA;
using PM2Waveform;
using PS2000Imports;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Collections.Generic;

namespace PM2gui
{
    public partial class PM2gui : Form
    {
        public PM2gui()
        {
            InitializeComponent();
            this.WaveFormChart.MouseMove += new MouseEventHandler(WaveFormChart_MouseMove);
            this.tooltiptD.AutomaticDelay = 10;
            this.FftChart.MouseMove += new MouseEventHandler(FftChart_MouseMove);
            this.tooltipfD.AutomaticDelay = 10;
        }

        private class AppSettings
        {
            public bool isDataReading = false;
            public bool isFitting = false;
            public bool isContExporting = false;
            public bool isFiltering = false;
            public bool isDeflectionReading = false;
            public bool isSpectrumBuilding = false;
            public bool isPeakTracking = false;
            public bool isViewing = false;
            public bool isPiezo = false;
            public bool isSnapExporting = false;
            public bool isChanelB = false;
        }

        #region Initialize Public Classes and Variables
        PM2WaveForm pM2WaveForm = new PM2WaveForm();
        Pico.ChannelSettings[] channelSettings = new Pico.ChannelSettings[Pico.PicoInterfacer.MAX_CHANNELS];
        PM2WaveForm.WaveFormData waveFormData = new PM2WaveForm.WaveFormData();
        PM2WaveForm.PlottableData plottableData = new PM2WaveForm.PlottableData();
        PM2WaveForm.FFTData fftData = new PM2WaveForm.FFTData();
        PM2WaveForm.FFTData LorentzFftData = new PM2WaveForm.FFTData();
        FilterInfoCollection CaptureDevice;
        VideoCaptureDevice FinalFrame;
        Point? prevPositiontD = null;
        ToolTip tooltiptD = new ToolTip();
        Point? prevPositionfD = null;
        ToolTip tooltipfD = new ToolTip();
        PM2WaveForm.LorentzParams lorentzParams = new PM2WaveForm.LorentzParams();
        ushort[] inputRanges = Pico.PicoInterfacer.inputRanges;
        SerialPort picoPort;
        LMAFunction lorentz = new PM2Waveform.PM2WaveForm.LorenzianFunction();
        LMAFunction lorentzShift = new PM2WaveForm.LorenzianFunctionShift();
        PM2WaveForm.FFTSettings fftSettings = new PM2WaveForm.FFTSettings();
        PM2WaveForm.LorentzSettings lorentzSettings = new PM2WaveForm.LorentzSettings();
        PM2WaveForm.FittingMetrics FittingMetrics = new PM2WaveForm.FittingMetrics();
        PM2WaveForm.ExportSettings ExportSettings = new PM2WaveForm.ExportSettings();
        AppSettings appSettings = new AppSettings();
        PM2WaveForm.ProcessTimes processTimes = new PM2WaveForm.ProcessTimes();
        Stopwatch totalSW = new Stopwatch();
        List<double> DeflectionList = new List<double>();
        DateTime DeflectionStartTime;
        DateTime SpecBuildStartTime;
        PM2WaveForm.LorentzParams lp = new PM2WaveForm.LorentzParams();

        int ChanelBCountDown;
        short handle;
        double[] lastfft = null;
        bool isPicoPortOpen = false;
        double[] LorParArray = new double[4];
        double pM2f_min;
        double pM2f_max;
        double peakTrackTime = 0;
        double deflectionTrackTime = 0;
        double spectBuilTrackTime = 0;
        double specBuildPeriod;
        #endregion

        private void PM2gui_Load(object sender, EventArgs e)
        {

            PicoscopeInit();
            AmscopeInit();
            ChartsInit();
            PicoPortInit();
            ButtonInit();
            TimersIntervalUpdate(EqualizeRefreshRateCheckBox.Checked);
            specBuildPeriod = 1e3 / double.Parse(PulseFrequencyTextBox.Text);
            BufferSizeComboBox.SelectedIndex = 5;
            _sampleCount = int.Parse(BufferSizeComboBox.SelectedItem.ToString());
            // init lorentz guess
            lorentzSettings.startPointLP = lp;
            
        }

        private void PicoscopeInit()
        {
            // Init Picoscope
            if ((handle = Imports.OpenUnit()) <= 0)
            {
                MessageBox.Show("Picoscope could not be opened. Check connection and start again.");
                Application.Exit();
            }
            else
            {
                channelSettings = pM2WaveForm.StartPico(handle);
            }
            StopWaveButton.Enabled = false;
            FreqMaxComboBox.SelectedIndex = 10;
            VoltRangComboBox.SelectedIndex = 10;
        }

        private void AmscopeInit()
        {
            //Init USB Camera
            StopViewingButton.Enabled = false;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                CamComboBox.Items.Add(Device.Name);
            }
            if (CamComboBox.Items.Count > 0)
                CamComboBox.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void ChartsInit()
        {
            //init charts
            //time domain
            WaveFormChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            WaveFormChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            WaveFormChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            WaveFormChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            WaveFormChart.ChartAreas[0].AxisX.Minimum = 0;
            WaveFormChart.ChartAreas[0].AxisY.Maximum = inputRanges[VoltRangComboBox.SelectedIndex];
            WaveFormChart.ChartAreas[0].AxisY.Minimum = inputRanges[VoltRangComboBox.SelectedIndex] * -1;
            //pM2tD.ChartAreas[0].AxisY.Interval = 100;
            //pM2tD.ChartAreas[0].AxisY.Interval = 2000;
            WaveFormChart.ChartAreas[0].AxisX.Title = "Time (us)";
            WaveFormChart.ChartAreas[0].AxisY.Title = "Amplitude (mV)";


            //frequency domain
            FftChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            FftChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            FftChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            FftChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            FftChart.ChartAreas[0].CursorY.IsUserEnabled = true;
            FftChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            FftChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            FftChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            FftChart.ChartAreas[0].AxisY.Title = "Magnitude";
            //pM2fD.ChartAreas[0].AxisY.Interval = 2000;
            //pM2fD.ChartAreas[0].AxisX.Minimum = 0;
            //pM2fD.ChartAreas[0].AxisX.Ma            FftChart.ChartAreas[0].AxisX.Title = "Frequency (kHz)";ximum = 100;
            //pM2fD.ChartAreas[0].AxisY.Minimum = 0;
            //pM2fD.ChartAreas[0].AxisY.Maximum = 100;
            //pM2fD.ChartAreas[0].AxisX.Interval = -2000;
        }

        private void PicoPortInit()
        {
            //arduino
            try
            {
                picoPort = new SerialPort(AutodetectArduinoPort(), 9600, Parity.None, 8, StopBits.One);
                picoPort.Open();
                isPicoPortOpen = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to Arduino.");
            }
        }

        private void ButtonInit()
        {
            MovAvTextBox.Enabled = false;
            pM2f_min = Math.Ceiling(FftChart.ChartAreas[0].AxisX.Minimum);
            pM2f_max = Math.Floor(FftChart.ChartAreas[0].AxisX.Maximum);

            LorentzStartButton.Enabled = false;
            LorentzStopButton.Enabled = false;
            StartDeflectionButton.Enabled = false;
            StopDeflectionButton.Enabled = false;
            StartExportButton.Enabled = false;
            StopExportButton.Enabled = false;
            StartFilterButton.Enabled = false;
            StopFilterButton.Enabled = false;
            StartPeakTrackButton.Enabled = false;
            StopPeakTrackButton.Enabled = false;
            ExportSnapShotButton.Enabled = false;
            PiezoButton.Enabled = false;
            btnStartChanelB.Enabled = false;
            btnStopChanelB.Enabled = false;
        }

        private void TimersIntervalUpdate(bool equalizeRefreshRate)
        {
            WaveFormTimer.Interval = int.Parse(Math.Round(double.Parse(ReadingRefreshRateTextBox.Text)).ToString());
            lblChanelBRefreshRate.Text = $"x {WaveFormTimer.Interval.ToString()}";
            if (equalizeRefreshRate)
            {
                ExportRateTextBox.Text = ReadingRefreshRateTextBox.Text;
                LorentzRefreshRateTextBox.Text = ReadingRefreshRateTextBox.Text;
                ExportRateTextBox.Enabled = false;
                LorentzRefreshRateTextBox.Enabled = false;

            }
            else
            {
                ExportRateTextBox.Enabled = true;
                LorentzRefreshRateTextBox.Enabled = true;
            }

            ExportTimer.Interval = int.Parse(Math.Round(double.Parse(ExportRateTextBox.Text)).ToString());
            LorentzTimer.Interval = int.Parse(Math.Round(double.Parse(LorentzRefreshRateTextBox.Text)).ToString());

        }

        private void PM2gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            pM2WaveForm.ShutDown(handle);
            if (isPicoPortOpen)
                picoPort.Close();
        }

        private void WaveFormChart_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPositiontD.HasValue && pos == prevPositiontD.Value)
                return;
            tooltiptD.RemoveAll();
            prevPositiontD = pos;
            var results = WaveFormChart.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            tooltiptD.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.WaveFormChart,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        private void FftChart_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPositionfD.HasValue && pos == prevPositionfD.Value)
                return;
            tooltipfD.RemoveAll();
            prevPositionfD = pos;
            var results = FftChart.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            tooltipfD.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.FftChart,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }



        // PICO READING AND FFT

        private void StartWaveButton_Click(object sender, EventArgs e)
        {
            WaveFormTimer.Start();
            appSettings.isDataReading = true;
            LorentzStartButton.Enabled = true;
            StartWaveButton.Enabled = false;
            StopWaveButton.Enabled = true;
            StartExportButton.Enabled = true;
            StartFilterButton.Enabled = true;
            StartDeflectionButton.Enabled = true;
            btnStartChanelB.Enabled = true;

        }

        private int _sampleCount;

        private void WaveFormTimer_Tick(object sender, EventArgs e)
        {

            totalSW.Restart();
            int SampleCount = _sampleCount;
            Stopwatch sw = new Stopwatch();

            // ReInitProcessTimes();

            // determine if we shuold get chanel B data
            bool ChanelB = false;
            if (appSettings.isChanelB)
            {
                int multiplier = int.Parse(tbChanelBRefreshRate.Text);
                if (ChanelBCountDown == 0)
                    ChanelB = true;
                ChanelBCountDown = (ChanelBCountDown + 1) % multiplier;
            }

            sw.Start();
            plottableData = pM2WaveForm.GetPlottableData(handle, channelSettings, fftSettings, lastfft, ref processTimes, ref WaveFormTimer, SampleCount, ChanelB, ref tbChanelBReading);
            sw.Stop();

            fftSettings.isFftStyleChange = false;

            sw.Restart();

            UpdateWaveCharts();
            appSettings.isSpectrumBuilding = SpectrumBuildCheckBox.Checked;
            if (appSettings.isDeflectionReading)
                UpdateDeflectionCharts();

            sw.Stop();
            processTimes.wavePlottingTime = sw.Elapsed;


            if (IsPm2fdFreqRangeChanged() & !TrimFftCheckBox.Checked)
                UpdateTrimTextBox();

            TimeDomainPlottingTimeLabel.Text = "Time Domain Plotting (ms) = " + Convert.ToString(processTimes.wavePlottingTime.Milliseconds);
            DataSamplingTimeLabel.Text = "Data Sampling (ms) = " + Convert.ToString(processTimes.samplingTime.Milliseconds);
            FftTimeLabel.Text = "FFT (ms) = " + Convert.ToString(processTimes.fftTime.Milliseconds);

            totalSW.Stop();

        }

        private void ReInitProcessTimes()
        {
            DataSamplingTimeLabel.Text = "Data Sampling and FFT (ms) = N/A";
            TimeDomainPlottingTimeLabel.Text = "Time Domain Plotting (ms) = N/A";
            FreqDomainPlottingTimeLabel.Text = "Frequency Domain Plotting (ms) = N/A";
            LorentzianFittingTimeLabel.Text = "Lorentzian Fitting (ms) = N/A";
            CameraViewingTimeLabel.Text = "Camera Fitting (ms) = N/A";
            ArduinoComTimeLabel.Text = "Arduino Communication (ms) = N/A";
        }

        private void StopWaveButton_Click(object sender, EventArgs e)
        {
            WaveFormTimer.Stop();

            appSettings.isDataReading = false;
            StartWaveButton.Enabled = true;
            StopWaveButton.Enabled = false;
            fftSettings.nFftContAvg = 1;

            LorentzStopButton.PerformClick();
            StopExportButton.PerformClick();
            StopFilterButton.PerformClick();
            StopDeflectionButton.PerformClick();

            LorentzStartButton.Enabled = false;
            LorentzStopButton.Enabled = false;
            StartDeflectionButton.Enabled = false;
            StopDeflectionButton.Enabled = false;
            StartExportButton.Enabled = false;
            StopExportButton.Enabled = false;
            StartFilterButton.Enabled = false;
            StopFilterButton.Enabled = false;
            StartPeakTrackButton.Enabled = false;
            StopPeakTrackButton.Enabled = false;
            ExportSnapShotButton.Enabled = false;
            PiezoButton.Enabled = false;
            btnStopChanelB.Enabled = false;
            btnStartChanelB.Enabled = false;
            tbChanelBRefreshRate.Enabled = true;

            DeflectionChart.Series["Series1"].Points.Clear();
            SpectrumBuildChart.Series["Series1"].Points.Clear();
        }

        private void UpdateWaveCharts()
        {
            WaveFormChart.Series["Series1"].Points.Clear();
            FftChart.Series["Series1"].Points.Clear();


            for (int i = 0; i < plottableData.WaveFormData.amp.Length; i++)
            {
                WaveFormChart.Series["Series1"].Points.AddXY(plottableData.WaveFormData.time[i] / 1e6, plottableData.WaveFormData.amp[i]); // time in us
                if (i%2 == 0)
                {
                    FftChart.Series["Series1"].Points.AddXY(plottableData.fftData.freq[i/2], plottableData.fftData.fft[i / 2]);
                }
            }
            lastfft = plottableData.fftData.fft;
        }

        private void FftComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCharts();
            NoAvButton.Checked = true;
            fftSettings.Fftstyle = FftComboBox.SelectedIndex;
            fftSettings.isFftStyleChange = true;
            fftSettings.nFftContAvg = 1;
        }

        private void MovAvTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(MovAvTextBox.Text, out fftSettings.nFftMovAvg))
            {
                MessageBox.Show("The input to the number of averages textbox must be an integer");
            }
        }

        private void FreqMaxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pM2WaveForm.timebase = (short)(FreqMaxComboBox.SelectedIndex + 1);
            NoAvButton.PerformClick();
            if (FreqMaxComboBox.SelectedIndex > 7)
            {
                WaveFormChart.ChartAreas[0].AxisX.Title = "Time (us)";
                FftChart.ChartAreas[0].AxisX.Title = "Frequency (kHz)";
            }
            else
            {
                WaveFormChart.ChartAreas[0].AxisX.Title = "Time (ns)";
                FftChart.ChartAreas[0].AxisX.Title = "Frequency (MHz)";
            }

        }

        private void VoltRangComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            channelSettings[0].range = (Imports.Range)(VoltRangComboBox.SelectedIndex);
            pM2WaveForm.ChangePicoVoltage(handle, channelSettings);
            WaveFormChart.ChartAreas[0].AxisY.Maximum = inputRanges[VoltRangComboBox.SelectedIndex];
            WaveFormChart.ChartAreas[0].AxisY.Minimum = inputRanges[VoltRangComboBox.SelectedIndex] * -1;
        }

        private void MovAvButton_CheckedChanged_1(object sender, EventArgs e)
        {
            fftSettings.isFftMovAvg = MovAvButton.Checked;
            fftSettings.nFftContAvg = 1;

            if (MovAvButton.Checked == true)
            {
                MovAvTextBox.Enabled = true;
            }
            else
            {
                MovAvTextBox.Enabled = false;
            }

            if (!Int32.TryParse(MovAvTextBox.Text, out fftSettings.nFftMovAvg))
            {
                MessageBox.Show("The input to the number of averages textbox must be an integer");
            }
        }

        private void ContAvButton_CheckedChanged_1(object sender, EventArgs e)
        {
            fftSettings.isFftContAvg = ContAvButton.Checked;
            fftSettings.nFftContAvg = 1;
        }

        private void ClearCharts()
        {
            FftChart.Series["Series2"].Points.Clear();
            WaveFormChart.Series["Series1"].Points.Clear();
            FftChart.Series["Series1"].Points.Clear();

        }

        private void ReadingRefreshRateTextBox_TextChanged(object sender, EventArgs e)
        {
            TimersIntervalUpdate(EqualizeRefreshRateCheckBox.Checked);
        }

        private void EqualizeRefreshRateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimersIntervalUpdate(EqualizeRefreshRateCheckBox.Checked);
        }
       

        //USB CAMERA
        private void StartVideoButton_Click(object sender, EventArgs e)
        {
            StartVideoButton.Enabled = false;
            StopViewingButton.Enabled = true;
            FinalFrame = new VideoCaptureDevice(CaptureDevice[0].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            totalSW.Start();

            Stopwatch sw = new Stopwatch();
            
            sw.Start();
            CamPictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
            sw.Stop();

            processTimes.microViewingTime = sw.Elapsed;

            CameraViewingTimeLabel.Text = "Microscope Viewing (ms) = " + Convert.ToString(processTimes.microViewingTime.Milliseconds);

            totalSW.Stop();
        }

        private void StopViewingButton_Click(object sender, EventArgs e)
        {
            FinalFrame.Stop();
            StartVideoButton.Enabled = true;
            StopViewingButton.Enabled = false;
        }

        //LORENTZ FITTING

        private void LorentzStartButton_Click(object sender, EventArgs e)
        {
            LorentzTimer.Start();
            appSettings.isFitting = true;
            LorentzStopButton.Enabled = true;
            LorentzStartButton.Enabled = false;
            StartPeakTrackButton.Enabled = true;
        }

        private void LorentzStopButton_Click(object sender, EventArgs e)
        {
            LorentzTimer.Stop();
            FftChart.Series["Series2"].Points.Clear();
            appSettings.isFitting = false;
            LorentzStartButton.Enabled = true;
            LorentzStopButton.Enabled = false;
            StartPeakTrackButton.Enabled = false;

            StopPeakTrackButton.PerformClick();

        }

        private void LorentzTimer_Tick(object sender, EventArgs e)
        {
            totalSW.Start();

            Stopwatch fittingSW = new Stopwatch();
            Stopwatch chartingSW = new Stopwatch();


            

            bool canTrimFFT;
            bool isIterMessage = false;
            bool isTrimMessage = false;
            bool isGuessMessage = false;
            lorentzSettings.trimStartFreq = 0;
            lorentzSettings.trimStopFreq = plottableData.fftData.freq.Max();

            //
            UpdateLorentzStartingPoints();

            // get trim frequency from user
            try
            {
                lorentzSettings.trimStartFreq = double.Parse(trimStartFreqTextBox.Text);
                lorentzSettings.trimStopFreq = double.Parse(trimStopFreqTextBox.Text);
                canTrimFFT = true;
            }
            catch (Exception)
            {
                canTrimFFT = false;
                LorentzTimer.Stop();
                StopWaveButton.PerformClick();
                if (!isTrimMessage)
                    MessageBox.Show("The trimming frequency inputs are not doubles");
                isTrimMessage = true;
            }

            // get algo iterations from user
            try
            {
                lorentzSettings.nIter = int.Parse(IterTextBox.Text);
            }
            catch (Exception)
            {
                if (!isIterMessage)
                    MessageBox.Show("The LMA Algorithm iterations input is not an integer, a default value of 100 will be used");
                isIterMessage = true;
                lorentzSettings.nIter = 100;
                
            }

            // trim FFT array based on user specifications
            if (lorentzSettings.isTrimFft && canTrimFFT)
            {
                LorentzFftData = pM2WaveForm.TrimFFT(plottableData.fftData, lorentzSettings);

            }
            else
            {
                LorentzFftData = plottableData.fftData;
            }

            // get Lorentz parameters and update lorentz chart based
            if (plottableData.fftData != null)
            {
                fittingSW.Start();
                pM2WaveForm.GetLorentzParams(LorentzFftData, lorentzSettings, ref lorentzParams);
                fittingSW.Stop();

                chartingSW.Start();
                UpdateLorenztCharts();
                chartingSW.Stop();
            }
            else
            {
                MessageBox.Show("Could not perform lorentzian fit. Please ensure you are reading data.");
                LorentzTimer.Stop();
                LorentzStartButton.Enabled = true;
                LorentzStopButton.Enabled = false;
            }

            fittingSW.Start();
            FittingMetrics = pM2WaveForm.GetFittingMetrics(lorentzParams, fftSettings);
            UpdateFittingMetricsDisplay();
            fittingSW.Stop();


            processTimes.fittingTime = fittingSW.Elapsed;

            chartingSW.Start();
            if (appSettings.isPeakTracking)
                UpdatePeakTrackerChart();
            chartingSW.Stop();

            peakTrackTime += LorentzTimer.Interval / 1000;

            processTimes.freqPlottingTime = chartingSW.Elapsed;
            processTimes.fittingTime = fittingSW.Elapsed;

            FreqDomainPlottingTimeLabel.Text = "Frequency Domain Plotting (ms) = " + Convert.ToString(processTimes.freqPlottingTime.Milliseconds);
            LorentzianFittingTimeLabel.Text = "Lorentzian Fitting (ms) = " + Convert.ToString(processTimes.fittingTime.Seconds*1e3 + processTimes.fittingTime.Milliseconds);

            totalSW.Stop();
        }

        private void UpdateFittingMetricsDisplay()
        {
            f0Label.Text = FittingMetrics.f0.ToString();
            f1Label.Text = FittingMetrics.f1.ToString();
            f2Label.Text = FittingMetrics.f2.ToString();
            amplitudeLabel.Text = FittingMetrics.amplitude.ToString();
            QLabel.Text = FittingMetrics.Q.ToString();
        }

        private void YShiftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lorentzSettings.isYShiftLorentz = YShiftCheckBox.Checked;
        }

        private void TrimFftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lorentzSettings.isTrimFft = TrimFftCheckBox.Checked;
            trimStopFreqTextBox.Enabled = TrimFftCheckBox.Checked;
            trimStartFreqTextBox.Enabled = TrimFftCheckBox.Checked;
        }

        private void PeakGuessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lorentzSettings.isStartingPointGuess = peakGuessCheckBox.Checked;
            if (lorentzSettings.isStartingPointGuess)
                UpdateLorentzStartingPoints();
        }

        private void UpdateLorentzStartingPoints()
        {
            try
            {
                lorentzSettings.startPointLP.f0 = double.Parse(MidFreqGuessTextBox.Text);

                lorentzSettings.startPointLP.up = double.Parse(InterGuessTextBox.Text);
                if (YShiftCheckBox.Checked)
                {
                    lorentzSettings.startPointLP.A = (double.Parse(AmpGuessTextBox.Text) - lorentzSettings.startPointLP.up);
                    lorentzSettings.startPointLP.gamma = 1;//- Math.Sqrt((lorentzSettings.startPointLP.A)/(lorentzSettings.startPointLP.A - lorentzSettings.startPointLP.up));
                }
                else
                {
                    lorentzSettings.startPointLP.A = double.Parse(AmpGuessTextBox.Text);
                    lorentzSettings.startPointLP.gamma =  1;
                }

            }
            catch (Exception)
            {

            }
        }

        private void LorentzRefreshRateTextBox_TextChanged(object sender, EventArgs e)
        {
            TimersIntervalUpdate(EqualizeRefreshRateCheckBox.Checked);
        }

        private void UpdateTrimTextBox()
        {
            trimStartFreqTextBox.Text = Math.Ceiling(FftChart.ChartAreas[0].AxisX.Minimum).ToString();
            trimStopFreqTextBox.Text = Math.Floor(FftChart.ChartAreas[0].AxisX.Maximum).ToString();
        }

        private bool IsPm2fdFreqRangeChanged()
        {

            try
            {
                if (double.Parse(trimStopFreqTextBox.Text) != Math.Floor(FftChart.ChartAreas[0].AxisX.Maximum) |
                    double.Parse(trimStartFreqTextBox.Text) != Math.Ceiling(FftChart.ChartAreas[0].AxisX.Minimum))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void UpdateLorenztCharts()
        {
            FftChart.Series["Series2"].Points.Clear();

            //transform lp class into an array so that LMAFunction.GetY() can read it 
            LorParArray[0] = lorentzParams.A;
            LorParArray[1] = lorentzParams.f0;
            LorParArray[2] = lorentzParams.gamma;

            if (lorentzSettings.isYShiftLorentz)
                LorParArray[3] = lorentzParams.up;
            else
                LorParArray[3] = 0;

            for (int i = 0; i < LorentzFftData.fft.Length; i++)
            {
                double yValue = lorentzShift.GetY(LorentzFftData.freq[i], LorParArray);
                FftChart.Series["Series2"].Points.AddXY(LorentzFftData.freq[i], yValue);
            }

            plottableData.lorentzFftData = LorentzFftData;
        }

        //PEAK TRACK

        private void StartPeakTrackButton_Click(object sender, EventArgs e)
        {
            appSettings.isPeakTracking = true;
            StopPeakTrackButton.Enabled = true;
            StartPeakTrackButton.Enabled = false;
        }

        private void StopPeakTrackButton_Click(object sender, EventArgs e)
        {
            appSettings.isPeakTracking = false;
            StopPeakTrackButton.Enabled = false;
            StartPeakTrackButton.Enabled = true;
            peakTrackerChart.Series["Series1"].Points.Clear();
            peakTrackTime = 0;
        }

        private void UpdatePeakTrackerChart()
        {
            peakTrackerChart.Series["Series1"].Points.AddXY(peakTrackTime, FittingMetrics.amplitude);
        }

        //ARDUINO COMMUNICATION

        private string AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException)
            {
                /* Do Nothing */
            }

            return null;
        }

        private void PiezoButton_Click(object sender, EventArgs e)
        {

            Stopwatch sw = new Stopwatch();

            sw.Start();
            if (isPicoPortOpen)
                picoPort.Write("P" + startFreqPiezoTextBox.Text + stopFreqPiezoTextBox.Text);
            sw.Stop();

            processTimes.ardunioComTime = sw.Elapsed;
            ArduinoComTimeLabel.Text = "Ardunio Communication (ms) = " + Convert.ToString(processTimes.ardunioComTime.Seconds);
        }

        // DATA EXPORT
        private void StartExportButton_Click(object sender, EventArgs e)
        {
            ExportTimer.Start();
            StopExportButton.Enabled = true;
            StartExportButton.Enabled = false;

        }

        private void ExportTimer_Tick(object sender, EventArgs e)
        {
            totalSW.Start();

            Stopwatch sw = new Stopwatch();

            ExportSettings.isWaveForm = WaveFormExportCheckBox.Checked;
            ExportSettings.isFFT = FreqExportCheckBox.Checked;
            ExportSettings.isDeflection = DeflectionCheckBox.Checked;
            ExportSettings.isPeakValue = PeakTrackCheckBox.Checked;
            ExportSettings.isLorentzian = LorentzCheckBox.Checked;
            ExportSettings.fileNamePrefix = fileNamePrefixTextBox.Text;
            ExportSettings.fileNamePrefix = "";

            sw.Start();
            pM2WaveForm.ExportWaveForm(ref plottableData, ExportSettings);
            sw.Stop();

            processTimes.exportTime = sw.Elapsed;

            totalSW.Stop();
        }

        private void StopExportButton_Click(object sender, EventArgs e)
        {
            ExportTimer.Stop();
            StartExportButton.Enabled = true;
            StopExportButton.Enabled = false;
        }

        private void ExportRateTextBox_TextChanged(object sender, EventArgs e)
        {
            TimersIntervalUpdate(EqualizeRefreshRateCheckBox.Checked);
        }

        // LONG TIME DOMAIN

        private void StartDeflectionButton_Click(object sender, EventArgs e)
        {
            DeflectionChart.Series["Series1"].Points.Clear();
            appSettings.isDeflectionReading = true;
            StartDeflectionButton.Enabled = false;
            StopDeflectionButton.Enabled = true;
            DeflectionStartTime = DateTime.Now;
            if(SpectrumBuildCheckBox.Checked)
                SpecBuildStartTime = DateTime.Now;
            
        }

        private void StopDeflectionButton_Click(object sender, EventArgs e)
        {
            appSettings.isDeflectionReading = false;
            StartDeflectionButton.Enabled = true;
            StopDeflectionButton.Enabled = false;
        }

        private void UpdateDeflectionCharts()
        {
            //Convert.ToDouble(DateTime.Now - DeflectionStartTime)
            DeflectionChart.ChartAreas[0].AxisX.Minimum = TimeSpantoMilisecond(DateTime.Now - DeflectionStartTime) - specBuildPeriod * 10;
            DeflectionChart.Series["Series1"].Points.AddXY(TimeSpantoMilisecond(DateTime.Now - DeflectionStartTime), plottableData.WaveFormData.amp.Average());
            deflectionTrackTime += WaveFormTimer.Interval;

            DeflectionList.Add(plottableData.WaveFormData.amp.Average());
            /*if (plottableData.DeflectionList == null)
            {
                List<double> DeflectionList = new List<double>();
                plottableData.DeflectionList = DeflectionList;
                plottableData.DeflectionList[0] = plottableData.WaveFormData.amp.Average();
            
            }
            else */
            if (appSettings.isSpectrumBuilding & DeflectionList.Count >= GetMaxDeflectionListLength())
                    UpdateSpectrumBuildingChart();
            

        }

        private void UpdateSpectrumBuildingChart()
        {

            SpectrumBuildChart.Series["Series1"].Points.AddXY(TimeSpantoMilisecond(DateTime.Now - SpecBuildStartTime), DeflectionList.Skip(GetSpecBuildDataPointsToSkip()).Average());
            spectBuilTrackTime += specBuildPeriod; //pulse period
            DeflectionList.Clear();
            
        }

        private double TimeSpantoMilisecond( TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds;
        }

        private int GetMaxDeflectionListLength()
        {
            return Convert.ToInt32(specBuildPeriod / WaveFormTimer.Interval); // max  = 1000 / pulse frequency / refresh rate 
        }

        private int GetSpecBuildDataPointsToSkip()
        {
            int maxDeflectionListLength = GetMaxDeflectionListLength();
            double lookBackTime = double.Parse(BackAvPeriodTextBox.Text);
            int lookBackTimeDataPointsLength = Convert.ToInt32(Math.Ceiling(specBuildPeriod / lookBackTime));

            return maxDeflectionListLength - lookBackTimeDataPointsLength;
        }

        private void PulseFrequencyTextBox_TextChanged(object sender, EventArgs e)
        {
            specBuildPeriod = 1e3 / double.Parse(PulseFrequencyTextBox.Text) / 2 ;
        }

        private void SpectrumBuildCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SpectrumBuildCheckBox.Checked)
                SpecBuildStartTime = DateTime.Now;
        }


        private void BufferSizeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NoAvButton.Checked = true;
            _sampleCount = int.Parse(BufferSizeComboBox.SelectedItem.ToString());

            if (BufferSizeComboBox.SelectedIndex > 2)
            {
                WaveFormChart.ChartAreas[0].AxisX.Title = "Time (us)";
                FftChart.ChartAreas[0].AxisX.Title = "Frequency (kHz)";
            }
            else
            {
                WaveFormChart.ChartAreas[0].AxisX.Title = "Time (ns)";
                FftChart.ChartAreas[0].AxisX.Title = "Frequency (MHz)";
            }
        }


        private void btnStartChanelB_Click(object sender, EventArgs e)
        {
            btnStopChanelB.Enabled = true;
            btnStartChanelB.Enabled = false;
            tbChanelBRefreshRate.Enabled = false;

            appSettings.isChanelB = true;
            ChanelBCountDown = 0;
        }

        private void btnStopChanelB_Click(object sender, EventArgs e)
        {
            btnStartChanelB.Enabled = true;
            btnStopChanelB.Enabled = false;
            tbChanelBRefreshRate.Enabled = true;

            appSettings.isChanelB = false;
            ChanelBCountDown = -1;
        }
    }
}
