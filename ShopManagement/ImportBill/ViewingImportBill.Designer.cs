namespace ShopManagement.ImportBill
{
    partial class ViewingImportBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewingImportBill));
            label1 = new Label();
            btn_DeleteImportBill = new Button();
            btn_UpdateImportBill = new Button();
            btn_AddImportBill = new Button();
            dgv_ViewImportBill = new DataGridView();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_ViewImportBill).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 125, 255);
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, -1);
            label1.Name = "label1";
            label1.Size = new Size(1192, 62);
            label1.TabIndex = 8;
            label1.Text = "Danh sách hóa đơn nhập";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_DeleteImportBill
            // 
            btn_DeleteImportBill.BackColor = Color.FromArgb(0, 125, 255);
            btn_DeleteImportBill.FlatStyle = FlatStyle.Flat;
            btn_DeleteImportBill.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_DeleteImportBill.ForeColor = Color.White;
            btn_DeleteImportBill.Location = new Point(851, 228);
            btn_DeleteImportBill.Margin = new Padding(3, 2, 3, 2);
            btn_DeleteImportBill.Name = "btn_DeleteImportBill";
            btn_DeleteImportBill.Size = new Size(309, 60);
            btn_DeleteImportBill.TabIndex = 11;
            btn_DeleteImportBill.Text = "Hủy đơn nhập";
            btn_DeleteImportBill.UseVisualStyleBackColor = false;
            btn_DeleteImportBill.Click += btn_DeleteImportBill_Click;
            // 
            // btn_UpdateImportBill
            // 
            btn_UpdateImportBill.BackColor = Color.FromArgb(0, 125, 255);
            btn_UpdateImportBill.FlatStyle = FlatStyle.Flat;
            btn_UpdateImportBill.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_UpdateImportBill.ForeColor = Color.White;
            btn_UpdateImportBill.Location = new Point(851, 161);
            btn_UpdateImportBill.Margin = new Padding(3, 2, 3, 2);
            btn_UpdateImportBill.Name = "btn_UpdateImportBill";
            btn_UpdateImportBill.Size = new Size(309, 60);
            btn_UpdateImportBill.TabIndex = 10;
            btn_UpdateImportBill.Text = "Sửa đơn nhập";
            btn_UpdateImportBill.UseVisualStyleBackColor = false;
            btn_UpdateImportBill.Click += btn_UpdateImportBill_Click;
            // 
            // btn_AddImportBill
            // 
            btn_AddImportBill.BackColor = Color.FromArgb(0, 125, 255);
            btn_AddImportBill.FlatStyle = FlatStyle.Flat;
            btn_AddImportBill.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddImportBill.ForeColor = Color.White;
            btn_AddImportBill.Location = new Point(851, 96);
            btn_AddImportBill.Margin = new Padding(3, 2, 3, 2);
            btn_AddImportBill.Name = "btn_AddImportBill";
            btn_AddImportBill.Size = new Size(309, 60);
            btn_AddImportBill.TabIndex = 9;
            btn_AddImportBill.Text = "Thêm hóa đơn nhập";
            btn_AddImportBill.UseVisualStyleBackColor = false;
            btn_AddImportBill.Click += btn_AddImportBill_Click;
            // 
            // dgv_ViewImportBill
            // 
            dgv_ViewImportBill.BackgroundColor = Color.White;
            dgv_ViewImportBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ViewImportBill.Location = new Point(12, 346);
            dgv_ViewImportBill.Margin = new Padding(3, 2, 3, 2);
            dgv_ViewImportBill.Name = "dgv_ViewImportBill";
            dgv_ViewImportBill.RowHeadersWidth = 74;
            dgv_ViewImportBill.RowTemplate.Height = 31;
            dgv_ViewImportBill.Size = new Size(1148, 380);
            dgv_ViewImportBill.TabIndex = 12;
            dgv_ViewImportBill.CellDoubleClick += dgv_ViewImportBill_CellDoubleClick_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 728);
            label2.Name = "label2";
            label2.Size = new Size(290, 20);
            label2.TabIndex = 13;
            label2.Text = "(*) Đúp chuột vào hóa đơn để xem chi tiết.";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 96);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HideSelection = false;
            txtSearch.Location = new Point(61, 96);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(249, 54);
            txtSearch.TabIndex = 18;
            //txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // ViewingImportBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1172, 805);
            Controls.Add(pictureBox1);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(dgv_ViewImportBill);
            Controls.Add(btn_DeleteImportBill);
            Controls.Add(btn_UpdateImportBill);
            Controls.Add(btn_AddImportBill);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ViewingImportBill";
            Text = "ViewingImportBill";
            ((System.ComponentModel.ISupportInitialize)dgv_ViewImportBill).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DeleteImportBill;
        private System.Windows.Forms.Button btn_UpdateImportBill;
        private System.Windows.Forms.Button btn_AddImportBill;
        private System.Windows.Forms.DataGridView dgv_ViewImportBill;
        private System.Windows.Forms.Label label2;
        private PictureBox pictureBox1;
        private TextBox txtSearch;
    }
}