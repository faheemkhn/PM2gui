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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.StartWaveButton = new System.Windows.Forms.Button();
            this.StopWaveButton = new System.Windows.Forms.Button();
            this.WaveFormTimer = new System.Windows.Forms.Timer(this.components);
            this.shortTimeDomainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.freqDomainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CamPictureBox = new System.Windows.Forms.PictureBox();
            this.CamComboBox = new System.Windows.Forms.ComboBox();
            this.StartVideoButton = new System.Windows.Forms.Button();
            this.StopViewingButton = new System.Windows.Forms.Button();
            this.LorentzTimer = new System.Windows.Forms.Timer(this.components);
            this.LorentzStopButton = new System.Windows.Forms.Button();
            this.LorentzStartButton = new System.Windows.Forms.Button();
            this.MovAvTextBox = new System.Windows.Forms.TextBox();
            this.FftComboBox = new System.Windows.Forms.ComboBox();
            this.VoltRangComboBox = new System.Windows.Forms.ComboBox();
            this.FreqMaxComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.startFreqPiezoTextBox = new System.Windows.Forms.MaskedTextBox();
            this.PiezoButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.YShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.stopFreqPiezoTextBox = new System.Windows.Forms.MaskedTextBox();
            this.trimStartFreqTextBox = new System.Windows.Forms.TextBox();
            this.trimStopFreqTextBox = new System.Windows.Forms.TextBox();
            this.TrimFftCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoAvButton = new System.Windows.Forms.RadioButton();
            this.ContAvButton = new System.Windows.Forms.RadioButton();
            this.MovAvButton = new System.Windows.Forms.RadioButton();
            this.IterTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.longTimeDomainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.peakTrackerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PeakGuessTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.peakGuessCheckBox = new System.Windows.Forms.CheckBox();
            this.StartExportButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fileNamePrefixTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.DeflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.PeakTrackCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportSnapShotButton = new System.Windows.Forms.Button();
            this.LorentzCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportRateTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.FreqExportCheckBox = new System.Windows.Forms.CheckBox();
            this.ShortTimeExportCheckBox = new System.Windows.Forms.CheckBox();
            this.StopExportButton = new System.Windows.Forms.Button();
            this.ExportTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.QLabel = new System.Windows.Forms.Label();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.f2Label = new System.Windows.Forms.Label();
            this.f1Label = new System.Windows.Forms.Label();
            this.f0Label = new System.Windows.Forms.Label();
            this.StartPeakTrackButton = new System.Windows.Forms.Button();
            this.StopPeakTrackButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.StartLongTimeButton = new System.Windows.Forms.Button();
            this.StopLongTimeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ReadingRefreshRateTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.FittingRefreshRateTextBox = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.IsDataPulseCheckBox = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.PulseFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.BackAvPeriodTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.shortTimeDomainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqDomainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longTimeDomainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peakTrackerChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartWaveButton
            // 
            resources.ApplyResources(this.StartWaveButton, "StartWaveButton");
            this.StartWaveButton.Name = "StartWaveButton";
            this.StartWaveButton.TabStop = false;
            this.StartWaveButton.UseVisualStyleBackColor = true;
            this.StartWaveButton.Click += new System.EventHandler(this.StartWaveButton_Click);
            // 
            // StopWaveButton
            // 
            resources.ApplyResources(this.StopWaveButton, "StopWaveButton");
            this.StopWaveButton.Name = "StopWaveButton";
            this.StopWaveButton.TabStop = false;
            this.StopWaveButton.UseVisualStyleBackColor = true;
            this.StopWaveButton.Click += new System.EventHandler(this.StopWaveButton_Click);
            // 
            // WaveFormTimer
            // 
            this.WaveFormTimer.Tick += new System.EventHandler(this.WaveFormTimer_Tick);
            // 
            // shortTimeDomainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.shortTimeDomainChart.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.shortTimeDomainChart, "shortTimeDomainChart");
            this.shortTimeDomainChart.Name = "shortTimeDomainChart";
            this.shortTimeDomainChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Black;
            series1.Name = "Series1";
            this.shortTimeDomainChart.Series.Add(series1);
            // 
            // freqDomainChart
            // 
            chartArea2.Name = "ChartArea1";
            this.freqDomainChart.ChartAreas.Add(chartArea2);
            resources.ApplyResources(this.freqDomainChart, "freqDomainChart");
            this.freqDomainChart.Name = "freqDomainChart";
            this.freqDomainChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Black;
            series2.Name = "Series1";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.LabelForeColor = System.Drawing.Color.Bisque;
            series3.Name = "Series2";
            this.freqDomainChart.Series.Add(series2);
            this.freqDomainChart.Series.Add(series3);
            // 
            // CamPictureBox
            // 
            this.CamPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.CamPictureBox, "CamPictureBox");
            this.CamPictureBox.Name = "CamPictureBox";
            this.CamPictureBox.TabStop = false;
            // 
            // CamComboBox
            // 
            this.CamComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.CamComboBox, "CamComboBox");
            this.CamComboBox.Name = "CamComboBox";
            // 
            // StartVideoButton
            // 
            resources.ApplyResources(this.StartVideoButton, "StartVideoButton");
            this.StartVideoButton.Name = "StartVideoButton";
            this.StartVideoButton.UseVisualStyleBackColor = true;
            this.StartVideoButton.Click += new System.EventHandler(this.StartVideoButton_Click);
            // 
            // StopViewingButton
            // 
            this.StopViewingButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.StopViewingButton, "StopViewingButton");
            this.StopViewingButton.Name = "StopViewingButton";
            this.StopViewingButton.UseVisualStyleBackColor = true;
            this.StopViewingButton.Click += new System.EventHandler(this.StopViewingButton_Click);
            // 
            // LorentzTimer
            // 
            this.LorentzTimer.Interval = 1000;
            this.LorentzTimer.Tick += new System.EventHandler(this.LorentzTimer_Tick);
            // 
            // LorentzStopButton
            // 
            resources.ApplyResources(this.LorentzStopButton, "LorentzStopButton");
            this.LorentzStopButton.Name = "LorentzStopButton";
            this.LorentzStopButton.TabStop = false;
            this.LorentzStopButton.UseVisualStyleBackColor = true;
            this.LorentzStopButton.Click += new System.EventHandler(this.LorentzStopButton_Click);
            // 
            // LorentzStartButton
            // 
            resources.ApplyResources(this.LorentzStartButton, "LorentzStartButton");
            this.LorentzStartButton.Name = "LorentzStartButton";
            this.LorentzStartButton.TabStop = false;
            this.LorentzStartButton.UseVisualStyleBackColor = true;
            this.LorentzStartButton.Click += new System.EventHandler(this.LorentzStartButton_Click);
            // 
            // MovAvTextBox
            // 
            resources.ApplyResources(this.MovAvTextBox, "MovAvTextBox");
            this.MovAvTextBox.Name = "MovAvTextBox";
            this.MovAvTextBox.TextChanged += new System.EventHandler(this.MovAvTextBox_TextChanged);
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
            this.FftComboBox.SelectedIndexChanged += new System.EventHandler(this.FftComboBox_SelectedIndexChanged);
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
            this.VoltRangComboBox.SelectedIndexChanged += new System.EventHandler(this.VoltRangComboBox_SelectedIndexChanged);
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
            resources.GetString("FreqMaxComboBox.Items15"),
            resources.GetString("FreqMaxComboBox.Items16")});
            resources.ApplyResources(this.FreqMaxComboBox, "FreqMaxComboBox");
            this.FreqMaxComboBox.Name = "FreqMaxComboBox";
            this.FreqMaxComboBox.SelectedIndexChanged += new System.EventHandler(this.FreqMaxComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // startFreqPiezoTextBox
            // 
            resources.ApplyResources(this.startFreqPiezoTextBox, "startFreqPiezoTextBox");
            this.startFreqPiezoTextBox.Name = "startFreqPiezoTextBox";
            // 
            // PiezoButton
            // 
            resources.ApplyResources(this.PiezoButton, "PiezoButton");
            this.PiezoButton.Name = "PiezoButton";
            this.PiezoButton.TabStop = false;
            this.PiezoButton.UseVisualStyleBackColor = true;
            this.PiezoButton.Click += new System.EventHandler(this.PiezoButton_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // YShiftCheckBox
            // 
            resources.ApplyResources(this.YShiftCheckBox, "YShiftCheckBox");
            this.YShiftCheckBox.Name = "YShiftCheckBox";
            this.YShiftCheckBox.UseVisualStyleBackColor = true;
            this.YShiftCheckBox.CheckedChanged += new System.EventHandler(this.YShiftCheckBox_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // stopFreqPiezoTextBox
            // 
            resources.ApplyResources(this.stopFreqPiezoTextBox, "stopFreqPiezoTextBox");
            this.stopFreqPiezoTextBox.Name = "stopFreqPiezoTextBox";
            // 
            // trimStartFreqTextBox
            // 
            resources.ApplyResources(this.trimStartFreqTextBox, "trimStartFreqTextBox");
            this.trimStartFreqTextBox.Name = "trimStartFreqTextBox";
            // 
            // trimStopFreqTextBox
            // 
            resources.ApplyResources(this.trimStopFreqTextBox, "trimStopFreqTextBox");
            this.trimStopFreqTextBox.Name = "trimStopFreqTextBox";
            // 
            // TrimFftCheckBox
            // 
            resources.ApplyResources(this.TrimFftCheckBox, "TrimFftCheckBox");
            this.TrimFftCheckBox.Name = "TrimFftCheckBox";
            this.TrimFftCheckBox.UseVisualStyleBackColor = true;
            this.TrimFftCheckBox.CheckedChanged += new System.EventHandler(this.TrimFftCheckBox_CheckedChanged);
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
            this.ContAvButton.CheckedChanged += new System.EventHandler(this.ContAvButton_CheckedChanged_1);
            // 
            // MovAvButton
            // 
            resources.ApplyResources(this.MovAvButton, "MovAvButton");
            this.MovAvButton.Name = "MovAvButton";
            this.MovAvButton.UseVisualStyleBackColor = true;
            this.MovAvButton.CheckedChanged += new System.EventHandler(this.MovAvButton_CheckedChanged_1);
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
            // longTimeDomainChart
            // 
            chartArea3.Name = "ChartArea1";
            this.longTimeDomainChart.ChartAreas.Add(chartArea3);
            resources.ApplyResources(this.longTimeDomainChart, "longTimeDomainChart");
            this.longTimeDomainChart.Name = "longTimeDomainChart";
            this.longTimeDomainChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Black;
            series4.Name = "Series1";
            this.longTimeDomainChart.Series.Add(series4);
            title1.Name = "Title1";
            title1.Position.Auto = false;
            title1.Position.Height = 5.516974F;
            title1.Position.Width = 85F;
            title1.Position.X = 8F;
            title1.Position.Y = 45F;
            title1.Text = "Long Time Domain";
            this.longTimeDomainChart.Titles.Add(title1);
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
            title2.Name = "Peak Tracker";
            title2.Position.Auto = false;
            title2.Position.Height = 5.516974F;
            title2.Position.Width = 70F;
            title2.Position.X = 15F;
            title2.Position.Y = 45F;
            title2.Text = "Peak Tracker";
            this.peakTrackerChart.Titles.Add(title2);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stopFreqPiezoTextBox);
            this.groupBox2.Controls.Add(this.startFreqPiezoTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.PiezoButton);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PeakGuessTextBox);
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
            // PeakGuessTextBox
            // 
            resources.ApplyResources(this.PeakGuessTextBox, "PeakGuessTextBox");
            this.PeakGuessTextBox.Name = "PeakGuessTextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // peakGuessCheckBox
            // 
            resources.ApplyResources(this.peakGuessCheckBox, "peakGuessCheckBox");
            this.peakGuessCheckBox.Name = "peakGuessCheckBox";
            this.peakGuessCheckBox.UseVisualStyleBackColor = true;
            this.peakGuessCheckBox.CheckedChanged += new System.EventHandler(this.peakGuessCheckBox_CheckedChanged);
            // 
            // StartExportButton
            // 
            resources.ApplyResources(this.StartExportButton, "StartExportButton");
            this.StartExportButton.Name = "StartExportButton";
            this.StartExportButton.TabStop = false;
            this.StartExportButton.UseVisualStyleBackColor = true;
            this.StartExportButton.Click += new System.EventHandler(this.StartExportButton_Click);
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
            this.groupBox4.Controls.Add(this.ShortTimeExportCheckBox);
            this.groupBox4.Controls.Add(this.StopExportButton);
            this.groupBox4.Controls.Add(this.StartExportButton);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
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
            this.ExportRateTextBox.TextChanged += new System.EventHandler(this.ExportRateTextBox_TextChanged);
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
            // ShortTimeExportCheckBox
            // 
            resources.ApplyResources(this.ShortTimeExportCheckBox, "ShortTimeExportCheckBox");
            this.ShortTimeExportCheckBox.Name = "ShortTimeExportCheckBox";
            this.ShortTimeExportCheckBox.UseVisualStyleBackColor = true;
            // 
            // StopExportButton
            // 
            resources.ApplyResources(this.StopExportButton, "StopExportButton");
            this.StopExportButton.Name = "StopExportButton";
            this.StopExportButton.TabStop = false;
            this.StopExportButton.UseVisualStyleBackColor = true;
            this.StopExportButton.Click += new System.EventHandler(this.StopExportButton_Click);
            // 
            // ExportTimer
            // 
            this.ExportTimer.Interval = 60000;
            this.ExportTimer.Tick += new System.EventHandler(this.ExportTimer_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.radioButton3);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
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
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.FittingRefreshRateTextBox);
            this.groupBox7.Controls.Add(this.textBox5);
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
            // f0Label
            // 
            resources.ApplyResources(this.f0Label, "f0Label");
            this.f0Label.Name = "f0Label";
            // 
            // StartPeakTrackButton
            // 
            resources.ApplyResources(this.StartPeakTrackButton, "StartPeakTrackButton");
            this.StartPeakTrackButton.Name = "StartPeakTrackButton";
            this.StartPeakTrackButton.TabStop = false;
            this.StartPeakTrackButton.UseVisualStyleBackColor = true;
            // 
            // StopPeakTrackButton
            // 
            resources.ApplyResources(this.StopPeakTrackButton, "StopPeakTrackButton");
            this.StopPeakTrackButton.Name = "StopPeakTrackButton";
            this.StopPeakTrackButton.TabStop = false;
            this.StopPeakTrackButton.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.StartPeakTrackButton);
            this.groupBox8.Controls.Add(this.StopPeakTrackButton);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.BackAvPeriodTextBox);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.PulseFrequencyTextBox);
            this.groupBox9.Controls.Add(this.IsDataPulseCheckBox);
            this.groupBox9.Controls.Add(this.StartLongTimeButton);
            this.groupBox9.Controls.Add(this.StopLongTimeButton);
            resources.ApplyResources(this.groupBox9, "groupBox9");
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.TabStop = false;
            // 
            // StartLongTimeButton
            // 
            resources.ApplyResources(this.StartLongTimeButton, "StartLongTimeButton");
            this.StartLongTimeButton.Name = "StartLongTimeButton";
            this.StartLongTimeButton.TabStop = false;
            this.StartLongTimeButton.UseVisualStyleBackColor = true;
            // 
            // StopLongTimeButton
            // 
            resources.ApplyResources(this.StopLongTimeButton, "StopLongTimeButton");
            this.StopLongTimeButton.Name = "StopLongTimeButton";
            this.StopLongTimeButton.TabStop = false;
            this.StopLongTimeButton.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            resources.ApplyResources(this.chart1, "chart1");
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.Black;
            series6.Name = "Series1";
            this.chart1.Series.Add(series6);
            title3.Name = "Title1";
            title3.Position.Auto = false;
            title3.Position.Height = 5.516974F;
            title3.Position.Width = 85F;
            title3.Position.X = 8F;
            title3.Position.Y = 45F;
            title3.Text = "Long Time Domain";
            this.chart1.Titles.Add(title3);
            // 
            // ReadingRefreshRateTextBox
            // 
            resources.ApplyResources(this.ReadingRefreshRateTextBox, "ReadingRefreshRateTextBox");
            this.ReadingRefreshRateTextBox.Name = "ReadingRefreshRateTextBox";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // FittingRefreshRateTextBox
            // 
            resources.ApplyResources(this.FittingRefreshRateTextBox, "FittingRefreshRateTextBox");
            this.FittingRefreshRateTextBox.Name = "FittingRefreshRateTextBox";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // IsDataPulseCheckBox
            // 
            resources.ApplyResources(this.IsDataPulseCheckBox, "IsDataPulseCheckBox");
            this.IsDataPulseCheckBox.Name = "IsDataPulseCheckBox";
            this.IsDataPulseCheckBox.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // PulseFrequencyTextBox
            // 
            resources.ApplyResources(this.PulseFrequencyTextBox, "PulseFrequencyTextBox");
            this.PulseFrequencyTextBox.Name = "PulseFrequencyTextBox";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // BackAvPeriodTextBox
            // 
            resources.ApplyResources(this.BackAvPeriodTextBox, "BackAvPeriodTextBox");
            this.BackAvPeriodTextBox.Name = "BackAvPeriodTextBox";
            // 
            // PM2gui
            // 
            this.AcceptButton = this.StartWaveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.StopViewingButton;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.peakTrackerChart);
            this.Controls.Add(this.longTimeDomainChart);
            this.Controls.Add(this.StopViewingButton);
            this.Controls.Add(this.StartVideoButton);
            this.Controls.Add(this.CamComboBox);
            this.Controls.Add(this.CamPictureBox);
            this.Controls.Add(this.freqDomainChart);
            this.Controls.Add(this.shortTimeDomainChart);
            this.Name = "PM2gui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PM2gui_FormClosing);
            this.Load += new System.EventHandler(this.PM2gui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shortTimeDomainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqDomainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longTimeDomainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peakTrackerChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartWaveButton;
        private System.Windows.Forms.Button StopWaveButton;
        private System.Windows.Forms.Timer WaveFormTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart freqDomainChart;
        private System.Windows.Forms.PictureBox CamPictureBox;
        private System.Windows.Forms.ComboBox CamComboBox;
        private System.Windows.Forms.Button StartVideoButton;
        private System.Windows.Forms.Button StopViewingButton;
        private System.Windows.Forms.Timer LorentzTimer;
        private System.Windows.Forms.Button LorentzStopButton;
        private System.Windows.Forms.Button LorentzStartButton;
        private System.Windows.Forms.TextBox MovAvTextBox;
        private System.Windows.Forms.ComboBox FftComboBox;
        private System.Windows.Forms.ComboBox VoltRangComboBox;
        private System.Windows.Forms.ComboBox FreqMaxComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox startFreqPiezoTextBox;
        private System.Windows.Forms.Button PiezoButton;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataVisualization.Charting.Chart shortTimeDomainChart;
        private System.Windows.Forms.CheckBox YShiftCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox stopFreqPiezoTextBox;
        private System.Windows.Forms.TextBox trimStartFreqTextBox;
        private System.Windows.Forms.TextBox trimStopFreqTextBox;
        private System.Windows.Forms.CheckBox TrimFftCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton NoAvButton;
        private System.Windows.Forms.RadioButton ContAvButton;
        private System.Windows.Forms.RadioButton MovAvButton;
        private System.Windows.Forms.TextBox IterTextBox;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DataVisualization.Charting.Chart longTimeDomainChart;
        public System.Windows.Forms.DataVisualization.Charting.Chart peakTrackerChart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox PeakGuessTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox peakGuessCheckBox;
        private System.Windows.Forms.Button StartExportButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox ExportRateTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox FreqExportCheckBox;
        private System.Windows.Forms.CheckBox ShortTimeExportCheckBox;
        private System.Windows.Forms.Button StopExportButton;
        private System.Windows.Forms.Timer ExportTimer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label QLabel;
        private System.Windows.Forms.Label amplitudeLabel;
        private System.Windows.Forms.Label f2Label;
        private System.Windows.Forms.Label f1Label;
        private System.Windows.Forms.Label f0Label;
        private System.Windows.Forms.Button ExportSnapShotButton;
        private System.Windows.Forms.CheckBox LorentzCheckBox;
        private System.Windows.Forms.CheckBox DeflectionCheckBox;
        private System.Windows.Forms.CheckBox PeakTrackCheckBox;
        private System.Windows.Forms.TextBox fileNamePrefixTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button StartPeakTrackButton;
        private System.Windows.Forms.Button StopPeakTrackButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button StartLongTimeButton;
        private System.Windows.Forms.Button StopLongTimeButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox ReadingRefreshRateTextBox;
        private System.Windows.Forms.Label FittingRefreshRateTextBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox PulseFrequencyTextBox;
        private System.Windows.Forms.CheckBox IsDataPulseCheckBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox BackAvPeriodTextBox;
    }
}

