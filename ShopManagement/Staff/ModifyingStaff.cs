using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShopManagement.Staff
{

    public partial class ModifyingStaff : Form
    {
        public event Action StaffUpdated;
        private int StaffId;

        public ModifyingStaff()
        {
            InitializeComponent();
            LoadRoles();
        }

        // Tải danh sách vai trò từ cơ sở dữ liệu
        private void LoadRoles()
        {
            using (var context = new AppDbContext())
            {
                var roles = context.Roles.ToList();
                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleId";
            }
        }

        // Tải dữ liệu nhân viên từ cơ sở dữ liệu dựa trên StaffId
        public void LoadStaffData(int staffId)
        {
            StaffId = staffId; // Lưu StaffId để sử dụng khi cập nhật

            using (var context = new AppDbContext())
            {
                var staff = context.Staff.FirstOrDefault(s => s.StaffId == StaffId);
                if (staff != null)
                {
                    // Điền dữ liệu vào các TextBox
                    txtName.Text = staff.Name;
                    txtPhoneNumber.Text = staff.PhoneNumber;
                    txtEmail.Text = staff.Email;
                    txtAddress.Text = staff.Address;
                    cmbRole.SelectedValue = staff.RoleId;
                    txtUsername.Text = staff.Username;
                    txtPassword.Text = staff.Password;
                }
            }
        }

        // Lưu thông tin nhân viên khi nhấn nút Lưu
        private void btn_Save_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            int roleId = (int)cmbRole.SelectedValue;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            if (StaffId > 0)
            {
                try
                {
                    using (var context = new AppDbContext())
                    {
                        // Tìm nhân viên trong cơ sở dữ liệu
                        var staff = context.Staff.FirstOrDefault(s => s.StaffId == StaffId);
                        if (staff != null)
                        {
                            // Cập nhật thông tin nhân viên
                            staff.Name = name;
                            staff.PhoneNumber = phoneNumber;
                            staff.Email = email;
                            staff.Address = address;
                            staff.RoleId = roleId;
                            staff.Username = username;
                            staff.Password = password;

                            // Lưu thay đổi vào cơ sở dữ liệu
                            context.SaveChanges();

                            MessageBox.Show("Đã cập nhật nhân viên thành công.");

                            // Kích hoạt sự kiện StaffUpdated để cập nhật DataGridView trên form chính
                            StaffUpdated?.Invoke();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên để cập nhật.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật nhân viên: {ex.Message}");
                }
                // Đóng form sau khi cập nhật thành công
                this.Close();
            }
        }

        private void ModifyingStaff_Load(object sender, EventArgs e)
        {
            LoadStaffData(StaffId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
