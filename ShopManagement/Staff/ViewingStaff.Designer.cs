namespace ShopManagement.Staff
{
    partial class ViewingStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewingStaff));
            dgv_ViewStaff = new DataGridView();
            txtSearch = new TextBox();
            btn_AddStaff = new Button();
            btn_UpdateStaff = new Button();
            btn_Delete = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgv_ViewStaff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgv_ViewStaff
            // 
            dgv_ViewStaff.BackgroundColor = Color.White;
            dgv_ViewStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ViewStaff.Location = new Point(12, 335);
            dgv_ViewStaff.Margin = new Padding(3, 2, 3, 2);
            dgv_ViewStaff.Name = "dgv_ViewStaff";
            dgv_ViewStaff.RowHeadersWidth = 74;
            dgv_ViewStaff.RowTemplate.Height = 31;
            dgv_ViewStaff.Size = new Size(1166, 504);
            dgv_ViewStaff.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HideSelection = false;
            txtSearch.Location = new Point(66, 86);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(249, 54);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btn_AddStaff
            // 
            btn_AddStaff.BackColor = Color.FromArgb(0, 125, 255);
            btn_AddStaff.FlatStyle = FlatStyle.Flat;
            btn_AddStaff.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddStaff.ForeColor = Color.White;
            btn_AddStaff.Location = new Point(959, 80);
            btn_AddStaff.Margin = new Padding(3, 2, 3, 2);
            btn_AddStaff.Name = "btn_AddStaff";
            btn_AddStaff.Size = new Size(185, 60);
            btn_AddStaff.TabIndex = 2;
            btn_AddStaff.Text = "Thêm";
            btn_AddStaff.UseVisualStyleBackColor = false;
            btn_AddStaff.Click += btn_AddStaff_Click;
            // 
            // btn_UpdateStaff
            // 
            btn_UpdateStaff.BackColor = Color.FromArgb(0, 125, 255);
            btn_UpdateStaff.FlatStyle = FlatStyle.Flat;
            btn_UpdateStaff.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_UpdateStaff.ForeColor = Color.White;
            btn_UpdateStaff.Location = new Point(959, 146);
            btn_UpdateStaff.Margin = new Padding(3, 2, 3, 2);
            btn_UpdateStaff.Name = "btn_UpdateStaff";
            btn_UpdateStaff.Size = new Size(185, 60);
            btn_UpdateStaff.TabIndex = 3;
            btn_UpdateStaff.Text = "Sửa";
            btn_UpdateStaff.UseVisualStyleBackColor = false;
            btn_UpdateStaff.Click += btn_UpdateStaff_Click;
            // 
            // btn_Delete
            // 
            btn_Delete.BackColor = Color.FromArgb(0, 125, 255);
            btn_Delete.FlatStyle = FlatStyle.Flat;
            btn_Delete.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Delete.ForeColor = Color.White;
            btn_Delete.Location = new Point(959, 212);
            btn_Delete.Margin = new Padding(3, 2, 3, 2);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(185, 60);
            btn_Delete.TabIndex = 4;
            btn_Delete.Text = "Xóa";
            btn_Delete.UseVisualStyleBackColor = false;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 125, 255);
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, -2);
            label1.Name = "label1";
            label1.Size = new Size(1192, 62);
            label1.TabIndex = 7;
            label1.Text = "Danh sách nhân viên";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 86);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // ViewingStaff
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1190, 860);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(btn_Delete);
            Controls.Add(btn_UpdateStaff);
            Controls.Add(btn_AddStaff);
            Controls.Add(txtSearch);
            Controls.Add(dgv_ViewStaff);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ViewingStaff";
            Text = "ViewingStaff";
            Load += ViewingStaff_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ViewStaff).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ViewStaff;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btn_AddStaff;
        private System.Windows.Forms.Button btn_UpdateStaff;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}