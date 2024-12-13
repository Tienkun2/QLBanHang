using ShopManagement.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagement.Brand
{
    public partial class EditBrand : Form
    {
        private int brandId; // Biến lưu trữ ID thương hiệu đang sửa

        // Constructor nhận vào ID thương hiệu cần sửa
        public EditBrand(int brandId)
        {
            InitializeComponent();
            this.brandId = brandId;

            // Tắt chế độ chỉnh sửa cho mã thương hiệu (ID)
            textBox1.ReadOnly = true;
            textBox1.Enabled = false;

            LoadBrandDetails();
        }

        // Hàm tải thông tin thương hiệu từ DB
        private void LoadBrandDetails()
        {
            using (var context = new AppDbContext())
            {
                var brand = context.Brands.FirstOrDefault(b => b.BrandId == brandId); // Tìm thương hiệu theo ID

                if (brand != null)
                {
                    // Điền thông tin vào các TextBox
                    textBox1.Text = brand.BrandId.ToString(); // Hoặc có thể thay bằng Name nếu dùng tên
                    textBox2.Text = brand.Name;
                    textBox3.Text = brand.Address;
                    textBox4.Text = brand.PhoneNumber;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thương hiệu này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        // Xử lý lưu thông tin sửa đổi
        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();      // Tên thương hiệu
            string address = textBox3.Text.Trim();   // Địa chỉ thương hiệu
            string phoneNumber = textBox4.Text.Trim(); // Số điện thoại

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật thông tin thương hiệu
            using (var context = new AppDbContext())
            {
                var brand = context.Brands.FirstOrDefault(b => b.BrandId == brandId); // Tìm thương hiệu theo ID

                if (brand != null)
                {
                    // Cập nhật thông tin thương hiệu
                    brand.Name = name;
                    brand.Address = address;
                    brand.PhoneNumber = phoneNumber;

                    // Lưu thay đổi vào DB
                    int result = context.SaveChanges();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thương hiệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Đánh dấu form này đã thành công
                        this.Close(); // Đóng form
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thương hiệu này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }
    }
}
