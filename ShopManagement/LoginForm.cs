using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement
{
    public partial class LoginForm : Form
    {
        public string usernameCurrently = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password, out bool isAdmin, out string usernameCurrently, out int staffid))
            {
                HomeForm homeForm = new HomeForm(isAdmin, usernameCurrently, staffid);
                homeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu. Vui lòng thử lại.");
            }
        }

        private bool AuthenticateUser(string username, string password, out bool isAdmin, out string usernameCurrently, out int staffid)
        {
            isAdmin = false;
            usernameCurrently = string.Empty;
            staffid = 0;

            try
            {
                using (var context = new AppDbContext())
                {
                    var user = context.Staff
                        .FirstOrDefault(s => s.Username == username && s.Password == password);

                    if (user != null)
                    {
                        usernameCurrently = user.Name;
                        isAdmin = user.RoleId == 1; // Kiểm tra RoleId để xác định quyền admin
                        staffid = user.StaffId;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}");
            }
            return false;
        }
    }
}
