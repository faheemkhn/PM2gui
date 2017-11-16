using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM2Waveform;
using System.Windows.Forms.DataVisualization.Charting;
using PS2000Imports;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO.Ports;
using System.Management;
using DotNetMatrix;
using Net.Kniaz.LMA;

namespace PM2gui
{
    public partial class PM2gui : Form
    {
        public PM2gui()
        {
            InitializeComponent();
            this.shortTimeDomainChart.MouseMove += new MouseEventHandler(pM2tD_MouseMove);
            this.tooltiptD.AutomaticDelay = 10;
            this.freqDomainChart.MouseMove += new MouseEventHandler(pM2fD_MouseMove);
            this.tooltipfD.AutomaticDelay = 10;
        }

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

        short handle;
       
        double[] lastfft = null;
        bool isPicoPortOpen = false;
        double[] LorParArray = new double[4];
        double pM2f_min;
        double pM2f_max;

        private void PM2gui_Load(object sender, EventArgs e)
        {

            PicoscopeInit();
            AmscopeInit();
            ChartsInit();
            PicoPortInit();
            ButtonInit();

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
                channelSettings = pM2WaveForm.InitPico(handle);
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
            CamComboBox.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void ChartsInit()
        {
            //init charts
            //time domain
            shortTimeDomainChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            shortTimeDomainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            shortTimeDomainChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            shortTimeDomainChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            shortTimeDomainChart.ChartAreas[0].AxisX.Minimum = 0;
            shortTimeDomainChart.ChartAreas[0].AxisY.Maximum = inputRanges[VoltRangComboBox.SelectedIndex];
            shortTimeDomainChart.ChartAreas[0].AxisY.Minimum = inputRanges[VoltRangComboBox.SelectedIndex] * -1;
            //pM2tD.ChartAreas[0].AxisY.Interval = 100;
            //pM2tD.ChartAreas[0].AxisY.Interval = 2000;
            shortTimeDomainChart.ChartAreas[0].AxisX.Title = "Time (us)";
            shortTimeDomainChart.ChartAreas[0].AxisY.Title = "Amplitude (mV)";


            //frequency domain
            freqDomainChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            freqDomainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            freqDomainChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            freqDomainChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            freqDomainChart.ChartAreas[0].CursorY.IsUserEnabled = true;
            freqDomainChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            freqDomainChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            freqDomainChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            freqDomainChart.ChartAreas[0].AxisX.Title = "Frequency (kHz)";
            freqDomainChart.ChartAreas[0].AxisY.Title = "Magnitude";
            //pM2fD.ChartAreas[0].AxisY.Interval = 2000;
            //pM2fD.ChartAreas[0].AxisX.Minimum = 0;
            //pM2fD.ChartAreas[0].AxisX.Maximum = 100;
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
            pM2f_min = Math.Ceiling(freqDomainChart.ChartAreas[0].AxisX.Minimum);
            pM2f_max = Math.Floor(freqDomainChart.ChartAreas[0].AxisX.Maximum);

            //lorentz
            LorentzStopButton.Enabled = false;
            YShiftCheckBox.Enabled = false;
            TrimFftCheckBox.Enabled = false;
            trimStopFreqTextBox.Enabled = false;
            trimStartFreqTextBox.Enabled = false;
            IterTextBox.Enabled = false;
            PeakGuessTextBox.Enabled = false;
            peakGuessCheckBox.Enabled = false;
        }

        private void PM2gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            pM2WaveForm.ShutDown(handle);
            if (isPicoPortOpen)
                picoPort.Close();
        }

        private void pM2tD_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPositiontD.HasValue && pos == prevPositiontD.Value)
                return;
            tooltiptD.RemoveAll();
            prevPositiontD = pos;
            var results = shortTimeDomainChart.HitTest(pos.X, pos.Y, false,
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
                            tooltiptD.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.shortTimeDomainChart,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        private void pM2fD_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPositionfD.HasValue && pos == prevPositionfD.Value)
                return;
            tooltipfD.RemoveAll();
            prevPositionfD = pos;
            var results = freqDomainChart.HitTest(pos.X, pos.Y, false,
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
                            tooltipfD.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.freqDomainChart,
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
            StartWaveButton.Enabled = false;
            StopWaveButton.Enabled = true;
        }

        private void WaveFormTimer_Tick(object sender, EventArgs e)
        {
            plottableData = pM2WaveForm.GetPlottableData(handle, channelSettings, fftSettings, lastfft);
            fftSettings.isFftStyleChange = false;
            UpdateWaveCharts();
            if (isPm2fdFreqRangeChanged() & !TrimFftCheckBox.Checked)
                UpdateTrimTextBox();
        }

        private void StopWaveButton_Click(object sender, EventArgs e)
        {
            WaveFormTimer.Stop();
            LorentzTimer.Stop();
            StartWaveButton.Enabled = true;
            StopWaveButton.Enabled = false;
            LorentzStartButton.Enabled = false;
            LorentzStopButton.Enabled = false;
            fftSettings.nFftContAvg = 1;
        }

        private void UpdateWaveCharts()
        {
            shortTimeDomainChart.Series["Series1"].Points.Clear();
            freqDomainChart.Series["Series1"].Points.Clear();

            for (int i = 0; i < plottableData.WaveFormData.amp.Length; i++)
            {
                shortTimeDomainChart.Series["Series1"].Points.AddXY(plottableData.WaveFormData.time[i] / 1e6, plottableData.WaveFormData.amp[i]); // time in us
                if (i%2 == 0)
                {
                    freqDomainChart.Series["Series1"].Points.AddXY(plottableData.fftData.freq[i/2], plottableData.fftData.fft[i / 2]);
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
        }

        private void VoltRangComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            channelSettings[0].range = (Imports.Range)(VoltRangComboBox.SelectedIndex);
            pM2WaveForm.ChangePicoVoltage(handle, channelSettings);
            shortTimeDomainChart.ChartAreas[0].AxisY.Maximum = inputRanges[VoltRangComboBox.SelectedIndex];
            shortTimeDomainChart.ChartAreas[0].AxisY.Minimum = inputRanges[VoltRangComboBox.SelectedIndex] * -1;
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
            freqDomainChart.Series["Series2"].Points.Clear();
            shortTimeDomainChart.Series["Series1"].Points.Clear();
            freqDomainChart.Series["Series1"].Points.Clear();

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
            CamPictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void StopViewingButton_Click(object sender, EventArgs e)
        {
            FinalFrame.Stop();
            StartVideoButton.Enabled = true;
            StopViewingButton.Enabled = false;
        }




        //LORENTZ FITTING

        private void LorentzTimer_Tick(object sender, EventArgs e)
        {
            bool canTrimFFT;
            bool isIterMessage = false;
            bool isTrimMessage = false;
            bool isPeakMessage = false;
            lorentzSettings.trimStartFreq = 0;
            lorentzSettings.trimStopFreq = plottableData.fftData.freq.Max();

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
                lorentzSettings.nIter = 100;
                isIterMessage = true;
            }

            // get peak guess from user
            try
            {
                lorentzSettings.PeakGuess = double.Parse(PeakGuessTextBox.Text);
            }
            catch (Exception)
            {
                if (!isPeakMessage)
                    MessageBox.Show("The peak guess is not a double, a default value of 25 will be used");
                lorentzSettings.PeakGuess = 25;
                isPeakMessage = true;
            }

            if (lorentzSettings.isTrimFft && canTrimFFT)
            {
                LorentzFftData = pM2WaveForm.TrimFFT(plottableData.fftData, lorentzSettings);

            }
            else
            {
                LorentzFftData = plottableData.fftData;
            }

            if (plottableData.fftData != null)
            {
                lorentzParams = pM2WaveForm.GetLorentzParams(LorentzFftData, lorentzSettings);


                UpdateLorenztCharts();
            }
            else
            {
                MessageBox.Show("Could not perform lorentzian fit. Please ensure you are reading data.");
                LorentzTimer.Stop();
                LorentzStartButton.Enabled = true;
                LorentzStopButton.Enabled = false;
            }

            FittingMetrics = pM2WaveForm.GetFittingMetrics(lorentzParams, fftSettings);
            UpdateFittingMetricsDisplay();
        }

        private void UpdateLorenztCharts()
        {
            freqDomainChart.Series["Series2"].Points.Clear();

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
                freqDomainChart.Series["Series2"].Points.AddXY(LorentzFftData.freq[i], yValue);
            }
        }

        private void UpdateFittingMetricsDisplay()
        {
            f0Label.Text = FittingMetrics.f0.ToString();
            f1Label.Text = FittingMetrics.f1.ToString();
            f2Label.Text = FittingMetrics.f2.ToString();
            amplitudeLabel.Text = FittingMetrics.amplitude.ToString();
            QLabel.Text = FittingMetrics.Q.ToString();
        }

        private void LorentzStartButton_Click(object sender, EventArgs e)
        {
            LorentzTimer.Start();
            LorentzStopButton.Enabled = true;
            LorentzStartButton.Enabled = false;
            YShiftCheckBox.Enabled = true;
            TrimFftCheckBox.Enabled = true;
            IterTextBox.Enabled = true;
            peakGuessCheckBox.Enabled = true;
        }

        private void LorentzStopButton_Click(object sender, EventArgs e)
        {
            LorentzTimer.Stop();
            freqDomainChart.Series["Series2"].Points.Clear();
            LorentzStartButton.Enabled = true;
            LorentzStopButton.Enabled = false;
            YShiftCheckBox.Enabled = false;
            TrimFftCheckBox.Enabled = true;
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

        private void peakGuessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PeakGuessTextBox.Enabled = peakGuessCheckBox.Checked;
        }

        private void UpdateTrimTextBox()
        {
            trimStartFreqTextBox.Text = Math.Ceiling(freqDomainChart.ChartAreas[0].AxisX.Minimum).ToString();
            trimStopFreqTextBox.Text = Math.Floor(freqDomainChart.ChartAreas[0].AxisX.Maximum).ToString();
        }

        private bool isPm2fdFreqRangeChanged()
        {

            try
            {
                if (double.Parse(trimStopFreqTextBox.Text) != Math.Floor(freqDomainChart.ChartAreas[0].AxisX.Maximum) |
                    double.Parse(trimStartFreqTextBox.Text) != Math.Ceiling(freqDomainChart.ChartAreas[0].AxisX.Minimum))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

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
            if (isPicoPortOpen)
                picoPort.Write("P" + startFreqPiezoTextBox.Text + stopFreqPiezoTextBox.Text);
        }

    }
}
