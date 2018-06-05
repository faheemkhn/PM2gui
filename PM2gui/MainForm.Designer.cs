using System.Windows.Forms;

namespace PM2gui
{
    partial class PM2gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM2gui));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StartPeakTrackButton = new System.Windows.Forms.Button();
            this.FittingRefreshRateTextBox = new System.Windows.Forms.Label();
            this.LorentzRefreshRateTextBox = new System.Windows.Forms.TextBox();
            this.QLabel = new System.Windows.Forms.Label();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.FftTimeLabel = new System.Windows.Forms.Label();
            this.FreqDomainPlottingTimeLabel = new System.Windows.Forms.Label();
            this.ArduinoComTimeLabel = new System.Windows.Forms.Label();
            this.CameraViewingTimeLabel = new System.Windows.Forms.Label();
            this.LorentzianFittingTimeLabel = new System.Windows.Forms.Label();
            this.TimeDomainPlottingTimeLabel = new System.Windows.Forms.Label();
            this.DataSamplingTimeLabel = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.StopPeakTrackButton = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnStopChanelB = new System.Windows.Forms.Button();
            this.btnStartChanelB = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.tbChanelBRefreshRate = new System.Windows.Forms.TextBox();
            this.f2Label = new System.Windows.Forms.Label();
            this.f1Label = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.LorentzStartButton = new System.Windows.Forms.Button();
            this.LorentzStopButton = new System.Windows.Forms.Button();
            this.f0Label = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.EqualizeRefreshRateCheckBox = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ReadingRefreshRateTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.btnPressureStop = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnPressure = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.BufferSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BR = new System.Windows.Forms.TextBox();
            this.textBoxBR = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBoxBL = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxTL = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBoxTR = new System.Windows.Forms.TextBox();
            this.trackBarBL = new System.Windows.Forms.TrackBar();
            this.trackBarBR = new System.Windows.Forms.TrackBar();
            this.trackBarTL = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarTR = new System.Windows.Forms.TrackBar();
            this.ChanelBWave = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.StopWaveButton = new System.Windows.Forms.Button();
            this.StartWaveButton = new System.Windows.Forms.Button();
            this.VoltRangComboBox = new System.Windows.Forms.ComboBox();
            this.FreqMaxComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FftComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NoAvButton = new System.Windows.Forms.RadioButton();
            this.ContAvButton = new System.Windows.Forms.RadioButton();
            this.MovAvButton = new System.Windows.Forms.RadioButton();
            this.stopFreqPiezoTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PiezoButton = new System.Windows.Forms.Button();
            this.startFreqPiezoTextBox = new System.Windows.Forms.MaskedTextBox();
            this.InterGuessTextBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.AmpGuessTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.StopViewingButton = new System.Windows.Forms.Button();
            this.MovAvTextBox = new System.Windows.Forms.TextBox();
            this.peakGuessCheckBox = new System.Windows.Forms.CheckBox();
            this.StartVideoButton = new System.Windows.Forms.Button();
            this.CamComboBox = new System.Windows.Forms.ComboBox();
            this.FftChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.WaveFormChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.CamPictureBox = new System.Windows.Forms.PictureBox();
            this.MidFreqGuessTextBox = new System.Windows.Forms.TextBox();
            this.IterTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.StartExportButton = new System.Windows.Forms.Button();
            this.btnFreqStop = new System.Windows.Forms.Button();
            this.fixedGroup = new System.Windows.Forms.Panel();
            this.FixedFreqPiezoTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.fileNamePrefixTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.DeflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.PeakTrackCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ExportSnapShotButton = new System.Windows.Forms.Button();
            this.LorentzCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportRateTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.FreqExportCheckBox = new System.Windows.Forms.CheckBox();
            this.WaveFormExportCheckBox = new System.Windows.Forms.CheckBox();
            this.StopExportButton = new System.Windows.Forms.Button();
            this.radioButtonFixed = new System.Windows.Forms.RadioButton();
            this.radioButtonSweep = new System.Windows.Forms.RadioButton();
            this.sweepGroup = new System.Windows.Forms.Panel();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.btnDisconnectPort = new System.Windows.Forms.Button();
            this.btnConnectPort = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.peakTrackerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.YShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.trimStartFreqTextBox = new System.Windows.Forms.TextBox();
            this.TrimFftCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trimStopFreqTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChanelBTimer = new System.Windows.Forms.Timer(this.components);
            this.ExportTimer = new System.Windows.Forms.Timer(this.components);
            this.WaveFormTimer = new System.Windows.Forms.Timer(this.components);
            this.LorentzTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChanelBWave)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FftChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WaveFormChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).BeginInit();
            this.fixedGroup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.sweepGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakTrackerChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.btnPressureStop);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.label35);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.btnPressure);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.BR);
            this.tabPage1.Controls.Add(this.textBoxBR);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.textBoxBL);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.textBoxTL);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBoxTR);
            this.tabPage1.Controls.Add(this.trackBarBL);
            this.tabPage1.Controls.Add(this.trackBarBR);
            this.tabPage1.Controls.Add(this.trackBarTL);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.trackBarTR);
            this.tabPage1.Controls.Add(this.ChanelBWave);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.StopViewingButton);
            this.tabPage1.Controls.Add(this.StartVideoButton);
            this.tabPage1.Controls.Add(this.CamComboBox);
            this.tabPage1.Controls.Add(this.FftChart);
            this.tabPage1.Controls.Add(this.WaveFormChart);
            this.tabPage1.Controls.Add(this.CamPictureBox);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.peakTrackerChart);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StartPeakTrackButton
            // 
            resources.ApplyResources(this.StartPeakTrackButton, "StartPeakTrackButton");
            this.StartPeakTrackButton.Name = "StartPeakTrackButton";
            this.StartPeakTrackButton.TabStop = false;
            this.StartPeakTrackButton.UseVisualStyleBackColor = true;
            // 
            // FittingRefreshRateTextBox
            // 
            resources.ApplyResources(this.FittingRefreshRateTextBox, "FittingRefreshRateTextBox");
            this.FittingRefreshRateTextBox.Name = "FittingRefreshRateTextBox";
            // 
            // LorentzRefreshRateTextBox
            // 
            resources.ApplyResources(this.LorentzRefreshRateTextBox, "LorentzRefreshRateTextBox");
            this.LorentzRefreshRateTextBox.Name = "LorentzRefreshRateTextBox";
            // 
            // QLabel
            // 
            resources.ApplyResources(this.QLabel, "QLabel");
            this.QLabel.Name = "QLabel";
            // 
            // amplitudeLabel
            // 
            resources.ApplyResources(this.amplitudeLabel, "amplitudeLabel");
            this.amplitudeLabel.Name = "amplitudeLabel";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.FftTimeLabel);
            this.groupBox10.Controls.Add(this.FreqDomainPlottingTimeLabel);
            this.groupBox10.Controls.Add(this.ArduinoComTimeLabel);
            this.groupBox10.Controls.Add(this.CameraViewingTimeLabel);
            this.groupBox10.Controls.Add(this.LorentzianFittingTimeLabel);
            this.groupBox10.Controls.Add(this.TimeDomainPlottingTimeLabel);
            this.groupBox10.Controls.Add(this.DataSamplingTimeLabel);
            resources.ApplyResources(this.groupBox10, "groupBox10");
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.TabStop = false;
            // 
            // FftTimeLabel
            // 
            resources.ApplyResources(this.FftTimeLabel, "FftTimeLabel");
            this.FftTimeLabel.Name = "FftTimeLabel";
            // 
            // FreqDomainPlottingTimeLabel
            // 
            resources.ApplyResources(this.FreqDomainPlottingTimeLabel, "FreqDomainPlottingTimeLabel");
            this.FreqDomainPlottingTimeLabel.Name = "FreqDomainPlottingTimeLabel";
            // 
            // ArduinoComTimeLabel
            // 
            resources.ApplyResources(this.ArduinoComTimeLabel, "ArduinoComTimeLabel");
            this.ArduinoComTimeLabel.Name = "ArduinoComTimeLabel";
            // 
            // CameraViewingTimeLabel
            // 
            resources.ApplyResources(this.CameraViewingTimeLabel, "CameraViewingTimeLabel");
            this.CameraViewingTimeLabel.Name = "CameraViewingTimeLabel";
            // 
            // LorentzianFittingTimeLabel
            // 
            resources.ApplyResources(this.LorentzianFittingTimeLabel, "LorentzianFittingTimeLabel");
            this.LorentzianFittingTimeLabel.Name = "LorentzianFittingTimeLabel";
            // 
            // TimeDomainPlottingTimeLabel
            // 
            resources.ApplyResources(this.TimeDomainPlottingTimeLabel, "TimeDomainPlottingTimeLabel");
            this.TimeDomainPlottingTimeLabel.Name = "TimeDomainPlottingTimeLabel";
            // 
            // DataSamplingTimeLabel
            // 
            resources.ApplyResources(this.DataSamplingTimeLabel, "DataSamplingTimeLabel");
            this.DataSamplingTimeLabel.Name = "DataSamplingTimeLabel";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.StartPeakTrackButton);
            this.groupBox8.Controls.Add(this.StopPeakTrackButton);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // StopPeakTrackButton
            // 
            resources.ApplyResources(this.StopPeakTrackButton, "StopPeakTrackButton");
            this.StopPeakTrackButton.Name = "StopPeakTrackButton";
            this.StopPeakTrackButton.TabStop = false;
            this.StopPeakTrackButton.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnStopChanelB);
            this.groupBox11.Controls.Add(this.btnStartChanelB);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Controls.Add(this.tbChanelBRefreshRate);
            resources.ApplyResources(this.groupBox11, "groupBox11");
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.TabStop = false;
            // 
            // btnStopChanelB
            // 
            resources.ApplyResources(this.btnStopChanelB, "btnStopChanelB");
            this.btnStopChanelB.Name = "btnStopChanelB";
            this.btnStopChanelB.TabStop = false;
            this.btnStopChanelB.UseVisualStyleBackColor = true;
            // 
            // btnStartChanelB
            // 
            resources.ApplyResources(this.btnStartChanelB, "btnStartChanelB");
            this.btnStartChanelB.Name = "btnStartChanelB";
            this.btnStartChanelB.TabStop = false;
            this.btnStartChanelB.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // tbChanelBRefreshRate
            // 
            resources.ApplyResources(this.tbChanelBRefreshRate, "tbChanelBRefreshRate");
            this.tbChanelBRefreshRate.Name = "tbChanelBRefreshRate";
            // 
            // f2Label
            // 
            resources.ApplyResources(this.f2Label, "f2Label");
            this.f2Label.Name = "f2Label";
            // 
            // f1Label
            // 
            resources.ApplyResources(this.f1Label, "f1Label");
            this.f1Label.Name = "f1Label";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.FittingRefreshRateTextBox);
            this.groupBox7.Controls.Add(this.LorentzRefreshRateTextBox);
            this.groupBox7.Controls.Add(this.QLabel);
            this.groupBox7.Controls.Add(this.amplitudeLabel);
            this.groupBox7.Controls.Add(this.LorentzStartButton);
            this.groupBox7.Controls.Add(this.f2Label);
            this.groupBox7.Controls.Add(this.LorentzStopButton);
            this.groupBox7.Controls.Add(this.f1Label);
            this.groupBox7.Controls.Add(this.f0Label);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // LorentzStartButton
            // 
            resources.ApplyResources(this.LorentzStartButton, "LorentzStartButton");
            this.LorentzStartButton.Name = "LorentzStartButton";
            this.LorentzStartButton.TabStop = false;
            this.LorentzStartButton.UseVisualStyleBackColor = true;
            // 
            // LorentzStopButton
            // 
            resources.ApplyResources(this.LorentzStopButton, "LorentzStopButton");
            this.LorentzStopButton.Name = "LorentzStopButton";
            this.LorentzStopButton.TabStop = false;
            this.LorentzStopButton.UseVisualStyleBackColor = true;
            // 
            // f0Label
            // 
            resources.ApplyResources(this.f0Label, "f0Label");
            this.f0Label.Name = "f0Label";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // EqualizeRefreshRateCheckBox
            // 
            resources.ApplyResources(this.EqualizeRefreshRateCheckBox, "EqualizeRefreshRateCheckBox");
            this.EqualizeRefreshRateCheckBox.Checked = true;
            this.EqualizeRefreshRateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EqualizeRefreshRateCheckBox.Name = "EqualizeRefreshRateCheckBox";
            this.EqualizeRefreshRateCheckBox.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // ReadingRefreshRateTextBox
            // 
            resources.ApplyResources(this.ReadingRefreshRateTextBox, "ReadingRefreshRateTextBox");
            this.ReadingRefreshRateTextBox.Name = "ReadingRefreshRateTextBox";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // nudTime
            // 
            resources.ApplyResources(this.nudTime, "nudTime");
            this.nudTime.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            // 
            // btnPressureStop
            // 
            resources.ApplyResources(this.btnPressureStop, "btnPressureStop");
            this.btnPressureStop.Name = "btnPressureStop";
            this.btnPressureStop.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.Name = "label35";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // btnPressure
            // 
            resources.ApplyResources(this.btnPressure, "btnPressure");
            this.btnPressure.Name = "btnPressure";
            this.btnPressure.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // BufferSizeComboBox
            // 
            this.BufferSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BufferSizeComboBox.FormattingEnabled = true;
            this.BufferSizeComboBox.Items.AddRange(new object[] {
            resources.GetString("BufferSizeComboBox.Items"),
            resources.GetString("BufferSizeComboBox.Items1"),
            resources.GetString("BufferSizeComboBox.Items2"),
            resources.GetString("BufferSizeComboBox.Items3"),
            resources.GetString("BufferSizeComboBox.Items4"),
            resources.GetString("BufferSizeComboBox.Items5"),
            resources.GetString("BufferSizeComboBox.Items6"),
            resources.GetString("BufferSizeComboBox.Items7")});
            resources.ApplyResources(this.BufferSizeComboBox, "BufferSizeComboBox");
            this.BufferSizeComboBox.Name = "BufferSizeComboBox";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // BR
            // 
            resources.ApplyResources(this.BR, "BR");
            this.BR.Name = "BR";
            this.BR.ReadOnly = true;
            // 
            // textBoxBR
            // 
            resources.ApplyResources(this.textBoxBR, "textBoxBR");
            this.textBoxBR.Name = "textBoxBR";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            // 
            // textBoxBL
            // 
            resources.ApplyResources(this.textBoxBL, "textBoxBL");
            this.textBoxBL.Name = "textBoxBL";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // textBoxTL
            // 
            resources.ApplyResources(this.textBoxTL, "textBoxTL");
            this.textBoxTL.Name = "textBoxTL";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            // 
            // textBoxTR
            // 
            resources.ApplyResources(this.textBoxTR, "textBoxTR");
            this.textBoxTR.Name = "textBoxTR";
            // 
            // trackBarBL
            // 
            resources.ApplyResources(this.trackBarBL, "trackBarBL");
            this.trackBarBL.Maximum = 7000;
            this.trackBarBL.Name = "trackBarBL";
            this.trackBarBL.TickFrequency = 1000;
            // 
            // trackBarBR
            // 
            resources.ApplyResources(this.trackBarBR, "trackBarBR");
            this.trackBarBR.Maximum = 7000;
            this.trackBarBR.Name = "trackBarBR";
            this.trackBarBR.TickFrequency = 1000;
            this.trackBarBR.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // trackBarTL
            // 
            resources.ApplyResources(this.trackBarTL, "trackBarTL");
            this.trackBarTL.Maximum = 7000;
            this.trackBarTL.Name = "trackBarTL";
            this.trackBarTL.TickFrequency = 1000;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::PM2gui.Properties.Resources.Cantilever;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // trackBarTR
            // 
            this.trackBarTR.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.trackBarTR, "trackBarTR");
            this.trackBarTR.Maximum = 7000;
            this.trackBarTR.Name = "trackBarTR";
            this.trackBarTR.TickFrequency = 1000;
            this.trackBarTR.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // ChanelBWave
            // 
            chartArea1.Name = "ChartArea1";
            this.ChanelBWave.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.ChanelBWave, "ChanelBWave");
            this.ChanelBWave.Name = "ChanelBWave";
            this.ChanelBWave.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Black;
            series1.Name = "Series1";
            this.ChanelBWave.Series.Add(series1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BufferSizeComboBox);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.EqualizeRefreshRateCheckBox);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.ReadingRefreshRateTextBox);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.StopWaveButton);
            this.groupBox6.Controls.Add(this.StartWaveButton);
            this.groupBox6.Controls.Add(this.VoltRangComboBox);
            this.groupBox6.Controls.Add(this.FreqMaxComboBox);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.FftComboBox);
            this.groupBox6.Controls.Add(this.label7);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // StopWaveButton
            // 
            resources.ApplyResources(this.StopWaveButton, "StopWaveButton");
            this.StopWaveButton.Name = "StopWaveButton";
            this.StopWaveButton.TabStop = false;
            this.StopWaveButton.UseVisualStyleBackColor = true;
            // 
            // StartWaveButton
            // 
            resources.ApplyResources(this.StartWaveButton, "StartWaveButton");
            this.StartWaveButton.Name = "StartWaveButton";
            this.StartWaveButton.TabStop = false;
            this.StartWaveButton.UseVisualStyleBackColor = true;
            // 
            // VoltRangComboBox
            // 
            this.VoltRangComboBox.FormattingEnabled = true;
            this.VoltRangComboBox.Items.AddRange(new object[] {
            resources.GetString("VoltRangComboBox.Items"),
            resources.GetString("VoltRangComboBox.Items1"),
            resources.GetString("VoltRangComboBox.Items2"),
            resources.GetString("VoltRangComboBox.Items3"),
            resources.GetString("VoltRangComboBox.Items4"),
            resources.GetString("VoltRangComboBox.Items5"),
            resources.GetString("VoltRangComboBox.Items6"),
            resources.GetString("VoltRangComboBox.Items7"),
            resources.GetString("VoltRangComboBox.Items8"),
            resources.GetString("VoltRangComboBox.Items9"),
            resources.GetString("VoltRangComboBox.Items10")});
            resources.ApplyResources(this.VoltRangComboBox, "VoltRangComboBox");
            this.VoltRangComboBox.Name = "VoltRangComboBox";
            // 
            // FreqMaxComboBox
            // 
            this.FreqMaxComboBox.FormattingEnabled = true;
            this.FreqMaxComboBox.Items.AddRange(new object[] {
            resources.GetString("FreqMaxComboBox.Items"),
            resources.GetString("FreqMaxComboBox.Items1"),
            resources.GetString("FreqMaxComboBox.Items2"),
            resources.GetString("FreqMaxComboBox.Items3"),
            resources.GetString("FreqMaxComboBox.Items4"),
            resources.GetString("FreqMaxComboBox.Items5"),
            resources.GetString("FreqMaxComboBox.Items6"),
            resources.GetString("FreqMaxComboBox.Items7"),
            resources.GetString("FreqMaxComboBox.Items8"),
            resources.GetString("FreqMaxComboBox.Items9"),
            resources.GetString("FreqMaxComboBox.Items10"),
            resources.GetString("FreqMaxComboBox.Items11"),
            resources.GetString("FreqMaxComboBox.Items12"),
            resources.GetString("FreqMaxComboBox.Items13"),
            resources.GetString("FreqMaxComboBox.Items14"),
            resources.GetString("FreqMaxComboBox.Items15")});
            resources.ApplyResources(this.FreqMaxComboBox, "FreqMaxComboBox");
            this.FreqMaxComboBox.Name = "FreqMaxComboBox";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // FftComboBox
            // 
            this.FftComboBox.FormattingEnabled = true;
            this.FftComboBox.Items.AddRange(new object[] {
            resources.GetString("FftComboBox.Items"),
            resources.GetString("FftComboBox.Items1"),
            resources.GetString("FftComboBox.Items2"),
            resources.GetString("FftComboBox.Items3")});
            resources.ApplyResources(this.FftComboBox, "FftComboBox");
            this.FftComboBox.Name = "FftComboBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // NoAvButton
            // 
            resources.ApplyResources(this.NoAvButton, "NoAvButton");
            this.NoAvButton.Checked = true;
            this.NoAvButton.Name = "NoAvButton";
            this.NoAvButton.TabStop = true;
            this.NoAvButton.UseVisualStyleBackColor = true;
            // 
            // ContAvButton
            // 
            resources.ApplyResources(this.ContAvButton, "ContAvButton");
            this.ContAvButton.Name = "ContAvButton";
            this.ContAvButton.UseVisualStyleBackColor = true;
            // 
            // MovAvButton
            // 
            resources.ApplyResources(this.MovAvButton, "MovAvButton");
            this.MovAvButton.Name = "MovAvButton";
            this.MovAvButton.UseVisualStyleBackColor = true;
            // 
            // stopFreqPiezoTextBox
            // 
            resources.ApplyResources(this.stopFreqPiezoTextBox, "stopFreqPiezoTextBox");
            this.stopFreqPiezoTextBox.Name = "stopFreqPiezoTextBox";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // PiezoButton
            // 
            resources.ApplyResources(this.PiezoButton, "PiezoButton");
            this.PiezoButton.Name = "PiezoButton";
            this.PiezoButton.TabStop = false;
            this.PiezoButton.UseVisualStyleBackColor = true;
            // 
            // startFreqPiezoTextBox
            // 
            resources.ApplyResources(this.startFreqPiezoTextBox, "startFreqPiezoTextBox");
            this.startFreqPiezoTextBox.Name = "startFreqPiezoTextBox";
            // 
            // InterGuessTextBox
            // 
            resources.ApplyResources(this.InterGuessTextBox, "InterGuessTextBox");
            this.InterGuessTextBox.Name = "InterGuessTextBox";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // AmpGuessTextBox
            // 
            resources.ApplyResources(this.AmpGuessTextBox, "AmpGuessTextBox");
            this.AmpGuessTextBox.Name = "AmpGuessTextBox";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // StopViewingButton
            // 
            this.StopViewingButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.StopViewingButton, "StopViewingButton");
            this.StopViewingButton.Name = "StopViewingButton";
            this.StopViewingButton.UseVisualStyleBackColor = true;
            // 
            // MovAvTextBox
            // 
            resources.ApplyResources(this.MovAvTextBox, "MovAvTextBox");
            this.MovAvTextBox.Name = "MovAvTextBox";
            // 
            // peakGuessCheckBox
            // 
            resources.ApplyResources(this.peakGuessCheckBox, "peakGuessCheckBox");
            this.peakGuessCheckBox.Name = "peakGuessCheckBox";
            this.peakGuessCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartVideoButton
            // 
            resources.ApplyResources(this.StartVideoButton, "StartVideoButton");
            this.StartVideoButton.Name = "StartVideoButton";
            this.StartVideoButton.UseVisualStyleBackColor = true;
            // 
            // CamComboBox
            // 
            this.CamComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.CamComboBox, "CamComboBox");
            this.CamComboBox.Name = "CamComboBox";
            // 
            // FftChart
            // 
            chartArea2.Name = "ChartArea1";
            this.FftChart.ChartAreas.Add(chartArea2);
            resources.ApplyResources(this.FftChart, "FftChart");
            this.FftChart.Name = "FftChart";
            this.FftChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Black;
            series2.Name = "Series1";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.LabelForeColor = System.Drawing.Color.Bisque;
            series3.Name = "Series2";
            this.FftChart.Series.Add(series2);
            this.FftChart.Series.Add(series3);
            // 
            // WaveFormChart
            // 
            chartArea3.Name = "ChartArea1";
            this.WaveFormChart.ChartAreas.Add(chartArea3);
            resources.ApplyResources(this.WaveFormChart, "WaveFormChart");
            this.WaveFormChart.Name = "WaveFormChart";
            this.WaveFormChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Black;
            series4.Name = "Series1";
            this.WaveFormChart.Series.Add(series4);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // CamPictureBox
            // 
            this.CamPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.CamPictureBox, "CamPictureBox");
            this.CamPictureBox.Name = "CamPictureBox";
            this.CamPictureBox.TabStop = false;
            // 
            // MidFreqGuessTextBox
            // 
            resources.ApplyResources(this.MidFreqGuessTextBox, "MidFreqGuessTextBox");
            this.MidFreqGuessTextBox.Name = "MidFreqGuessTextBox";
            // 
            // IterTextBox
            // 
            resources.ApplyResources(this.IterTextBox, "IterTextBox");
            this.IterTextBox.Name = "IterTextBox";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // StartExportButton
            // 
            resources.ApplyResources(this.StartExportButton, "StartExportButton");
            this.StartExportButton.Name = "StartExportButton";
            this.StartExportButton.TabStop = false;
            this.StartExportButton.UseVisualStyleBackColor = true;
            // 
            // btnFreqStop
            // 
            resources.ApplyResources(this.btnFreqStop, "btnFreqStop");
            this.btnFreqStop.Name = "btnFreqStop";
            this.btnFreqStop.TabStop = false;
            this.btnFreqStop.UseVisualStyleBackColor = true;
            // 
            // fixedGroup
            // 
            this.fixedGroup.Controls.Add(this.FixedFreqPiezoTextBox);
            this.fixedGroup.Controls.Add(this.label40);
            resources.ApplyResources(this.fixedGroup, "fixedGroup");
            this.fixedGroup.Name = "fixedGroup";
            // 
            // FixedFreqPiezoTextBox
            // 
            resources.ApplyResources(this.FixedFreqPiezoTextBox, "FixedFreqPiezoTextBox");
            this.FixedFreqPiezoTextBox.Name = "FixedFreqPiezoTextBox";
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // fileNamePrefixTextBox
            // 
            resources.ApplyResources(this.fileNamePrefixTextBox, "fileNamePrefixTextBox");
            this.fileNamePrefixTextBox.Name = "fileNamePrefixTextBox";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // DeflectionCheckBox
            // 
            resources.ApplyResources(this.DeflectionCheckBox, "DeflectionCheckBox");
            this.DeflectionCheckBox.Name = "DeflectionCheckBox";
            this.DeflectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // PeakTrackCheckBox
            // 
            resources.ApplyResources(this.PeakTrackCheckBox, "PeakTrackCheckBox");
            this.PeakTrackCheckBox.Name = "PeakTrackCheckBox";
            this.PeakTrackCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fileNamePrefixTextBox);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.DeflectionCheckBox);
            this.groupBox4.Controls.Add(this.PeakTrackCheckBox);
            this.groupBox4.Controls.Add(this.ExportSnapShotButton);
            this.groupBox4.Controls.Add(this.LorentzCheckBox);
            this.groupBox4.Controls.Add(this.ExportRateTextBox);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.FreqExportCheckBox);
            this.groupBox4.Controls.Add(this.WaveFormExportCheckBox);
            this.groupBox4.Controls.Add(this.StopExportButton);
            this.groupBox4.Controls.Add(this.StartExportButton);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // ExportSnapShotButton
            // 
            resources.ApplyResources(this.ExportSnapShotButton, "ExportSnapShotButton");
            this.ExportSnapShotButton.Name = "ExportSnapShotButton";
            this.ExportSnapShotButton.TabStop = false;
            this.ExportSnapShotButton.UseVisualStyleBackColor = true;
            // 
            // LorentzCheckBox
            // 
            resources.ApplyResources(this.LorentzCheckBox, "LorentzCheckBox");
            this.LorentzCheckBox.Name = "LorentzCheckBox";
            this.LorentzCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExportRateTextBox
            // 
            resources.ApplyResources(this.ExportRateTextBox, "ExportRateTextBox");
            this.ExportRateTextBox.Name = "ExportRateTextBox";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // FreqExportCheckBox
            // 
            resources.ApplyResources(this.FreqExportCheckBox, "FreqExportCheckBox");
            this.FreqExportCheckBox.Name = "FreqExportCheckBox";
            this.FreqExportCheckBox.UseVisualStyleBackColor = true;
            // 
            // WaveFormExportCheckBox
            // 
            resources.ApplyResources(this.WaveFormExportCheckBox, "WaveFormExportCheckBox");
            this.WaveFormExportCheckBox.Name = "WaveFormExportCheckBox";
            this.WaveFormExportCheckBox.UseVisualStyleBackColor = true;
            // 
            // StopExportButton
            // 
            resources.ApplyResources(this.StopExportButton, "StopExportButton");
            this.StopExportButton.Name = "StopExportButton";
            this.StopExportButton.TabStop = false;
            this.StopExportButton.UseVisualStyleBackColor = true;
            // 
            // radioButtonFixed
            // 
            resources.ApplyResources(this.radioButtonFixed, "radioButtonFixed");
            this.radioButtonFixed.Name = "radioButtonFixed";
            this.radioButtonFixed.UseVisualStyleBackColor = true;
            // 
            // radioButtonSweep
            // 
            resources.ApplyResources(this.radioButtonSweep, "radioButtonSweep");
            this.radioButtonSweep.Checked = true;
            this.radioButtonSweep.Name = "radioButtonSweep";
            this.radioButtonSweep.TabStop = true;
            this.radioButtonSweep.UseVisualStyleBackColor = true;
            // 
            // sweepGroup
            // 
            this.sweepGroup.Controls.Add(this.nudTime);
            this.sweepGroup.Controls.Add(this.label39);
            this.sweepGroup.Controls.Add(this.startFreqPiezoTextBox);
            this.sweepGroup.Controls.Add(this.stopFreqPiezoTextBox);
            this.sweepGroup.Controls.Add(this.label8);
            this.sweepGroup.Controls.Add(this.label11);
            resources.ApplyResources(this.sweepGroup, "sweepGroup");
            this.sweepGroup.Name = "sweepGroup";
            // 
            // btnRefreshPorts
            // 
            resources.ApplyResources(this.btnRefreshPorts, "btnRefreshPorts");
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            // 
            // btnDisconnectPort
            // 
            resources.ApplyResources(this.btnDisconnectPort, "btnDisconnectPort");
            this.btnDisconnectPort.Name = "btnDisconnectPort";
            this.btnDisconnectPort.UseVisualStyleBackColor = true;
            // 
            // btnConnectPort
            // 
            resources.ApplyResources(this.btnConnectPort, "btnConnectPort");
            this.btnConnectPort.Name = "btnConnectPort";
            this.btnConnectPort.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            resources.ApplyResources(this.cbPorts, "cbPorts");
            this.cbPorts.Name = "cbPorts";
            // 
            // peakTrackerChart
            // 
            chartArea4.Name = "ChartArea1";
            this.peakTrackerChart.ChartAreas.Add(chartArea4);
            resources.ApplyResources(this.peakTrackerChart, "peakTrackerChart");
            this.peakTrackerChart.Name = "peakTrackerChart";
            this.peakTrackerChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Black;
            series5.Name = "Series1";
            this.peakTrackerChart.Series.Add(series5);
            title1.Name = "Peak Tracker";
            title1.Position.Auto = false;
            title1.Position.Height = 5.516974F;
            title1.Position.Width = 70F;
            title1.Position.X = 15F;
            title1.Position.Y = 45F;
            title1.Text = "Peak Tracker";
            this.peakTrackerChart.Titles.Add(title1);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // YShiftCheckBox
            // 
            resources.ApplyResources(this.YShiftCheckBox, "YShiftCheckBox");
            this.YShiftCheckBox.Name = "YShiftCheckBox";
            this.YShiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // trimStartFreqTextBox
            // 
            resources.ApplyResources(this.trimStartFreqTextBox, "trimStartFreqTextBox");
            this.trimStartFreqTextBox.Name = "trimStartFreqTextBox";
            // 
            // TrimFftCheckBox
            // 
            resources.ApplyResources(this.TrimFftCheckBox, "TrimFftCheckBox");
            this.TrimFftCheckBox.Name = "TrimFftCheckBox";
            this.TrimFftCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoAvButton);
            this.groupBox1.Controls.Add(this.ContAvButton);
            this.groupBox1.Controls.Add(this.MovAvButton);
            this.groupBox1.Controls.Add(this.MovAvTextBox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // trimStopFreqTextBox
            // 
            resources.ApplyResources(this.trimStopFreqTextBox, "trimStopFreqTextBox");
            this.trimStopFreqTextBox.Name = "trimStopFreqTextBox";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.InterGuessTextBox);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.AmpGuessTextBox);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.MidFreqGuessTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.peakGuessCheckBox);
            this.groupBox3.Controls.Add(this.IterTextBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.trimStartFreqTextBox);
            this.groupBox3.Controls.Add(this.YShiftCheckBox);
            this.groupBox3.Controls.Add(this.TrimFftCheckBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.trimStopFreqTextBox);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFreqStop);
            this.groupBox2.Controls.Add(this.fixedGroup);
            this.groupBox2.Controls.Add(this.radioButtonFixed);
            this.groupBox2.Controls.Add(this.radioButtonSweep);
            this.groupBox2.Controls.Add(this.sweepGroup);
            this.groupBox2.Controls.Add(this.btnRefreshPorts);
            this.groupBox2.Controls.Add(this.btnDisconnectPort);
            this.groupBox2.Controls.Add(this.btnConnectPort);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.cbPorts);
            this.groupBox2.Controls.Add(this.PiezoButton);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // ExportTimer
            // 
            this.ExportTimer.Interval = 60000;
            // 
            // LorentzTimer
            // 
            this.LorentzTimer.Interval = 1000;
            // 
            // PM2gui
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Name = "PM2gui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PM2gui_FormClosing);
            this.Load += new System.EventHandler(this.PM2gui_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChanelBWave)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FftChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WaveFormChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).EndInit();
            this.fixedGroup.ResumeLayout(false);
            this.fixedGroup.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.sweepGroup.ResumeLayout(false);
            this.sweepGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakTrackerChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox10;
        private Label FftTimeLabel;
        private Label FreqDomainPlottingTimeLabel;
        private Label ArduinoComTimeLabel;
        private Label CameraViewingTimeLabel;
        private Label LorentzianFittingTimeLabel;
        private Label TimeDomainPlottingTimeLabel;
        private Label DataSamplingTimeLabel;
        private GroupBox groupBox8;
        private Button StartPeakTrackButton;
        private Button StopPeakTrackButton;
        private GroupBox groupBox11;
        private Button btnStopChanelB;
        private Button btnStartChanelB;
        private Label label26;
        private TextBox tbChanelBRefreshRate;
        private GroupBox groupBox7;
        private Label FittingRefreshRateTextBox;
        private TextBox LorentzRefreshRateTextBox;
        private Label QLabel;
        private Label amplitudeLabel;
        private Button LorentzStartButton;
        private Label f2Label;
        private Button LorentzStopButton;
        private Label f1Label;
        private Label f0Label;
        private Label label17;
        private Label label16;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnPressureStop;
        private Label label38;
        private Label label37;
        private Label label36;
        private Label label35;
        private Label label34;
        private Label label33;
        private Label label32;
        private Label label31;
        private Button btnPressure;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label22;
        private Label label21;
        private Label label15;
        private Label label14;
        private Label label13;
        private TextBox BR;
        private TextBox textBoxBR;
        private TextBox textBox5;
        private TextBox textBoxBL;
        private TextBox textBox1;
        private TextBox textBoxTL;
        private TextBox textBox3;
        private TextBox textBoxTR;
        private TrackBar trackBarBL;
        private TrackBar trackBarBR;
        private TrackBar trackBarTL;
        private PictureBox pictureBox1;
        private TrackBar trackBarTR;
        public System.Windows.Forms.DataVisualization.Charting.Chart ChanelBWave;
        private GroupBox groupBox6;
        private ComboBox BufferSizeComboBox;
        private Label label23;
        private CheckBox EqualizeRefreshRateCheckBox;
        private Label label20;
        private TextBox ReadingRefreshRateTextBox;
        private Label label19;
        private Button StopWaveButton;
        private Button StartWaveButton;
        private ComboBox VoltRangComboBox;
        private ComboBox FreqMaxComboBox;
        private Label label6;
        private ComboBox FftComboBox;
        private Label label7;
        private Button StopViewingButton;
        private Button StartVideoButton;
        private ComboBox CamComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart FftChart;
        public System.Windows.Forms.DataVisualization.Charting.Chart WaveFormChart;
        private PictureBox CamPictureBox;
        private GroupBox groupBox4;
        private TextBox fileNamePrefixTextBox;
        private Label label18;
        private CheckBox DeflectionCheckBox;
        private CheckBox PeakTrackCheckBox;
        private Button ExportSnapShotButton;
        private CheckBox LorentzCheckBox;
        private TextBox ExportRateTextBox;
        private Label label12;
        private CheckBox FreqExportCheckBox;
        private CheckBox WaveFormExportCheckBox;
        private Button StopExportButton;
        private Button StartExportButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart peakTrackerChart;
        private GroupBox groupBox3;
        private TextBox InterGuessTextBox;
        private Label label25;
        private TextBox AmpGuessTextBox;
        private Label label24;
        private TextBox MidFreqGuessTextBox;
        private Label label4;
        private CheckBox peakGuessCheckBox;
        private TextBox IterTextBox;
        private Label label9;
        private Label label5;
        private TextBox trimStartFreqTextBox;
        private CheckBox YShiftCheckBox;
        private CheckBox TrimFftCheckBox;
        private Label label10;
        private GroupBox groupBox1;
        private RadioButton NoAvButton;
        private RadioButton ContAvButton;
        private RadioButton MovAvButton;
        private TextBox MovAvTextBox;
        private TextBox trimStopFreqTextBox;
        private GroupBox groupBox2;
        private Button btnFreqStop;
        private Panel fixedGroup;
        private MaskedTextBox FixedFreqPiezoTextBox;
        private Label label40;
        private RadioButton radioButtonFixed;
        private RadioButton radioButtonSweep;
        private Panel sweepGroup;
        private NumericUpDown nudTime;
        private Label label39;
        private MaskedTextBox startFreqPiezoTextBox;
        private MaskedTextBox stopFreqPiezoTextBox;
        private Label label8;
        private Label label11;
        private Button btnRefreshPorts;
        private Button btnDisconnectPort;
        private Button btnConnectPort;
        private Label label30;
        private ComboBox cbPorts;
        private Button PiezoButton;
        private TabPage tabPage2;
        private Timer ChanelBTimer;
        private Timer ExportTimer;
        private Timer WaveFormTimer;
        private Timer LorentzTimer;
    }
}

