namespace ShopManagement.Statistics
{
    partial class ViewingStatictis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewingStatictis));
            labelWrapper1 = new Label();
            dataGridView1 = new DataGridView();
            labelSection1 = new Label();
            label7 = new Label();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            btnFilter = new Button();
            pictureBox1 = new PictureBox();
            labelSection2 = new Label();
            labelWrapper2 = new Label();
            labelSection3 = new Label();
            labelWrapper3 = new Label();
            picB_Section2 = new PictureBox();
            labelInfo = new Label();
            label1 = new Label();
            btnExportReport = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picB_Section2).BeginInit();
            SuspendLayout();
            // 
            // labelWrapper1
            // 
            labelWrapper1.BackColor = Color.FromArgb(128, 128, 255);
            labelWrapper1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWrapper1.ForeColor = SystemColors.ButtonHighlight;
            labelWrapper1.Location = new Point(29, 121);
            labelWrapper1.Name = "labelWrapper1";
            labelWrapper1.Padding = new Padding(10, 12, 0, 0);
            labelWrapper1.Size = new Size(331, 210);
            labelWrapper1.TabIndex = 0;
            labelWrapper1.Text = "SỐ LƯỢNG HÓA ĐƠN";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 496);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(1091, 381);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // labelSection1
            // 
            labelSection1.BackColor = Color.FromArgb(128, 128, 255);
            labelSection1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSection1.ForeColor = SystemColors.ButtonHighlight;
            labelSection1.Location = new Point(29, 181);
            labelSection1.Name = "labelSection1";
            labelSection1.Size = new Size(162, 105);
            labelSection1.TabIndex = 4;
            labelSection1.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(29, 389);
            label7.Name = "label7";
            label7.Size = new Size(147, 28);
            label7.TabIndex = 7;
            label7.Text = "Thống kê theo";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(196, 378);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(315, 39);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(798, 382);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(322, 30);
            dateTimePicker1.TabIndex = 9;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(0, 125, 255);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1037, 437);
            btnFilter.Margin = new Padding(0);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(83, 42);
            btnFilter.TabIndex = 32;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(128, 128, 255);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(228, 181);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(132, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // labelSection2
            // 
            labelSection2.BackColor = Color.FromArgb(0, 192, 0);
            labelSection2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSection2.ForeColor = SystemColors.ButtonHighlight;
            labelSection2.Location = new Point(417, 181);
            labelSection2.Name = "labelSection2";
            labelSection2.Size = new Size(162, 105);
            labelSection2.TabIndex = 37;
            labelSection2.Text = "0";
            // 
            // labelWrapper2
            // 
            labelWrapper2.BackColor = Color.FromArgb(0, 192, 0);
            labelWrapper2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWrapper2.ForeColor = SystemColors.ButtonHighlight;
            labelWrapper2.Location = new Point(417, 121);
            labelWrapper2.Name = "labelWrapper2";
            labelWrapper2.Padding = new Padding(10, 12, 0, 0);
            labelWrapper2.Size = new Size(331, 210);
            labelWrapper2.TabIndex = 36;
            labelWrapper2.Text = "KHÁCH HÀNG";
            // 
            // labelSection3
            // 
            labelSection3.BackColor = Color.Red;
            labelSection3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSection3.ForeColor = SystemColors.ButtonHighlight;
            labelSection3.Location = new Point(789, 181);
            labelSection3.Name = "labelSection3";
            labelSection3.Size = new Size(331, 105);
            labelSection3.TabIndex = 40;
            labelSection3.Text = "0";
            labelSection3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelWrapper3
            // 
            labelWrapper3.BackColor = Color.Red;
            labelWrapper3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWrapper3.ForeColor = SystemColors.ButtonHighlight;
            labelWrapper3.Location = new Point(789, 121);
            labelWrapper3.Name = "labelWrapper3";
            labelWrapper3.Padding = new Padding(10, 12, 0, 0);
            labelWrapper3.Size = new Size(331, 210);
            labelWrapper3.TabIndex = 39;
            labelWrapper3.Text = "DOANH THU";
            // 
            // picB_Section2
            // 
            picB_Section2.BackColor = Color.FromArgb(0, 192, 0);
            picB_Section2.Image = (Image)resources.GetObject("picB_Section2.Image");
            picB_Section2.Location = new Point(610, 181);
            picB_Section2.Margin = new Padding(3, 4, 3, 4);
            picB_Section2.Name = "picB_Section2";
            picB_Section2.Size = new Size(138, 150);
            picB_Section2.SizeMode = PictureBoxSizeMode.StretchImage;
            picB_Section2.TabIndex = 41;
            picB_Section2.TabStop = false;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInfo.Location = new Point(29, 881);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(290, 20);
            labelInfo.TabIndex = 42;
            labelInfo.Text = "(*) Đúp chuột vào hóa đơn để xem chi tiết.";
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 125, 255);
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-2, -7);
            label1.Name = "label1";
            label1.Size = new Size(1199, 62);
            label1.TabIndex = 43;
            label1.Text = "Thống kê";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnExportReport
            // 
            btnExportReport.BackColor = Color.FromArgb(0, 125, 255);
            btnExportReport.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnExportReport.Location = new Point(29, 437);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(173, 42);
            btnExportReport.TabIndex = 44;
            btnExportReport.Text = "Xuất thống kê";
            btnExportReport.UseVisualStyleBackColor = false;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // ViewingStatictis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1172, 916);
            Controls.Add(btnExportReport);
            Controls.Add(label1);
            Controls.Add(labelInfo);
            Controls.Add(picB_Section2);
            Controls.Add(labelSection3);
            Controls.Add(labelWrapper3);
            Controls.Add(labelSection2);
            Controls.Add(labelWrapper2);
            Controls.Add(pictureBox1);
            Controls.Add(btnFilter);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(labelSection1);
            Controls.Add(dataGridView1);
            Controls.Add(labelWrapper1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ViewingStatictis";
            ShowIcon = false;
            Text = "ViewingStatictis";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picB_Section2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelWrapper1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelSection1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelSection2;
        private System.Windows.Forms.Label labelWrapper2;
        private System.Windows.Forms.Label labelSection3;
        private System.Windows.Forms.Label labelWrapper3;
        private System.Windows.Forms.PictureBox picB_Section2;
        private System.Windows.Forms.Label labelInfo;
        private Label label1;
        private Button btnExportReport;
    }
}