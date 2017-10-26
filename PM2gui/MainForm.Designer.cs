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
            this.LorentzButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lpALabel = new System.Windows.Forms.Label();
            this.lpGamLabel = new System.Windows.Forms.Label();
            this.lpx0Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pM2tD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pM2fD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).BeginInit();
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
            this.WaveFormTimer.Interval = 10;
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
            // LorentzButton
            // 
            this.LorentzButton.Location = new System.Drawing.Point(29, 262);
            this.LorentzButton.Name = "LorentzButton";
            this.LorentzButton.Size = new System.Drawing.Size(85, 30);
            this.LorentzButton.TabIndex = 10;
            this.LorentzButton.TabStop = true;
            this.LorentzButton.Text = "Lorentzian FIt";
            this.LorentzButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LorentzButton.UseVisualStyleBackColor = true;
            this.LorentzButton.CheckedChanged += new System.EventHandler(this.LorentzButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "A =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "gam = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "freq0 =";
            // 
            // lpALabel
            // 
            this.lpALabel.AutoSize = true;
            this.lpALabel.Location = new System.Drawing.Point(54, 314);
            this.lpALabel.Name = "lpALabel";
            this.lpALabel.Size = new System.Drawing.Size(19, 13);
            this.lpALabel.TabIndex = 14;
            this.lpALabel.Text = "00";
            // 
            // lpGamLabel
            // 
            this.lpGamLabel.AutoSize = true;
            this.lpGamLabel.Location = new System.Drawing.Point(64, 336);
            this.lpGamLabel.Name = "lpGamLabel";
            this.lpGamLabel.Size = new System.Drawing.Size(19, 13);
            this.lpGamLabel.TabIndex = 15;
            this.lpGamLabel.Text = "00";
            // 
            // lpx0Label
            // 
            this.lpx0Label.AutoSize = true;
            this.lpx0Label.Location = new System.Drawing.Point(67, 358);
            this.lpx0Label.Name = "lpx0Label";
            this.lpx0Label.Size = new System.Drawing.Size(19, 13);
            this.lpx0Label.TabIndex = 16;
            this.lpx0Label.Text = "00";
            // 
            // PM2gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 630);
            this.Controls.Add(this.lpx0Label);
            this.Controls.Add(this.lpGamLabel);
            this.Controls.Add(this.lpALabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LorentzButton);
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
        internal System.Windows.Forms.RadioButton LorentzButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lpALabel;
        private System.Windows.Forms.Label lpGamLabel;
        private System.Windows.Forms.Label lpx0Label;
    }
}

