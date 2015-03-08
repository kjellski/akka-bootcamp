namespace ChartApp
{
    partial class Main
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sysChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DiskButton = new System.Windows.Forms.Button();
            this.MemoryButton = new System.Windows.Forms.Button();
            this.CPUButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sysChart)).BeginInit();
            this.SuspendLayout();
            // 
            // sysChart
            // 
            chartArea2.Name = "ChartArea1";
            this.sysChart.ChartAreas.Add(chartArea2);
            this.sysChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.sysChart.Legends.Add(legend2);
            this.sysChart.Location = new System.Drawing.Point(0, 0);
            this.sysChart.Name = "sysChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.sysChart.Series.Add(series2);
            this.sysChart.Size = new System.Drawing.Size(684, 446);
            this.sysChart.TabIndex = 0;
            this.sysChart.Text = "sysChart";
            // 
            // DiskButton
            // 
            this.DiskButton.Location = new System.Drawing.Point(571, 364);
            this.DiskButton.Name = "DiskButton";
            this.DiskButton.Size = new System.Drawing.Size(101, 39);
            this.DiskButton.TabIndex = 2;
            this.DiskButton.Text = "Disk (OFF)";
            this.DiskButton.UseVisualStyleBackColor = true;
            this.DiskButton.Click += new System.EventHandler(this.DiskButton_Click);
            // 
            // MemoryButton
            // 
            this.MemoryButton.Location = new System.Drawing.Point(571, 319);
            this.MemoryButton.Name = "MemoryButton";
            this.MemoryButton.Size = new System.Drawing.Size(101, 39);
            this.MemoryButton.TabIndex = 3;
            this.MemoryButton.Text = "Memory (OFF)";
            this.MemoryButton.UseVisualStyleBackColor = true;
            this.MemoryButton.Click += new System.EventHandler(this.MemoryButton_Click);
            // 
            // CPUButton
            // 
            this.CPUButton.Location = new System.Drawing.Point(571, 274);
            this.CPUButton.Name = "CPUButton";
            this.CPUButton.Size = new System.Drawing.Size(101, 39);
            this.CPUButton.TabIndex = 4;
            this.CPUButton.Text = "CPU (ON)";
            this.CPUButton.UseVisualStyleBackColor = true;
            this.CPUButton.Click += new System.EventHandler(this.CPUButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 446);
            this.Controls.Add(this.CPUButton);
            this.Controls.Add(this.MemoryButton);
            this.Controls.Add(this.DiskButton);
            this.Controls.Add(this.sysChart);
            this.Name = "Main";
            this.Text = "System Metrics";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sysChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart sysChart;
        private System.Windows.Forms.Button DiskButton;
        private System.Windows.Forms.Button MemoryButton;
        private System.Windows.Forms.Button CPUButton;
    }
}

