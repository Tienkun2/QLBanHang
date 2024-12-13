using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement.Product
{
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        public void SetProduct(Models.Product product)
        {
            // Tạo đường dẫn đầy đủ tới ảnh từ thư mục images/product
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), product.ImageUrl);

            // Kiểm tra nếu ảnh tồn tại tại đường dẫn
            if (!string.IsNullOrEmpty(product.ImageUrl) && System.IO.File.Exists(imagePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(imagePath); // Tải ảnh vào pictureBox
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi khi tải ảnh, hiển thị ảnh mặc định và thông báo lỗi
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Sử dụng ảnh mặc định từ thư mục images của dự án
                    string defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", "FFFF00.jpg");
                    if (File.Exists(defaultImagePath))
                    {
                        pictureBox1.Image = Image.FromFile(defaultImagePath);
                    }
                    else
                    {
                        MessageBox.Show("Ảnh mặc định không tìm thấy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                // Nếu không có ảnh, hiển thị ảnh mặc định
                string defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", "FFFF00.jpg");
                if (File.Exists(defaultImagePath))
                {
                    pictureBox1.Image = Image.FromFile(defaultImagePath);
                }
                else
                {
                    MessageBox.Show("Ảnh mặc định không tìm thấy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Gán thông tin sản phẩm vào các điều khiển khác
            lblProductName.Text = product.ProductName;
            lblPrice.Text = $"Giá: {product.Price:N0}₫";
            lblSize.Text = $"Kích cỡ: {product.Size}";
            //lblMaterial.Text = $"Chất liệu: {product.Material}";
        }
    }
}
