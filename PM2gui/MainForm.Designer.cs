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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StartWaveButton = new System.Windows.Forms.Button();
            this.StopWaveButton = new System.Windows.Forms.Button();
            this.WaveFormTimer = new System.Windows.Forms.Timer(this.components);
            this.pM2tD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pM2fD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CamPictureBox = new System.Windows.Forms.PictureBox();
            this.CamComboBox = new System.Windows.Forms.ComboBox();
            this.StartVideoButton = new System.Windows.Forms.Button();
            this.StopViewingButton = new System.Windows.Forms.Button();
            this.LorentzTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lpAlphaLabel = new System.Windows.Forms.Label();
            this.lpGam0Label = new System.Windows.Forms.Label();
            this.lpBetaLabel = new System.Windows.Forms.Label();
            this.LorentzStopButton = new System.Windows.Forms.Button();
            this.LorentzStartButton = new System.Windows.Forms.Button();
            this.MovAvTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.trimFFTCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MovAvButton = new System.Windows.Forms.RadioButton();
            this.ContAvButton = new System.Windows.Forms.RadioButton();
            this.NoAvButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pM2tD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pM2fD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartWaveButton
            // 
            this.StartWaveButton.Location = new System.Drawing.Point(29, 12);
            this.StartWaveButton.Name = "StartWaveButton";
            this.StartWaveButton.Size = new System.Drawing.Size(85, 30);
            this.StartWaveButton.TabIndex = 1;
            this.StartWaveButton.TabStop = false;
            this.StartWaveButton.Text = "Start Reading";
            this.StartWaveButton.UseVisualStyleBackColor = true;
            this.StartWaveButton.Click += new System.EventHandler(this.StartWaveButton_Click);
            // 
            // StopWaveButton
            // 
            this.StopWaveButton.Location = new System.Drawing.Point(29, 48);
            this.StopWaveButton.Name = "StopWaveButton";
            this.StopWaveButton.Size = new System.Drawing.Size(85, 30);
            this.StopWaveButton.TabIndex = 2;
            this.StopWaveButton.TabStop = false;
            this.StopWaveButton.Text = "Stop Reading";
            this.StopWaveButton.UseVisualStyleBackColor = true;
            this.StopWaveButton.Click += new System.EventHandler(this.StopWaveButton_Click);
            // 
            // WaveFormTimer
            // 
            this.WaveFormTimer.Tick += new System.EventHandler(this.WaveFormTimer_Tick);
            // 
            // pM2tD
            // 
            chartArea7.Name = "ChartArea1";
            this.pM2tD.ChartAreas.Add(chartArea7);
            this.pM2tD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pM2tD.Location = new System.Drawing.Point(170, 12);
            this.pM2tD.Name = "pM2tD";
            this.pM2tD.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Color = System.Drawing.Color.Black;
            series10.Name = "Series1";
            this.pM2tD.Series.Add(series10);
            this.pM2tD.Size = new System.Drawing.Size(534, 226);
            this.pM2tD.TabIndex = 4;
            this.pM2tD.Text = "chart2";
            // 
            // pM2fD
            // 
            chartArea8.Name = "ChartArea1";
            this.pM2fD.ChartAreas.Add(chartArea8);
            this.pM2fD.Location = new System.Drawing.Point(170, 262);
            this.pM2fD.Name = "pM2fD";
            this.pM2fD.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.Black;
            series11.Name = "Series1";
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.Red;
            series12.LabelForeColor = System.Drawing.Color.Bisque;
            series12.Name = "Series2";
            this.pM2fD.Series.Add(series11);
            this.pM2fD.Series.Add(series12);
            this.pM2fD.Size = new System.Drawing.Size(534, 226);
            this.pM2fD.TabIndex = 5;
            this.pM2fD.Text = "chart2";
            // 
            // CamPictureBox
            // 
            this.CamPictureBox.Location = new System.Drawing.Point(808, 71);
            this.CamPictureBox.Name = "CamPictureBox";
            this.CamPictureBox.Size = new System.Drawing.Size(409, 323);
            this.CamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CamPictureBox.TabIndex = 6;
            this.CamPictureBox.TabStop = false;
            // 
            // CamComboBox
            // 
            this.CamComboBox.FormattingEnabled = true;
            this.CamComboBox.Location = new System.Drawing.Point(808, 400);
            this.CamComboBox.Name = "CamComboBox";
            this.CamComboBox.Size = new System.Drawing.Size(121, 21);
            this.CamComboBox.TabIndex = 7;
            // 
            // StartVideoButton
            // 
            this.StartVideoButton.Location = new System.Drawing.Point(1035, 398);
            this.StartVideoButton.Name = "StartVideoButton";
            this.StartVideoButton.Size = new System.Drawing.Size(93, 23);
            this.StartVideoButton.TabIndex = 8;
            this.StartVideoButton.Text = "Start Viewing";
            this.StartVideoButton.UseVisualStyleBackColor = true;
            this.StartVideoButton.Click += new System.EventHandler(this.StartVideoButton_Click);
            // 
            // StopViewingButton
            // 
            this.StopViewingButton.Location = new System.Drawing.Point(1134, 398);
            this.StopViewingButton.Name = "StopViewingButton";
            this.StopViewingButton.Size = new System.Drawing.Size(83, 23);
            this.StopViewingButton.TabIndex = 9;
            this.StopViewingButton.Text = "Stop Viewing";
            this.StopViewingButton.UseVisualStyleBackColor = true;
            this.StopViewingButton.Click += new System.EventHandler(this.StopViewingButton_Click);
            // 
            // LorentzTimer
            // 
            this.LorentzTimer.Interval = 1000;
            this.LorentzTimer.Tick += new System.EventHandler(this.LorentzTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "alpha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 543);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "gam0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 565);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "beta";
            // 
            // lpAlphaLabel
            // 
            this.lpAlphaLabel.AutoSize = true;
            this.lpAlphaLabel.Location = new System.Drawing.Point(64, 521);
            this.lpAlphaLabel.Name = "lpAlphaLabel";
            this.lpAlphaLabel.Size = new System.Drawing.Size(19, 13);
            this.lpAlphaLabel.TabIndex = 14;
            this.lpAlphaLabel.Text = "00";
            // 
            // lpGam0Label
            // 
            this.lpGam0Label.AutoSize = true;
            this.lpGam0Label.Location = new System.Drawing.Point(65, 543);
            this.lpGam0Label.Name = "lpGam0Label";
            this.lpGam0Label.Size = new System.Drawing.Size(19, 13);
            this.lpGam0Label.TabIndex = 15;
            this.lpGam0Label.Text = "00";
            // 
            // lpBetaLabel
            // 
            this.lpBetaLabel.AutoSize = true;
            this.lpBetaLabel.Location = new System.Drawing.Point(64, 565);
            this.lpBetaLabel.Name = "lpBetaLabel";
            this.lpBetaLabel.Size = new System.Drawing.Size(19, 13);
            this.lpBetaLabel.TabIndex = 16;
            this.lpBetaLabel.Text = "00";
            // 
            // LorentzStopButton
            // 
            this.LorentzStopButton.Location = new System.Drawing.Point(29, 298);
            this.LorentzStopButton.Name = "LorentzStopButton";
            this.LorentzStopButton.Size = new System.Drawing.Size(85, 30);
            this.LorentzStopButton.TabIndex = 18;
            this.LorentzStopButton.TabStop = false;
            this.LorentzStopButton.Text = "Stop Fitting";
            this.LorentzStopButton.UseVisualStyleBackColor = true;
            this.LorentzStopButton.Click += new System.EventHandler(this.LorentzStopButton_Click);
            // 
            // LorentzStartButton
            // 
            this.LorentzStartButton.Location = new System.Drawing.Point(29, 262);
            this.LorentzStartButton.Name = "LorentzStartButton";
            this.LorentzStartButton.Size = new System.Drawing.Size(85, 30);
            this.LorentzStartButton.TabIndex = 17;
            this.LorentzStartButton.TabStop = false;
            this.LorentzStartButton.Text = "Start Fitting";
            this.LorentzStartButton.UseVisualStyleBackColor = true;
            this.LorentzStartButton.Click += new System.EventHandler(this.LorentzStartButton_Click);
            // 
            // MovAvTextBox
            // 
            this.MovAvTextBox.Location = new System.Drawing.Point(257, 15);
            this.MovAvTextBox.Name = "MovAvTextBox";
            this.MovAvTextBox.Size = new System.Drawing.Size(85, 20);
            this.MovAvTextBox.TabIndex = 21;
            this.MovAvTextBox.Text = "100";
            this.MovAvTextBox.TextChanged += new System.EventHandler(this.MovAvTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Number of Averages";
            // 
            // FftComboBox
            // 
            this.FftComboBox.FormattingEnabled = true;
            this.FftComboBox.Items.AddRange(new object[] {
            "Log",
            "Log - Complex Conjugate",
            "Magnitude",
            "Magnitude - Complex Conjugate"});
            this.FftComboBox.Location = new System.Drawing.Point(583, 494);
            this.FftComboBox.Name = "FftComboBox";
            this.FftComboBox.Size = new System.Drawing.Size(121, 21);
            this.FftComboBox.TabIndex = 23;
            this.FftComboBox.Text = "Log";
            this.FftComboBox.SelectedIndexChanged += new System.EventHandler(this.FftComboBox_SelectedIndexChanged);
            // 
            // VoltRangComboBox
            // 
            this.VoltRangComboBox.FormattingEnabled = true;
            this.VoltRangComboBox.Items.AddRange(new object[] {
            "10 mV",
            "20 mV",
            "50 mV",
            "100 mV",
            "200 mV",
            "500 mV",
            "1 V",
            "2 V",
            "5 V",
            "10 V",
            "20 V"});
            this.VoltRangComboBox.Location = new System.Drawing.Point(12, 180);
            this.VoltRangComboBox.Name = "VoltRangComboBox";
            this.VoltRangComboBox.Size = new System.Drawing.Size(121, 21);
            this.VoltRangComboBox.TabIndex = 29;
            this.VoltRangComboBox.SelectedIndexChanged += new System.EventHandler(this.VoltRangComboBox_SelectedIndexChanged);
            // 
            // FreqMaxComboBox
            // 
            this.FreqMaxComboBox.FormattingEnabled = true;
            this.FreqMaxComboBox.Items.AddRange(new object[] {
            "50 MHz (10 ns)",
            "25 MHz (20 ns)",
            "13 MHz (40 ns)",
            "6 MHz (80 ns)",
            "3 MHz (160 ns)",
            "1563 kHz (320 ns)",
            "781 kHz (640 ns)",
            "391 kHz (1280 ns)",
            "195 kHz (2560 ns)",
            "98 kHz (5120 ns)",
            "49 kHz (10 us)",
            "24 kHz (20 us)",
            "12 kHz (40 us)",
            "6104 Hz (81 us)",
            "3052 Hz (163 us)",
            "1526 Hz (327 us)",
            "763 Hz (655 us)"});
            this.FreqMaxComboBox.Location = new System.Drawing.Point(12, 126);
            this.FreqMaxComboBox.Name = "FreqMaxComboBox";
            this.FreqMaxComboBox.Size = new System.Drawing.Size(121, 21);
            this.FreqMaxComboBox.TabIndex = 30;
            this.FreqMaxComboBox.SelectedIndexChanged += new System.EventHandler(this.FreqMaxComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Max Frequency (Sampling Time)";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Voltage Range";
            this.label7.Visible = false;
            // 
            // startFreqPiezoTextBox
            // 
            this.startFreqPiezoTextBox.Location = new System.Drawing.Point(829, 485);
            this.startFreqPiezoTextBox.Name = "startFreqPiezoTextBox";
            this.startFreqPiezoTextBox.Size = new System.Drawing.Size(100, 20);
            this.startFreqPiezoTextBox.TabIndex = 34;
            this.startFreqPiezoTextBox.Text = "10";
            // 
            // PiezoButton
            // 
            this.PiezoButton.Location = new System.Drawing.Point(1124, 475);
            this.PiezoButton.Name = "PiezoButton";
            this.PiezoButton.Size = new System.Drawing.Size(85, 30);
            this.PiezoButton.TabIndex = 36;
            this.PiezoButton.TabStop = false;
            this.PiezoButton.Text = "Piezo";
            this.PiezoButton.UseVisualStyleBackColor = true;
            this.PiezoButton.Click += new System.EventHandler(this.PiezoButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(826, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Starting Frequency (kHz)";
            // 
            // YShiftCheckBox
            // 
            this.YShiftCheckBox.AutoSize = true;
            this.YShiftCheckBox.Location = new System.Drawing.Point(29, 334);
            this.YShiftCheckBox.Name = "YShiftCheckBox";
            this.YShiftCheckBox.Size = new System.Drawing.Size(71, 17);
            this.YShiftCheckBox.TabIndex = 39;
            this.YShiftCheckBox.Text = "Y-Shift Fit";
            this.YShiftCheckBox.UseVisualStyleBackColor = true;
            this.YShiftCheckBox.CheckedChanged += new System.EventHandler(this.YShiftCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Starting Trim Frequency (kHz)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 441);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Stopping  Trim Frequency (kHz)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(966, 469);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Starting Frequency (kHz)";
            // 
            // stopFreqPiezoTextBox
            // 
            this.stopFreqPiezoTextBox.Location = new System.Drawing.Point(969, 485);
            this.stopFreqPiezoTextBox.Name = "stopFreqPiezoTextBox";
            this.stopFreqPiezoTextBox.Size = new System.Drawing.Size(100, 20);
            this.stopFreqPiezoTextBox.TabIndex = 45;
            this.stopFreqPiezoTextBox.Text = "80";
            // 
            // trimStartFreqTextBox
            // 
            this.trimStartFreqTextBox.Location = new System.Drawing.Point(29, 408);
            this.trimStartFreqTextBox.Name = "trimStartFreqTextBox";
            this.trimStartFreqTextBox.Size = new System.Drawing.Size(100, 20);
            this.trimStartFreqTextBox.TabIndex = 46;
            this.trimStartFreqTextBox.Text = "0";
            // 
            // trimStopFreqTextBox
            // 
            this.trimStopFreqTextBox.Location = new System.Drawing.Point(29, 457);
            this.trimStopFreqTextBox.Name = "trimStopFreqTextBox";
            this.trimStopFreqTextBox.Size = new System.Drawing.Size(100, 20);
            this.trimStopFreqTextBox.TabIndex = 47;
            this.trimStopFreqTextBox.Text = "0";
            // 
            // trimFFTCheckBox
            // 
            this.trimFFTCheckBox.AutoSize = true;
            this.trimFFTCheckBox.Location = new System.Drawing.Point(29, 357);
            this.trimFFTCheckBox.Name = "trimFFTCheckBox";
            this.trimFFTCheckBox.Size = new System.Drawing.Size(68, 17);
            this.trimFFTCheckBox.TabIndex = 48;
            this.trimFFTCheckBox.Text = "Trim FFT";
            this.trimFFTCheckBox.UseVisualStyleBackColor = true;
            this.trimFFTCheckBox.CheckedChanged += new System.EventHandler(this.trimFFTCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoAvButton);
            this.groupBox1.Controls.Add(this.ContAvButton);
            this.groupBox1.Controls.Add(this.MovAvButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.MovAvTextBox);
            this.groupBox1.Location = new System.Drawing.Point(170, 493);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 85);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // MovAvButton
            // 
            this.MovAvButton.AutoSize = true;
            this.MovAvButton.Location = new System.Drawing.Point(6, 16);
            this.MovAvButton.Name = "MovAvButton";
            this.MovAvButton.Size = new System.Drawing.Size(103, 17);
            this.MovAvButton.TabIndex = 0;
            this.MovAvButton.Text = "Moving Average";
            this.MovAvButton.UseVisualStyleBackColor = true;
            this.MovAvButton.CheckedChanged += new System.EventHandler(this.MovAvButton_CheckedChanged_1);
            // 
            // ContAvButton
            // 
            this.ContAvButton.AutoSize = true;
            this.ContAvButton.Location = new System.Drawing.Point(6, 39);
            this.ContAvButton.Name = "ContAvButton";
            this.ContAvButton.Size = new System.Drawing.Size(121, 17);
            this.ContAvButton.TabIndex = 1;
            this.ContAvButton.Text = "Continuous Average";
            this.ContAvButton.UseVisualStyleBackColor = true;
            this.ContAvButton.CheckedChanged += new System.EventHandler(this.ContAvButton_CheckedChanged_1);
            // 
            // NoAvButton
            // 
            this.NoAvButton.AutoSize = true;
            this.NoAvButton.Checked = true;
            this.NoAvButton.Location = new System.Drawing.Point(6, 62);
            this.NoAvButton.Name = "NoAvButton";
            this.NoAvButton.Size = new System.Drawing.Size(82, 17);
            this.NoAvButton.TabIndex = 2;
            this.NoAvButton.TabStop = true;
            this.NoAvButton.Text = "No Average";
            this.NoAvButton.UseVisualStyleBackColor = true;
            // 
            // PM2gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 630);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trimFFTCheckBox);
            this.Controls.Add(this.trimStopFreqTextBox);
            this.Controls.Add(this.trimStartFreqTextBox);
            this.Controls.Add(this.stopFreqPiezoTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.YShiftCheckBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PiezoButton);
            this.Controls.Add(this.startFreqPiezoTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FreqMaxComboBox);
            this.Controls.Add(this.VoltRangComboBox);
            this.Controls.Add(this.FftComboBox);
            this.Controls.Add(this.LorentzStopButton);
            this.Controls.Add(this.LorentzStartButton);
            this.Controls.Add(this.lpBetaLabel);
            this.Controls.Add(this.lpGam0Label);
            this.Controls.Add(this.lpAlphaLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopViewingButton);
            this.Controls.Add(this.StartVideoButton);
            this.Controls.Add(this.CamComboBox);
            this.Controls.Add(this.CamPictureBox);
            this.Controls.Add(this.pM2fD);
            this.Controls.Add(this.pM2tD);
            this.Controls.Add(this.StopWaveButton);
            this.Controls.Add(this.StartWaveButton);
            this.Name = "PM2gui";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PM2gui_FormClosing);
            this.Load += new System.EventHandler(this.PM2gui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pM2tD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pM2fD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartWaveButton;
        private System.Windows.Forms.Button StopWaveButton;
        private System.Windows.Forms.Timer WaveFormTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart pM2fD;
        private System.Windows.Forms.PictureBox CamPictureBox;
        private System.Windows.Forms.ComboBox CamComboBox;
        private System.Windows.Forms.Button StartVideoButton;
        private System.Windows.Forms.Button StopViewingButton;
        private System.Windows.Forms.Timer LorentzTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lpAlphaLabel;
        private System.Windows.Forms.Label lpGam0Label;
        private System.Windows.Forms.Label lpBetaLabel;
        private System.Windows.Forms.Button LorentzStopButton;
        private System.Windows.Forms.Button LorentzStartButton;
        private System.Windows.Forms.TextBox MovAvTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FftComboBox;
        private System.Windows.Forms.ComboBox VoltRangComboBox;
        private System.Windows.Forms.ComboBox FreqMaxComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox startFreqPiezoTextBox;
        private System.Windows.Forms.Button PiezoButton;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataVisualization.Charting.Chart pM2tD;
        private System.Windows.Forms.CheckBox YShiftCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox stopFreqPiezoTextBox;
        private System.Windows.Forms.TextBox trimStartFreqTextBox;
        private System.Windows.Forms.TextBox trimStopFreqTextBox;
        private System.Windows.Forms.CheckBox trimFFTCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton NoAvButton;
        private System.Windows.Forms.RadioButton ContAvButton;
        private System.Windows.Forms.RadioButton MovAvButton;
    }
}

