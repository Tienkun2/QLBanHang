namespace ShopManagement.Bill
{
    partial class AddingBill
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
            cmbCustomer = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTotal = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            btnAddProductToBill = new Button();
            dgvBillDetail = new DataGridView();
            label6 = new Label();
            btnSave = new Button();
            btnExit = new Button();
            txtSale = new TextBox();
            label1 = new Label();
            btnAddCustomer = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBillDetail).BeginInit();
            SuspendLayout();
            // 
            // cmbCustomer
            // 
            cmbCustomer.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(146, 132);
            cmbCustomer.Margin = new Padding(3, 2, 3, 2);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(222, 33);
            cmbCustomer.TabIndex = 2;
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 142);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 3;
            label2.Text = "Khách hàng :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(446, 141);
            label3.Name = "label3";
            label3.Size = new Size(56, 25);
            label3.TabIndex = 5;
            label3.Text = "Sale :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(715, 140);
            label4.Name = "label4";
            label4.Size = new Size(203, 25);
            label4.TabIndex = 7;
            label4.Text = "Tổng tiền thanh toán : ";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(938, 134);
            txtTotal.Margin = new Padding(3, 2, 3, 2);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(191, 32);
            txtTotal.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(146, 249);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(222, 32);
            dateTimePicker1.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(60, 249);
            label5.Name = "label5";
            label5.Size = new Size(65, 25);
            label5.TabIndex = 9;
            label5.Text = "Ngày :";
            // 
            // btnAddProductToBill
            // 
            btnAddProductToBill.BackColor = Color.FromArgb(0, 125, 255);
            btnAddProductToBill.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProductToBill.ForeColor = Color.White;
            btnAddProductToBill.Location = new Point(11, 704);
            btnAddProductToBill.Margin = new Padding(3, 2, 3, 2);
            btnAddProductToBill.Name = "btnAddProductToBill";
            btnAddProductToBill.Size = new Size(164, 52);
            btnAddProductToBill.TabIndex = 10;
            btnAddProductToBill.Text = "Thêm quần áo ";
            btnAddProductToBill.UseVisualStyleBackColor = false;
            btnAddProductToBill.Click += btnAddProductToBill_Click;
            // 
            // dgvBillDetail
            // 
            dgvBillDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillDetail.Location = new Point(11, 332);
            dgvBillDetail.Margin = new Padding(3, 2, 3, 2);
            dgvBillDetail.Name = "dgvBillDetail";
            dgvBillDetail.RowHeadersWidth = 62;
            dgvBillDetail.RowTemplate.Height = 28;
            dgvBillDetail.Size = new Size(1161, 366);
            dgvBillDetail.TabIndex = 11;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(0, 125, 255);
            label6.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 9);
            label6.Name = "label6";
            label6.Size = new Size(1161, 45);
            label6.TabIndex = 12;
            label6.Text = "Thêm hóa đơn";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 125, 255);
            btnSave.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(681, 718);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(164, 70);
            btnSave.TabIndex = 13;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(0, 125, 255);
            btnExit.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(890, 718);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(164, 70);
            btnExit.TabIndex = 14;
            btnExit.Text = "Hủy";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // txtSale
            // 
            txtSale.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSale.Location = new Point(522, 136);
            txtSale.Margin = new Padding(3, 2, 3, 2);
            txtSale.Name = "txtSale";
            txtSale.ReadOnly = true;
            txtSale.Size = new Size(56, 32);
            txtSale.TabIndex = 4;
            txtSale.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(573, 138);
            label1.Name = "label1";
            label1.Size = new Size(29, 28);
            label1.TabIndex = 15;
            label1.Text = "%";
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.BackColor = Color.FromArgb(0, 125, 255);
            btnAddCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCustomer.ForeColor = Color.White;
            btnAddCustomer.Location = new Point(174, 179);
            btnAddCustomer.Margin = new Padding(3, 2, 3, 2);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(194, 36);
            btnAddCustomer.TabIndex = 16;
            btnAddCustomer.Text = "Thêm khách hàng mới";
            btnAddCustomer.UseVisualStyleBackColor = false;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // AddingBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 808);
            Controls.Add(btnAddCustomer);
            Controls.Add(btnExit);
            Controls.Add(btnSave);
            Controls.Add(label6);
            Controls.Add(dgvBillDetail);
            Controls.Add(btnAddProductToBill);
            Controls.Add(label5);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(txtSale);
            Controls.Add(label2);
            Controls.Add(cmbCustomer);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddingBill";
            Text = "Thêm hóa đơn bán";
            Load += AddingBill_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBillDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddProductToBill;
        private System.Windows.Forms.DataGridView dgvBillDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtSale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCustomer;
    }
}