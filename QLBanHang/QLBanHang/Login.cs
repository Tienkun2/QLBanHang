using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLBanHang.Models;

namespace QLBanHang
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Đặt kiểu cửa sổ cố định không thể thay đổi kích thước
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Tắt các nút tối đa hóa và thu nhỏ
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Đặt kích thước cửa sổ cố định
            this.Size = new Size(900, 500);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            txtMatKhau.PasswordChar = '*';  // Mật khẩu hiển thị dưới dạng dấu *.

            // Kiểm tra nếu nhớ thông tin đăng nhập
            if (Properties.Settings.Default.RememberMe)
            {
                txtTaiKhoan.Text = Properties.Settings.Default.Username;
                txtMatKhau.Text = Properties.Settings.Default.Password;
                chkRememberMe.Checked = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string passWord = txtMatKhau.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QLBanHangEntities())
            {
                var account = db.Accounts.AsNoTracking().FirstOrDefault(a => a.Username == userName);
                if (account == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (account.Password == passWord) 
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Nếu RememberMe được chọn, lưu thông tin tài khoản và mật khẩu vào Settings
                    if (chkRememberMe.Checked)
                    {
                        Properties.Settings.Default.Username = userName;
                        Properties.Settings.Default.Password = passWord;  // Lưu mật khẩu trong Settings (nên mã hóa mật khẩu trước khi lưu)
                        Properties.Settings.Default.RememberMe = true;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        // Nếu không chọn RememberMe, xóa thông tin khỏi Settings
                        Properties.Settings.Default.RememberMe = false;
                        Properties.Settings.Default.Save();
                    }

                    // Mở form chính sau khi đăng nhập thành công
                    MainForm_ mainForm = new MainForm_();
                    mainForm.Show();
                    this.Hide();  // Ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


