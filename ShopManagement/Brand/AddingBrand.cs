using ShopManagement.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopManagement.Brand
{
    public partial class AddingBrand : Form
    {
        public AddingBrand()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox1.Enabled = false;
        }

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

            // Thêm thương hiệu mới vào DB
            using (var context = new AppDbContext())
            {
                var newBrand = new Models.Brand
                {
                    Name = name,
                    Address = address,
                    PhoneNumber = phoneNumber
                };

                // Thêm đối tượng vào DbSet và lưu thay đổi
                context.Brands.Add(newBrand);
                int result = context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Thêm thương hiệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đánh dấu form này đã thành công
                    this.Close(); // Đóng form
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
