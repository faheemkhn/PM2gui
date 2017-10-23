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
            this.StartWaveButton = new System.Windows.Forms.Button();
            this.StopWaveButton = new System.Windows.Forms.Button();
            this.WaveFormTimer = new System.Windows.Forms.Timer(this.components);
            this.pM2tD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pM2fD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CamPictureBox = new System.Windows.Forms.PictureBox();
            this.CamComboBox = new System.Windows.Forms.ComboBox();
            this.StartVideoButton = new System.Windows.Forms.Button();
            this.StopViewingButton = new System.Windows.Forms.Button();
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
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
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
            this.pM2fD.Series.Add(series2);
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
            // PM2gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 630);
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
    }
}

