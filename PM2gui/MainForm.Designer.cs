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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.lpALabel = new System.Windows.Forms.Label();
            this.lpGamLabel = new System.Windows.Forms.Label();
            this.lpx0Label = new System.Windows.Forms.Label();
            this.LorentzStopButton = new System.Windows.Forms.Button();
            this.LorentzStartButton = new System.Windows.Forms.Button();
            this.MovAvTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FftComboBox = new System.Windows.Forms.ComboBox();
            this.MovAvButton = new System.Windows.Forms.CheckBox();
            this.MeasDevComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pM2tD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pM2fD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartWaveButton
            // 
            this.StartWaveButton.Location = new System.Drawing.Point(29, 84);
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
            this.StopWaveButton.Location = new System.Drawing.Point(29, 120);
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
            chartArea1.Name = "ChartArea1";
            this.pM2tD.ChartAreas.Add(chartArea1);
            this.pM2tD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pM2tD.Location = new System.Drawing.Point(151, 12);
            this.pM2tD.Name = "pM2tD";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            this.pM2tD.Series.Add(series1);
            this.pM2tD.Size = new System.Drawing.Size(534, 226);
            this.pM2tD.TabIndex = 4;
            this.pM2tD.Text = "chart2";
            // 
            // pM2fD
            // 
            chartArea2.Name = "ChartArea1";
            this.pM2fD.ChartAreas.Add(chartArea2);
            this.pM2fD.Location = new System.Drawing.Point(151, 262);
            this.pM2fD.Name = "pM2fD";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series2";
            this.pM2fD.Series.Add(series2);
            this.pM2fD.Series.Add(series3);
            this.pM2fD.Size = new System.Drawing.Size(534, 226);
            this.pM2fD.TabIndex = 5;
            this.pM2fD.Text = "chart2";
            // 
            // CamPictureBox
            // 
            this.CamPictureBox.Location = new System.Drawing.Point(812, 78);
            this.CamPictureBox.Name = "CamPictureBox";
            this.CamPictureBox.Size = new System.Drawing.Size(409, 323);
            this.CamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CamPictureBox.TabIndex = 6;
            this.CamPictureBox.TabStop = false;
            // 
            // CamComboBox
            // 
            this.CamComboBox.FormattingEnabled = true;
            this.CamComboBox.Location = new System.Drawing.Point(812, 407);
            this.CamComboBox.Name = "CamComboBox";
            this.CamComboBox.Size = new System.Drawing.Size(121, 21);
            this.CamComboBox.TabIndex = 7;
            this.CamComboBox.Visible = false;
            // 
            // StartVideoButton
            // 
            this.StartVideoButton.Location = new System.Drawing.Point(1039, 407);
            this.StartVideoButton.Name = "StartVideoButton";
            this.StartVideoButton.Size = new System.Drawing.Size(93, 23);
            this.StartVideoButton.TabIndex = 8;
            this.StartVideoButton.Text = "Start Viewing";
            this.StartVideoButton.UseVisualStyleBackColor = true;
            this.StartVideoButton.Click += new System.EventHandler(this.StartVideoButton_Click);
            // 
            // StopViewingButton
            // 
            this.StopViewingButton.Location = new System.Drawing.Point(1138, 407);
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
            this.label1.Location = new System.Drawing.Point(26, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "A =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "gam = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "freq0 =";
            // 
            // lpALabel
            // 
            this.lpALabel.AutoSize = true;
            this.lpALabel.Location = new System.Drawing.Point(51, 342);
            this.lpALabel.Name = "lpALabel";
            this.lpALabel.Size = new System.Drawing.Size(19, 13);
            this.lpALabel.TabIndex = 14;
            this.lpALabel.Text = "00";
            // 
            // lpGamLabel
            // 
            this.lpGamLabel.AutoSize = true;
            this.lpGamLabel.Location = new System.Drawing.Point(61, 364);
            this.lpGamLabel.Name = "lpGamLabel";
            this.lpGamLabel.Size = new System.Drawing.Size(19, 13);
            this.lpGamLabel.TabIndex = 15;
            this.lpGamLabel.Text = "00";
            // 
            // lpx0Label
            // 
            this.lpx0Label.AutoSize = true;
            this.lpx0Label.Location = new System.Drawing.Point(64, 386);
            this.lpx0Label.Name = "lpx0Label";
            this.lpx0Label.Size = new System.Drawing.Size(19, 13);
            this.lpx0Label.TabIndex = 16;
            this.lpx0Label.Text = "00";
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
            this.MovAvTextBox.Location = new System.Drawing.Point(170, 519);
            this.MovAvTextBox.Name = "MovAvTextBox";
            this.MovAvTextBox.Size = new System.Drawing.Size(85, 20);
            this.MovAvTextBox.TabIndex = 21;
            this.MovAvTextBox.Text = "100";
            this.MovAvTextBox.TextChanged += new System.EventHandler(this.MovAvTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 522);
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
            this.FftComboBox.Location = new System.Drawing.Point(299, 496);
            this.FftComboBox.Name = "FftComboBox";
            this.FftComboBox.Size = new System.Drawing.Size(121, 21);
            this.FftComboBox.TabIndex = 23;
            this.FftComboBox.Text = "Log";
            this.FftComboBox.SelectedIndexChanged += new System.EventHandler(this.FftComboBox_SelectedIndexChanged);
            // 
            // MovAvButton
            // 
            this.MovAvButton.Location = new System.Drawing.Point(160, 494);
            this.MovAvButton.Name = "MovAvButton";
            this.MovAvButton.Size = new System.Drawing.Size(104, 24);
            this.MovAvButton.TabIndex = 25;
            this.MovAvButton.Text = "Moving Average";
            this.MovAvButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MovAvButton.UseVisualStyleBackColor = true;
            this.MovAvButton.CheckedChanged += new System.EventHandler(this.MovAvButton_CheckedChanged);
            // 
            // MeasDevComboBox
            // 
            this.MeasDevComboBox.FormattingEnabled = true;
            this.MeasDevComboBox.Location = new System.Drawing.Point(12, 31);
            this.MeasDevComboBox.Name = "MeasDevComboBox";
            this.MeasDevComboBox.Size = new System.Drawing.Size(121, 21);
            this.MeasDevComboBox.TabIndex = 26;
            this.MeasDevComboBox.SelectedIndexChanged += new System.EventHandler(this.MeasDevComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Tek Device Address";
            // 
            // PM2gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 630);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MeasDevComboBox);
            this.Controls.Add(this.MovAvButton);
            this.Controls.Add(this.FftComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MovAvTextBox);
            this.Controls.Add(this.LorentzStopButton);
            this.Controls.Add(this.LorentzStartButton);
            this.Controls.Add(this.lpx0Label);
            this.Controls.Add(this.lpGamLabel);
            this.Controls.Add(this.lpALabel);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartWaveButton;
        private System.Windows.Forms.Button StopWaveButton;
        private System.Windows.Forms.Timer WaveFormTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart pM2tD;
        private System.Windows.Forms.DataVisualization.Charting.Chart pM2fD;
        private System.Windows.Forms.PictureBox CamPictureBox;
        private System.Windows.Forms.ComboBox CamComboBox;
        private System.Windows.Forms.Button StartVideoButton;
        private System.Windows.Forms.Button StopViewingButton;
        private System.Windows.Forms.Timer LorentzTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lpALabel;
        private System.Windows.Forms.Label lpGamLabel;
        private System.Windows.Forms.Label lpx0Label;
        private System.Windows.Forms.Button LorentzStopButton;
        private System.Windows.Forms.Button LorentzStartButton;
        private System.Windows.Forms.TextBox MovAvTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FftComboBox;
        private System.Windows.Forms.CheckBox MovAvButton;
        private System.Windows.Forms.ComboBox MeasDevComboBox;
        private System.Windows.Forms.Label label5;
    }
}

