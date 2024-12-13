namespace ShopManagement
{
    partial class HomeForm
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
            PanelForm = new Panel();
            label4 = new Label();
            label1 = new Label();
            btnProducts = new Button();
            btnBill = new Button();
            btnStatistic = new Button();
            btnWarehouse = new Button();
            btnStaff = new Button();
            btnImportBill = new Button();
            btnThoat = new Button();
            label2 = new Label();
            label3 = new Label();
            btnBrand = new Button();
            btnCustomers = new Button();
            PanelForm.SuspendLayout();
            SuspendLayout();
            // 
            // PanelForm
            // 
            PanelForm.BackColor = SystemColors.ButtonHighlight;
            PanelForm.Controls.Add(label4);
            PanelForm.Location = new Point(342, -1);
            PanelForm.Margin = new Padding(3, 2, 3, 2);
            PanelForm.Name = "PanelForm";
            PanelForm.Size = new Size(1190, 950);
            PanelForm.TabIndex = 0;
            PanelForm.Paint += PanelForm_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(192, 192, 255);
            label4.Location = new Point(280, 99);
            label4.Name = "label4";
            label4.Size = new Size(775, 62);
            label4.TabIndex = 0;
            label4.Text = "Chúc bạn một ngày tốt lành!! :333\r\n";
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 125, 255);
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-1, -1);
            label1.Name = "label1";
            label1.Size = new Size(337, 56);
            label1.TabIndex = 4;
            label1.Text = "Xin chào ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(0, 125, 225);
            btnProducts.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = SystemColors.ButtonHighlight;
            btnProducts.Location = new Point(35, 108);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(267, 60);
            btnProducts.TabIndex = 7;
            btnProducts.Text = "QUẦN ÁO";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnBill
            // 
            btnBill.BackColor = Color.FromArgb(0, 125, 225);
            btnBill.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBill.ForeColor = SystemColors.ButtonHighlight;
            btnBill.Location = new Point(35, 367);
            btnBill.Margin = new Padding(4);
            btnBill.Name = "btnBill";
            btnBill.Size = new Size(267, 60);
            btnBill.TabIndex = 9;
            btnBill.Text = "HÓA ĐƠN BÁN";
            btnBill.UseVisualStyleBackColor = false;
            btnBill.Click += btnBill_Click;
            // 
            // btnStatistic
            // 
            btnStatistic.BackColor = Color.FromArgb(0, 125, 225);
            btnStatistic.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStatistic.ForeColor = SystemColors.ButtonHighlight;
            btnStatistic.Location = new Point(35, 624);
            btnStatistic.Margin = new Padding(4);
            btnStatistic.Name = "btnStatistic";
            btnStatistic.Size = new Size(267, 60);
            btnStatistic.TabIndex = 10;
            btnStatistic.Text = "THỐNG KÊ";
            btnStatistic.UseVisualStyleBackColor = false;
            btnStatistic.Click += btnStatistic_Click;
            // 
            // btnWarehouse
            // 
            btnWarehouse.BackColor = Color.FromArgb(0, 125, 225);
            btnWarehouse.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWarehouse.ForeColor = SystemColors.ButtonHighlight;
            btnWarehouse.Location = new Point(35, 454);
            btnWarehouse.Margin = new Padding(4);
            btnWarehouse.Name = "btnWarehouse";
            btnWarehouse.Size = new Size(267, 60);
            btnWarehouse.TabIndex = 11;
            btnWarehouse.Text = "KHO QUẦN ÁO";
            btnWarehouse.UseVisualStyleBackColor = false;
            btnWarehouse.Click += btnWarehouse_Click;
            // 
            // btnStaff
            // 
            btnStaff.BackColor = Color.FromArgb(0, 125, 225);
            btnStaff.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStaff.ForeColor = SystemColors.ButtonHighlight;
            btnStaff.Location = new Point(35, 715);
            btnStaff.Margin = new Padding(4);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(267, 60);
            btnStaff.TabIndex = 12;
            btnStaff.Text = "NHÂN VIÊN";
            btnStaff.UseVisualStyleBackColor = false;
            btnStaff.Click += btnStaff_Click;
            // 
            // btnImportBill
            // 
            btnImportBill.BackColor = Color.FromArgb(0, 125, 225);
            btnImportBill.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImportBill.ForeColor = SystemColors.ButtonHighlight;
            btnImportBill.Location = new Point(35, 542);
            btnImportBill.Margin = new Padding(4);
            btnImportBill.Name = "btnImportBill";
            btnImportBill.Size = new Size(267, 60);
            btnImportBill.TabIndex = 13;
            btnImportBill.Text = "NHẬP HÀNG";
            btnImportBill.UseVisualStyleBackColor = false;
            btnImportBill.Click += btnImportBill_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.White;
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = SystemColors.ActiveCaptionText;
            btnThoat.Location = new Point(35, 835);
            btnThoat.Margin = new Padding(4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(267, 60);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(0, 125, 255);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(332, -1);
            label2.Name = "label2";
            label2.Size = new Size(11, 1196);
            label2.TabIndex = 15;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 125, 225);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(1, 1180);
            label3.Name = "label3";
            label3.Size = new Size(381, 11);
            label3.TabIndex = 16;
            // 
            // btnBrand
            // 
            btnBrand.BackColor = Color.FromArgb(0, 125, 225);
            btnBrand.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrand.ForeColor = SystemColors.ButtonHighlight;
            btnBrand.Location = new Point(35, 193);
            btnBrand.Margin = new Padding(4);
            btnBrand.Name = "btnBrand";
            btnBrand.Size = new Size(267, 60);
            btnBrand.TabIndex = 17;
            btnBrand.Text = "NHÃN HÀNG";
            btnBrand.UseVisualStyleBackColor = false;
            btnBrand.Click += btnBrand_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.FromArgb(0, 125, 225);
            btnCustomers.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCustomers.ForeColor = SystemColors.ButtonHighlight;
            btnCustomers.Location = new Point(35, 280);
            btnCustomers.Margin = new Padding(4);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(267, 60);
            btnCustomers.TabIndex = 18;
            btnCustomers.Text = "KHÁCH HÀNG";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1532, 953);
            Controls.Add(btnCustomers);
            Controls.Add(btnBrand);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnThoat);
            Controls.Add(btnImportBill);
            Controls.Add(btnStaff);
            Controls.Add(btnWarehouse);
            Controls.Add(btnStatistic);
            Controls.Add(btnBill);
            Controls.Add(btnProducts);
            Controls.Add(label1);
            Controls.Add(PanelForm);
            Font = new Font("Microsoft Sans Serif", 7.8F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(342, -1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            PanelForm.ResumeLayout(false);
            PanelForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel PanelForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnImportBill;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Button btnBrand;
        private Button btnCustomers;
    }
}