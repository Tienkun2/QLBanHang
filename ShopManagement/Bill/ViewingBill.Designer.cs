namespace ShopManagement.Bill
{
    partial class ViewingBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewingBill));
            label1 = new Label();
            btn_DeleteBill = new Button();
            btn_AddBill = new Button();
            dgv_Bill = new DataGridView();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_Bill).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 125, 255);
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-9, -3);
            label1.Name = "label1";
            label1.Size = new Size(1205, 63);
            label1.TabIndex = 15;
            label1.Text = "Hóa đơn bán";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_DeleteBill
            // 
            btn_DeleteBill.BackColor = Color.FromArgb(0, 125, 255);
            btn_DeleteBill.FlatStyle = FlatStyle.Flat;
            btn_DeleteBill.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_DeleteBill.ForeColor = Color.White;
            btn_DeleteBill.Location = new Point(759, 194);
            btn_DeleteBill.Name = "btn_DeleteBill";
            btn_DeleteBill.Size = new Size(385, 60);
            btn_DeleteBill.TabIndex = 14;
            btn_DeleteBill.Text = "Xóa Hóa đơn bán";
            btn_DeleteBill.UseVisualStyleBackColor = false;
            btn_DeleteBill.Click += btn_DeleteBill_Click;
            // 
            // btn_AddBill
            // 
            btn_AddBill.BackColor = Color.FromArgb(0, 125, 255);
            btn_AddBill.FlatStyle = FlatStyle.Flat;
            btn_AddBill.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddBill.ForeColor = Color.White;
            btn_AddBill.Location = new Point(759, 105);
            btn_AddBill.Name = "btn_AddBill";
            btn_AddBill.Size = new Size(385, 60);
            btn_AddBill.TabIndex = 12;
            btn_AddBill.Text = "Thêm Hóa đơn bán";
            btn_AddBill.UseVisualStyleBackColor = false;
            btn_AddBill.Click += btn_AddBill_Click;
            // 
            // dgv_Bill
            // 
            dgv_Bill.BackgroundColor = Color.White;
            dgv_Bill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Bill.Location = new Point(12, 284);
            dgv_Bill.Name = "dgv_Bill";
            dgv_Bill.RowHeadersWidth = 74;
            dgv_Bill.RowTemplate.Height = 31;
            dgv_Bill.Size = new Size(1165, 503);
            dgv_Bill.TabIndex = 11;
            dgv_Bill.CellClick += dgv_Bill_CellClick;
            dgv_Bill.CellDoubleClick += dgv_Bill_CellDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 790);
            label2.Name = "label2";
            label2.Size = new Size(290, 20);
            label2.TabIndex = 16;
            label2.Text = "(*) Đúp chuột vào hóa đơn để xem chi tiết.";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(21, 105);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HideSelection = false;
            txtSearch.Location = new Point(75, 105);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(249, 54);
            txtSearch.TabIndex = 17;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // ViewingBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1191, 860);
            Controls.Add(pictureBox1);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_DeleteBill);
            Controls.Add(btn_AddBill);
            Controls.Add(dgv_Bill);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "ViewingBill";
            Text = "Form1";
            Load += ViewingBill_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Bill).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DeleteBill;
        private System.Windows.Forms.Button btn_AddBill;
        private System.Windows.Forms.DataGridView dgv_Bill;
        private System.Windows.Forms.Label label2;
        private PictureBox pictureBox1;
        private TextBox txtSearch;
    }
}