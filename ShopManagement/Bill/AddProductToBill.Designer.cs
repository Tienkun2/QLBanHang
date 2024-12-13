namespace ShopManagement.Bill
{
    partial class AddProductToBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductToBill));
            cmbWarehouse = new ComboBox();
            label1 = new Label();
            dgvProducts = new DataGridView();
            btn_Save = new Button();
            button2 = new Button();
            txtQuanity = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSellingPrice = new TextBox();
            pictureBox1 = new PictureBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(413, 91);
            cmbWarehouse.Margin = new Padding(3, 2, 3, 2);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(168, 33);
            cmbWarehouse.TabIndex = 0;
            cmbWarehouse.SelectedIndexChanged += cmbWarehouse_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(315, 98);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 1;
            label1.Text = "Nhà kho :";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 151);
            dgvProducts.Margin = new Padding(3, 2, 3, 2);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.RowTemplate.Height = 28;
            dgvProducts.Size = new Size(1160, 434);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // btn_Save
            // 
            btn_Save.BackColor = Color.FromArgb(0, 125, 255);
            btn_Save.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Save.ForeColor = Color.White;
            btn_Save.Location = new Point(809, 665);
            btn_Save.Margin = new Padding(3, 2, 3, 2);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(164, 72);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "Lưu";
            btn_Save.UseVisualStyleBackColor = false;
            btn_Save.Click += btn_Save_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 125, 255);
            button2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(990, 665);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(164, 72);
            button2.TabIndex = 4;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtQuanity
            // 
            txtQuanity.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuanity.Location = new Point(1065, 91);
            txtQuanity.Margin = new Padding(3, 2, 3, 2);
            txtQuanity.Name = "txtQuanity";
            txtQuanity.Size = new Size(89, 32);
            txtQuanity.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(963, 98);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 6;
            label2.Text = "Số lượng :";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 125, 255);
            label3.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(11, 8);
            label3.Name = "label3";
            label3.Size = new Size(1161, 56);
            label3.TabIndex = 7;
            label3.Text = "Thêm sản phẩm vào hóa đơn";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(587, 98);
            label4.Name = "label4";
            label4.Size = new Size(135, 25);
            label4.TabIndex = 9;
            label4.Text = "Nhập giá bán :";
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSellingPrice.Location = new Point(728, 91);
            txtSellingPrice.Margin = new Padding(3, 2, 3, 2);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(229, 32);
            txtSellingPrice.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 79);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HideSelection = false;
            txtSearch.Location = new Point(60, 79);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(249, 54);
            txtSearch.TabIndex = 21;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // AddProductToBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 808);
            Controls.Add(pictureBox1);
            Controls.Add(txtSearch);
            Controls.Add(label4);
            Controls.Add(txtSellingPrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtQuanity);
            Controls.Add(button2);
            Controls.Add(btn_Save);
            Controls.Add(dgvProducts);
            Controls.Add(cmbWarehouse);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddProductToBill";
            Text = "AddProductToBill";
            Load += AddProductToBill_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtQuanity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private PictureBox pictureBox1;
        private TextBox txtSearch;
    }
}