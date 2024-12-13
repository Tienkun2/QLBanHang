namespace ShopManagement.Product
{
    partial class ViewingProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewingProduct));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btn_AddProduct = new Button();
            txtSearch = new TextBox();
            btn_Prev = new Button();
            btn_Next = new Button();
            lbl_PageInfo = new Label();
            flp_Products = new FlowLayoutPanel();
            cmbBrandFilter = new ComboBox();
            label2 = new Label();
            trackBarPrice = new TrackBar();
            label3 = new Label();
            lblPriceRange = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPrice).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(43, 101);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 125, 255);
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-3, -1);
            label1.Name = "label1";
            label1.Size = new Size(1214, 62);
            label1.TabIndex = 14;
            label1.Text = "Danh sách quần áo";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.BackColor = Color.FromArgb(0, 125, 255);
            btn_AddProduct.FlatStyle = FlatStyle.Flat;
            btn_AddProduct.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddProduct.ForeColor = Color.White;
            btn_AddProduct.Location = new Point(816, 101);
            btn_AddProduct.Margin = new Padding(3, 2, 3, 2);
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.Size = new Size(337, 60);
            btn_AddProduct.TabIndex = 11;
            btn_AddProduct.Text = "Nhập thêm quần/áo";
            btn_AddProduct.UseVisualStyleBackColor = false;
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HideSelection = false;
            txtSearch.Location = new Point(97, 101);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(249, 54);
            txtSearch.TabIndex = 10;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // btn_Prev
            // 
            btn_Prev.BackColor = Color.FromArgb(0, 125, 255);
            btn_Prev.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btn_Prev.ForeColor = Color.White;
            btn_Prev.Location = new Point(386, 858);
            btn_Prev.Name = "btn_Prev";
            btn_Prev.Size = new Size(129, 48);
            btn_Prev.TabIndex = 16;
            btn_Prev.Text = "Trước";
            btn_Prev.UseVisualStyleBackColor = false;
            btn_Prev.Click += btn_Prev_Click;
            // 
            // btn_Next
            // 
            btn_Next.BackColor = Color.FromArgb(0, 125, 255);
            btn_Next.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btn_Next.ForeColor = Color.White;
            btn_Next.Location = new Point(696, 858);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new Size(129, 48);
            btn_Next.TabIndex = 17;
            btn_Next.Text = "Sau";
            btn_Next.UseVisualStyleBackColor = false;
            btn_Next.Click += btn_Next_Click;
            // 
            // lbl_PageInfo
            // 
            lbl_PageInfo.AutoSize = true;
            lbl_PageInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl_PageInfo.Location = new Point(537, 864);
            lbl_PageInfo.Name = "lbl_PageInfo";
            lbl_PageInfo.Size = new Size(96, 37);
            lbl_PageInfo.TabIndex = 18;
            lbl_PageInfo.Text = "label2";
            // 
            // flp_Products
            // 
            flp_Products.BackColor = Color.White;
            flp_Products.BorderStyle = BorderStyle.FixedSingle;
            flp_Products.Font = new Font("Microsoft Sans Serif", 8.25F);
            flp_Products.Location = new Point(43, 302);
            flp_Products.Name = "flp_Products";
            flp_Products.Size = new Size(1110, 518);
            flp_Products.TabIndex = 19;
            // 
            // cmbBrandFilter
            // 
            cmbBrandFilter.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBrandFilter.FormattingEnabled = true;
            cmbBrandFilter.Location = new Point(138, 224);
            cmbBrandFilter.Name = "cmbBrandFilter";
            cmbBrandFilter.Size = new Size(151, 39);
            cmbBrandFilter.TabIndex = 20;
            cmbBrandFilter.SelectedIndexChanged += cmbBrandFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 125, 255);
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(43, 225);
            label2.Name = "label2";
            label2.Size = new Size(89, 38);
            label2.TabIndex = 21;
            label2.Text = "Brand";
            // 
            // trackBarPrice
            // 
            trackBarPrice.Location = new Point(960, 207);
            trackBarPrice.Maximum = 1000000;
            trackBarPrice.Minimum = 10000;
            trackBarPrice.Name = "trackBarPrice";
            trackBarPrice.Size = new Size(193, 56);
            trackBarPrice.TabIndex = 22;
            trackBarPrice.Value = 10000;
            trackBarPrice.Scroll += trackBarPrice_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 125, 255);
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(883, 222);
            label3.Name = "label3";
            label3.Size = new Size(59, 38);
            label3.TabIndex = 23;
            label3.Text = "Lọc";
            // 
            // lblPriceRange
            // 
            lblPriceRange.AutoSize = true;
            lblPriceRange.Location = new Point(983, 275);
            lblPriceRange.Name = "lblPriceRange";
            lblPriceRange.Size = new Size(0, 20);
            lblPriceRange.TabIndex = 24;
            // 
            // ViewingProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1215, 1016);
            Controls.Add(lblPriceRange);
            Controls.Add(label3);
            Controls.Add(trackBarPrice);
            Controls.Add(label2);
            Controls.Add(cmbBrandFilter);
            Controls.Add(flp_Products);
            Controls.Add(lbl_PageInfo);
            Controls.Add(btn_Next);
            Controls.Add(btn_Prev);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(btn_AddProduct);
            Controls.Add(txtSearch);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ViewingProduct";
            Text = "ViewingProduct";
            Load += ViewingProduct_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddProduct;
        private System.Windows.Forms.TextBox txtSearch;
        private Button btn_Prev;
        private Button btn_Next;
        private Label lbl_PageInfo;
        private ComboBox cmbBrandFilter;
        private Label label2;
        private Label label3;
        private Label lblPriceRange;
        internal TrackBar trackBarPrice;
    }
}