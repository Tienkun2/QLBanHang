namespace ShopManagement.Product
{
    partial class ProductCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lblProductName = new Label();
            lblPrice = new Label();
            lblSize = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProductName.ForeColor = Color.Black;
            lblProductName.Location = new Point(15, 160);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(148, 28);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(0, 122, 204);
            lblPrice.Location = new Point(15, 215);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 23);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new Font("Segoe UI", 10F);
            lblSize.ForeColor = Color.Gray;
            lblSize.Location = new Point(15, 190);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(40, 23);
            lblSize.TabIndex = 3;
            lblSize.Text = "Size";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 255);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblProductName);
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(lblSize);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(215, 252);
            panel1.TabIndex = 0;
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ProductCard";
            Size = new Size(215, 252);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private PictureBox pictureBox1;
        private Label lblProductName;
        private Label lblPrice;
        private Label lblSize;
        private Panel panel1;
    }
}
