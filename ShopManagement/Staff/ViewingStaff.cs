using ShopManagement;
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

namespace ShopManagement.Staff
{
    public partial class ViewingStaff : Form
    {
        public ViewingStaff()
        {
            InitializeComponent();
        }

        private void ViewingStaff_Load(object sender, EventArgs e)
        {
            StyleSet.DataGridViewStyle(dgv_ViewStaff);
            Load_Staff();  // Tải thông tin nhân viên khi form tải

            // Đặt tên hiển thị cho các cột trong DataGridView
            dgv_ViewStaff.Columns["StaffId"].HeaderText = "Mã nhân viên";
            dgv_ViewStaff.Columns["Name"].HeaderText = "Họ và tên";
            dgv_ViewStaff.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgv_ViewStaff.Columns["Password"].HeaderText = "Mật khẩu";
            dgv_ViewStaff.Columns["RoleName"].HeaderText = "Vai trò";
            dgv_ViewStaff.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dgv_ViewStaff.Columns["Email"].HeaderText = "Email";
            dgv_ViewStaff.Columns["Address"].HeaderText = "Địa chỉ";
        }


        private void Load_Staff()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var staffList = (from s in context.Staff
                                     join r in context.Roles on s.RoleId equals r.RoleId
                                     select new
                                     {
                                         s.StaffId,
                                         s.Name,
                                         s.PhoneNumber,
                                         s.Email,
                                         s.Address,
                                         RoleName = r.RoleName,
                                         s.Username,
                                         s.Password
                                     }).ToList();

                    // Đảm bảo rằng các giá trị null được xử lý
                    //foreach (var staff in staffList)
                    //{
                    //    staff.Address = staff.Address ?? "Không có địa chỉ";
                    //    staff.PhoneNumber = staff.PhoneNumber ?? "Không có số điện thoại";
                    //    staff.Email = staff.Email ?? "Không có email";
                    //}

                    // Chuyển dữ liệu vào DataGridView
                    dgv_ViewStaff.DataSource = staffList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn dữ liệu: {ex.Message}");
            }
        }

        private void btn_AddStaff_Click(object sender, EventArgs e)
        {
            AddingStaff addingStaff = new AddingStaff();
            addingStaff.StaffAdded += () =>
            {
                Load_Staff();
            };

            addingStaff.Show();
        }

        private void btn_UpdateStaff_Click(object sender, EventArgs e)
        {
            if (dgv_ViewStaff.SelectedRows.Count > 0)
            {
                int staffId = Convert.ToInt32(dgv_ViewStaff.SelectedRows[0].Cells["StaffId"].Value);

                using (var context = new AppDbContext())
                {
                    var staff = context.Staff.FirstOrDefault(s => s.StaffId == staffId);

                    if (staff != null)
                    {
                        ModifyingStaff modifyForm = new ModifyingStaff();
                        modifyForm.LoadStaffData(staff.StaffId); // Truyền đối tượng Staff

                        modifyForm.StaffUpdated += () =>
                        {
                            Load_Staff(); // Tải lại danh sách nhân viên sau khi sửa
                        };

                        modifyForm.ShowDialog(); // Hiển thị form sửa nhân viên
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để sửa.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }


        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ViewStaff.SelectedRows.Count > 0)
            {
                int staffId = Convert.ToInt32(dgv_ViewStaff.SelectedRows[0].Cells["StaffId"].Value);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new AppDbContext())
                        {
                            var staffToDelete = context.Staff.FirstOrDefault(s => s.StaffId == staffId);

                            if (staffToDelete != null)
                            {
                                context.Staff.Remove(staffToDelete);
                                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                            }
                        }

                        Load_Staff();
                        MessageBox.Show("Đã xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim().ToLower(); // Lấy từ khóa tìm kiếm và chuyển thành chữ thường

            using (var context = new AppDbContext())
            {
                // Truy vấn danh sách nhân viên và lọc theo từ khóa tìm kiếm
                var staffList = (from s in context.Staff
                                 join r in context.Roles on s.RoleId equals r.RoleId
                                 where s.Name.ToLower().Contains(searchKeyword) || // Tìm kiếm theo Tên nhân viên
                                       s.PhoneNumber.ToLower().Contains(searchKeyword) || // Tìm kiếm theo số điện thoại
                                       s.Email.ToLower().Contains(searchKeyword) || // Tìm kiếm theo email
                                       r.RoleName.ToLower().Contains(searchKeyword) // Tìm kiếm theo vai trò
                                 select new
                                 {
                                     s.StaffId,
                                     s.Name,
                                     s.PhoneNumber,
                                     s.Email,
                                     s.Address,
                                     RoleName = r.RoleName,
                                     s.Username,
                                     s.Password
                                 }).ToList();

                // Cập nhật DataGridView với kết quả tìm kiếm
                dgv_ViewStaff.DataSource = staffList;
            }
        }

    }
}
