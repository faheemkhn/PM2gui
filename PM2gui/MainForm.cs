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
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace PM2gui
{
    public partial class PM2gui : Form
    {
        public PM2gui()
        {
            InitializeComponent();
            this.pM2tD.MouseMove += new MouseEventHandler(pM2tD_MouseMove);
            this.tooltiptD.AutomaticDelay = 10;
            this.pM2fD.MouseMove += new MouseEventHandler(pM2fD_MouseMove);
            this.tooltipfD.AutomaticDelay = 10;
        }

        PM2WaveForm pM2WaveForm = new PM2WaveForm();
        Pico.ChannelSettings[] channelSettings = new Pico.ChannelSettings[Pico.PicoInterfacer.MAX_CHANNELS];
        PM2WaveForm.WaveFormData waveFormData = new PM2WaveForm.WaveFormData();
        PM2WaveForm.PlottableData plottableData = new PM2WaveForm.PlottableData();
        FilterInfoCollection CaptureDevice;
        VideoCaptureDevice FinalFrame;
        System.Drawing.Point? prevPositiontD = null;
        ToolTip tooltiptD = new ToolTip();
        System.Drawing.Point? prevPositionfD = null;
        ToolTip tooltipfD = new ToolTip();

        short handle;

        private void PM2gui_Load(object sender, EventArgs e)
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

            //Init USB Camera
            StopViewingButton.Enabled = false;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                CamComboBox.Items.Add(Device.Name);
            }
            CamComboBox.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();

            //init charts
            //time domain
            pM2tD.ChartAreas[0].CursorX.IsUserEnabled = true;
            pM2tD.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            pM2tD.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            pM2tD.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            pM2tD.ChartAreas[0].AxisX.Maximum = 1000;
            pM2tD.ChartAreas[0].AxisX.Minimum = 0;
            pM2tD.ChartAreas[0].AxisX.Interval = 100;
            pM2tD.ChartAreas[0].AxisY.Interval = 2000;


            //frequency domain
            pM2fD.ChartAreas[0].CursorX.IsUserEnabled = true;
            pM2fD.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            pM2fD.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            pM2fD.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            pM2fD.ChartAreas[0].CursorY.IsUserEnabled = true;
            pM2fD.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            pM2fD.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            pM2fD.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            //pM2fD.ChartAreas[0].AxisY.Interval = 200;
            pM2fD.ChartAreas[0].AxisX.Minimum = 0;
            pM2fD.ChartAreas[0].AxisX.Interval = 100;
        }

        private void pM2tD_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPositiontD.HasValue && pos == prevPositiontD.Value)
                return;
            tooltiptD.RemoveAll();
            prevPositiontD = pos;
            var results = pM2tD.HitTest(pos.X, pos.Y, false,
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
                            tooltiptD.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.pM2tD,
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
            var results = pM2fD.HitTest(pos.X, pos.Y, false,
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
                            tooltipfD.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.pM2fD,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        private void StartWaveButton_Click(object sender, EventArgs e)
        {
            WaveFormTimer.Start();
            StartWaveButton.Enabled = false;
            StopWaveButton.Enabled = true;
        }

        private void WaveFormTimer_Tick(object sender, EventArgs e)
        {
            plottableData = pM2WaveForm.GetPlottableData(handle, channelSettings);
            UpdateCharts();

        }

        private void StopWaveButton_Click(object sender, EventArgs e)
        {
            WaveFormTimer.Stop();
            StartWaveButton.Enabled = true;
            StopWaveButton.Enabled = false;

        }

        private void UpdateCharts()
        {
            pM2tD.Series["Series1"].Points.Clear();
            pM2fD.Series["Series1"].Points.Clear();

            for (int i = 0; i < plottableData.WaveFormData.amp.Length; i++)
            {
                pM2tD.Series["Series1"].Points.AddXY(plottableData.WaveFormData.time[i] / 1e6, plottableData.WaveFormData.amp[i]); // time in ms
                if (i%2 == 0)
                {
                    pM2fD.Series["Series1"].Points.AddXY((i / 2 - 0.221) / 1.3072, plottableData.fft[i / 2] / plottableData.fft.Max());
                }

            }
        }

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

        private void PM2gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            pM2WaveForm.ShutDown(handle);
        }
    }
}
