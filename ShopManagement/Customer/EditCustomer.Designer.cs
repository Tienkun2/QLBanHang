namespace ShopManagement.Customer
{
    partial class EditCustomer
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
            label9 = new Label();
            button2 = new Button();
            btn_Save = new Button();
            dtp_CreateDate = new DateTimePicker();
            label7 = new Label();
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            label1 = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(0, 125, 255);
            label9.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(-5, -3);
            label9.Name = "label9";
            label9.Size = new Size(1199, 62);
            label9.TabIndex = 53;
            label9.Text = "Thay đổi thông tin khách hàng";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlLightLight;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(865, 365);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(237, 77);
            button2.TabIndex = 45;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btn_Save
            // 
            btn_Save.BackColor = Color.FromArgb(0, 125, 255);
            btn_Save.FlatStyle = FlatStyle.Flat;
            btn_Save.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Save.ForeColor = Color.White;
            btn_Save.Location = new Point(622, 365);
            btn_Save.Margin = new Padding(3, 2, 3, 2);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(237, 77);
            btn_Save.TabIndex = 44;
            btn_Save.Text = "Lưu";
            btn_Save.UseVisualStyleBackColor = false;
            btn_Save.Click += btn_Save_Click;
            // 
            // dtp_CreateDate
            // 
            dtp_CreateDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dtp_CreateDate.Location = new Point(745, 220);
            dtp_CreateDate.Margin = new Padding(4, 5, 4, 5);
            dtp_CreateDate.Name = "dtp_CreateDate";
            dtp_CreateDate.Size = new Size(352, 30);
            dtp_CreateDate.TabIndex = 61;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(599, 220);
            label7.Name = "label7";
            label7.Size = new Size(93, 28);
            label7.TabIndex = 60;
            label7.Text = "Ngày tạo";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(204, 212);
            txtPhoneNumber.Multiline = true;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(352, 59);
            txtPhoneNumber.TabIndex = 55;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(615, 137);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 58;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(87, 220);
            label2.Name = "label2";
            label2.Size = new Size(47, 28);
            label2.TabIndex = 59;
            label2.Text = "SĐT";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(745, 132);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(352, 59);
            txtEmail.TabIndex = 56;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 132);
            label1.Name = "label1";
            label1.Size = new Size(72, 28);
            label1.TabIndex = 57;
            label1.Text = "Họ Tên";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(204, 132);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(352, 59);
            txtName.TabIndex = 54;
            // 
            // EditCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 506);
            Controls.Add(dtp_CreateDate);
            Controls.Add(label7);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(label9);
            Controls.Add(button2);
            Controls.Add(btn_Save);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "EditCustomer";
            Text = "EditCustomer";
            Load += EditCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DateTimePicker dtp_CreateDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
    }
}