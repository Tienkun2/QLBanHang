using ShopManagement.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagement.Staff
{
    public partial class AddingStaff : Form
    {
        public event Action StaffAdded;

        public AddingStaff()
        {
            InitializeComponent();
            LoadRoles(); // Nạp các vai trò vào ComboBox
        }

        private void LoadRoles()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var roles = context.Roles.Select(r => new
                    {
                        r.RoleId,
                        r.RoleName
                    }).ToList();

                    cmbRole.DataSource = roles;
                    cmbRole.DisplayMember = "RoleName";  // Hiển thị tên vai trò
                    cmbRole.ValueMember = "RoleId";      // Giá trị là RoleId
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải vai trò: {ex.Message}");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string name = txtName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            int roleId = (int)cmbRole.SelectedValue;

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra trùng lặp tên đăng nhập
            try
            {
                using (var context = new AppDbContext())
                {
                    var existingUser = context.Staff.FirstOrDefault(s => s.Username == username);
                    if (existingUser != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tên đăng nhập: {ex.Message}");
                return;
            }

            try
            {
                // Tạo đối tượng nhân viên mới
                using (var context = new AppDbContext())
                {
                    var newStaff = new Models.Staff
                    {
                        Name = name,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        Address = address,
                        Username = username,
                        Password = password,
                        RoleId = roleId
                    };

                    // Thêm nhân viên vào DbSet
                    context.Staff.Add(newStaff);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    MessageBox.Show("Đã thêm nhân viên thành công.");

                    // Kích hoạt sự kiện StaffAdded để cập nhật DataGridView trên form chính
                    StaffAdded?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}");
            }

            // Xóa các trường nhập liệu để chuẩn bị cho lần nhập tiếp theo
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            txtName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
