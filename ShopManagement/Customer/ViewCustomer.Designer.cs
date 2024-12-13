namespace ShopManagement.Customer
{
    partial class ViewCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCustomer));
            btn_DeleteCus = new Button();
            btn_UpdateCus = new Button();
            btn_AddCus = new Button();
            dgv_ViewCus = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgv_ViewCus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btn_DeleteCus
            // 
            btn_DeleteCus.BackColor = Color.FromArgb(0, 125, 255);
            btn_DeleteCus.FlatStyle = FlatStyle.Flat;
            btn_DeleteCus.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_DeleteCus.ForeColor = Color.White;
            btn_DeleteCus.Location = new Point(969, 184);
            btn_DeleteCus.Margin = new Padding(2);
            btn_DeleteCus.Name = "btn_DeleteCus";
            btn_DeleteCus.Size = new Size(210, 49);
            btn_DeleteCus.TabIndex = 9;
            btn_DeleteCus.Text = "Xóa";
            btn_DeleteCus.UseVisualStyleBackColor = false;
            btn_DeleteCus.Click += btn_DeleteCus_Click;
            // 
            // btn_UpdateCus
            // 
            btn_UpdateCus.BackColor = Color.FromArgb(0, 125, 255);
            btn_UpdateCus.FlatStyle = FlatStyle.Flat;
            btn_UpdateCus.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_UpdateCus.ForeColor = Color.White;
            btn_UpdateCus.Location = new Point(969, 131);
            btn_UpdateCus.Margin = new Padding(2);
            btn_UpdateCus.Name = "btn_UpdateCus";
            btn_UpdateCus.Size = new Size(210, 49);
            btn_UpdateCus.TabIndex = 8;
            btn_UpdateCus.Text = "Sửa";
            btn_UpdateCus.UseVisualStyleBackColor = false;
            btn_UpdateCus.Click += btn_UpdateCus_Click;
            // 
            // btn_AddCus
            // 
            btn_AddCus.BackColor = Color.FromArgb(0, 125, 255);
            btn_AddCus.FlatStyle = FlatStyle.Flat;
            btn_AddCus.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddCus.ForeColor = Color.White;
            btn_AddCus.Location = new Point(969, 78);
            btn_AddCus.Margin = new Padding(2);
            btn_AddCus.Name = "btn_AddCus";
            btn_AddCus.Size = new Size(210, 49);
            btn_AddCus.TabIndex = 7;
            btn_AddCus.Text = "Thêm";
            btn_AddCus.UseVisualStyleBackColor = false;
            btn_AddCus.Click += btn_AddCus_Click;
            // 
            // dgv_ViewCus
            // 
            dgv_ViewCus.BackgroundColor = Color.White;
            dgv_ViewCus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ViewCus.Location = new Point(8, 331);
            dgv_ViewCus.Margin = new Padding(2);
            dgv_ViewCus.Name = "dgv_ViewCus";
            dgv_ViewCus.RowHeadersWidth = 74;
            dgv_ViewCus.RowTemplate.Height = 31;
            dgv_ViewCus.Size = new Size(1185, 340);
            dgv_ViewCus.TabIndex = 5;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 125, 255);
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-6, -2);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(1199, 63);
            label1.TabIndex = 10;
            label1.Text = "Danh sách khách hàng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HideSelection = false;
            txtSearch.Location = new Point(65, 78);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(249, 54);
            txtSearch.TabIndex = 16;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.WhiteSmoke;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(14, 78);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 54);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // ViewCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1190, 950);
            Controls.Add(pictureBox2);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(btn_DeleteCus);
            Controls.Add(btn_UpdateCus);
            Controls.Add(btn_AddCus);
            Controls.Add(dgv_ViewCus);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewCustomer";
            Text = "Form1";
            Load += ViewCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ViewCus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_DeleteCus;
        private System.Windows.Forms.Button btn_UpdateCus;
        private System.Windows.Forms.Button btn_AddCus;
        private System.Windows.Forms.DataGridView dgv_ViewCus;
        private System.Windows.Forms.Label label1;
        private TextBox txtSearch;
        private PictureBox pictureBox2;
    }
}