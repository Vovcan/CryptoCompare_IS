namespace CryptoCompare
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            button1 = new System.Windows.Forms.Button();
            DownloadFinishedLabel = new System.Windows.Forms.Label();
            xmlCheck = new System.Windows.Forms.CheckBox();
            jsonCheck = new System.Windows.Forms.CheckBox();
            databaseCheck = new System.Windows.Forms.CheckBox();
            listView1 = new System.Windows.Forms.ListView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            listBox1 = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(20, 29);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(142, 23);
            button1.TabIndex = 0;
            button1.Text = "Download Data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DownloadFinishedLabel
            // 
            DownloadFinishedLabel.AutoSize = true;
            DownloadFinishedLabel.Location = new System.Drawing.Point(577, 29);
            DownloadFinishedLabel.Name = "DownloadFinishedLabel";
            DownloadFinishedLabel.Size = new System.Drawing.Size(0, 15);
            DownloadFinishedLabel.TabIndex = 1;
            DownloadFinishedLabel.Click += DownloadFinishedLabel_Click;
            // 
            // xmlCheck
            // 
            xmlCheck.AutoSize = true;
            xmlCheck.Location = new System.Drawing.Point(168, 29);
            xmlCheck.Name = "xmlCheck";
            xmlCheck.Size = new System.Drawing.Size(101, 19);
            xmlCheck.TabIndex = 2;
            xmlCheck.Text = "export to XML";
            xmlCheck.UseVisualStyleBackColor = true;
            xmlCheck.CheckedChanged += xmlCheck_CheckedChanged;
            // 
            // jsonCheck
            // 
            jsonCheck.AutoSize = true;
            jsonCheck.Location = new System.Drawing.Point(275, 29);
            jsonCheck.Name = "jsonCheck";
            jsonCheck.Size = new System.Drawing.Size(100, 19);
            jsonCheck.TabIndex = 3;
            jsonCheck.Text = "export to Json";
            jsonCheck.UseVisualStyleBackColor = true;
            jsonCheck.CheckedChanged += jsonCheck_CheckedChanged;
            // 
            // databaseCheck
            // 
            databaseCheck.AutoSize = true;
            databaseCheck.BackColor = System.Drawing.SystemColors.Control;
            databaseCheck.Location = new System.Drawing.Point(381, 29);
            databaseCheck.Name = "databaseCheck";
            databaseCheck.Size = new System.Drawing.Size(125, 19);
            databaseCheck.TabIndex = 4;
            databaseCheck.Text = "export to Database";
            databaseCheck.UseVisualStyleBackColor = false;
            databaseCheck.CheckedChanged += databaseCheck_CheckedChanged;
            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(20, 77);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(667, 207);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new System.Drawing.Point(20, 314);
            chart1.Name = "chart1";
            chart1.Size = new System.Drawing.Size(667, 307);
            chart1.TabIndex = 7;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new System.Drawing.Point(726, 77);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(93, 544);
            listBox1.TabIndex = 8;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 296);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 15);
            label1.TabIndex = 9;
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(842, 640);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(chart1);
            Controls.Add(listView1);
            Controls.Add(databaseCheck);
            Controls.Add(jsonCheck);
            Controls.Add(xmlCheck);
            Controls.Add(DownloadFinishedLabel);
            Controls.Add(button1);
            Name = "Form1";
            Text = "CryptoCompare";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label DownloadFinishedLabel;
        private System.Windows.Forms.CheckBox xmlCheck;
        private System.Windows.Forms.CheckBox jsonCheck;
        private System.Windows.Forms.CheckBox databaseCheck;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}

