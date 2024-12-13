namespace ShopManagement.Product
{
    partial class AddingProduct
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
            label4 = new Label();
            txtName = new TextBox();
            txtSize = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtQuantity = new TextBox();
            label3 = new Label();
            label5 = new Label();
            txtMaterial = new TextBox();
            label6 = new Label();
            txtPrice = new TextBox();
            cmbBrand = new ComboBox();
            button2 = new Button();
            btnAddProduct = new Button();
            groupBox1 = new GroupBox();
            clbSizes = new CheckedListBox();
            txtImagePath = new TextBox();
            btn_AddImage = new Button();
            label8 = new Label();
            btnDone = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(54, 215);
            label4.Name = "label4";
            label4.Size = new Size(125, 28);
            label4.TabIndex = 22;
            label4.Text = "Tên quần/ áo";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(185, 203);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(267, 40);
            txtName.TabIndex = 23;
            // 
            // txtSize
            // 
            txtSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSize.Location = new Point(972, 206);
            txtSize.Margin = new Padding(3, 2, 3, 2);
            txtSize.Multiline = true;
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(97, 118);
            txtSize.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(671, 206);
            label1.Name = "label1";
            label1.Size = new Size(75, 28);
            label1.TabIndex = 24;
            label1.Text = "Kích cỡ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(671, 374);
            label2.Name = "label2";
            label2.Size = new Size(122, 28);
            label2.TabIndex = 28;
            label2.Text = "Thương hiệu";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuantity.Location = new Point(185, 288);
            txtQuantity.Margin = new Padding(3, 2, 3, 2);
            txtQuantity.Multiline = true;
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(97, 40);
            txtQuantity.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(54, 288);
            label3.Name = "label3";
            label3.Size = new Size(92, 28);
            label3.TabIndex = 26;
            label3.Text = "Số lượng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(54, 365);
            label5.Name = "label5";
            label5.Size = new Size(81, 28);
            label5.TabIndex = 32;
            label5.Text = "Đơn giá";
            // 
            // txtMaterial
            // 
            txtMaterial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaterial.Location = new Point(802, 130);
            txtMaterial.Margin = new Padding(3, 2, 3, 2);
            txtMaterial.Multiline = true;
            txtMaterial.Name = "txtMaterial";
            txtMaterial.Size = new Size(267, 40);
            txtMaterial.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(671, 133);
            label6.Name = "label6";
            label6.Size = new Size(88, 28);
            label6.TabIndex = 30;
            label6.Text = "Chất liệu";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(185, 362);
            txtPrice.Margin = new Padding(3, 2, 3, 2);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(267, 40);
            txtPrice.TabIndex = 33;
            // 
            // cmbBrand
            // 
            cmbBrand.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBrand.FormattingEnabled = true;
            cmbBrand.Location = new Point(802, 366);
            cmbBrand.Margin = new Padding(3, 2, 3, 2);
            cmbBrand.Name = "cmbBrand";
            cmbBrand.Size = new Size(267, 36);
            cmbBrand.TabIndex = 34;
            cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlLightLight;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.WindowText;
            button2.Location = new Point(880, 559);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(237, 76);
            button2.TabIndex = 36;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.FromArgb(0, 125, 255);
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(394, 559);
            btnAddProduct.Margin = new Padding(3, 2, 3, 2);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(237, 76);
            btnAddProduct.TabIndex = 35;
            btnAddProduct.Text = "Thêm";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(clbSizes);
            groupBox1.Controls.Add(txtImagePath);
            groupBox1.Controls.Add(btn_AddImage);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbBrand);
            groupBox1.Controls.Add(txtSize);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtMaterial);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label6);
            groupBox1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(27, 15);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1124, 489);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // clbSizes
            // 
            clbSizes.FormattingEnabled = true;
            clbSizes.Location = new Point(802, 206);
            clbSizes.Name = "clbSizes";
            clbSizes.Size = new Size(164, 118);
            clbSizes.TabIndex = 38;
            clbSizes.ItemCheck += clbSizes_ItemCheck;
            // 
            // txtImagePath
            // 
            txtImagePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtImagePath.Location = new Point(319, 125);
            txtImagePath.Margin = new Padding(3, 2, 3, 2);
            txtImagePath.Multiline = true;
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(230, 40);
            txtImagePath.TabIndex = 37;
            // 
            // btn_AddImage
            // 
            btn_AddImage.Location = new Point(185, 120);
            btn_AddImage.Name = "btn_AddImage";
            btn_AddImage.Size = new Size(115, 48);
            btn_AddImage.TabIndex = 36;
            btn_AddImage.Text = "choose";
            btn_AddImage.UseVisualStyleBackColor = true;
            btn_AddImage.Click += btn_AddImage_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(54, 125);
            label8.Name = "label8";
            label8.Size = new Size(95, 28);
            label8.TabIndex = 35;
            label8.Text = "Chọn ảnh";
            // 
            // btnDone
            // 
            btnDone.BackColor = Color.FromArgb(255, 255, 128);
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDone.ForeColor = Color.Black;
            btnDone.Location = new Point(637, 559);
            btnDone.Margin = new Padding(3, 2, 3, 2);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(237, 76);
            btnDone.TabIndex = 38;
            btnDone.Text = "Xong";
            btnDone.UseVisualStyleBackColor = false;
            btnDone.Click += btnDone_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddingProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1182, 691);
            Controls.Add(btnDone);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(btnAddProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddingProduct";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm sản phẩm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDone;
        private Button btn_AddImage;
        private Label label8;
        private OpenFileDialog openFileDialog1;
        private TextBox txtImagePath;
        private CheckedListBox clbSizes;
    }
}