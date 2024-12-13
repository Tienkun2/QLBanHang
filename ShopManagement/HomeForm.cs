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
    public partial class HomeForm : Form
    {
        private bool isAdmin;
        private int StaffId;

        // Constructor
        public HomeForm(bool isAdmin, string usernameCurrently, int staffid)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.StaffId = staffid;

            // Hiển thị tên người dùng
            label1.Text += usernameCurrently;

            // Kiểm tra quyền Admin để hiển thị các nút chức năng
            btnStaff.Visible = isAdmin;
            btnStatistic.Visible = isAdmin; // Thống kê chỉ dành cho Admin
        }

        // Phương thức để hiển thị form trong Panel
        public void ShowFormInPanel(Form form)
        {
            // Xóa nội dung hiện tại của Panel
            PanelForm.Controls.Clear();
            // Thiết lập các thuộc tính của form con
            form.TopLevel = false;    // Không cho form con là TopLevel (form độc lập)
            form.Dock = DockStyle.Fill; // Cho phép form lấp đầy panel
            PanelForm.Controls.Add(form);  // Thêm form vào Panel
            form.Show();                // Hiển thị form con
        }

        // Các sự kiện khi nhấn các nút chức năng
        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Product.ViewingProduct(isAdmin));
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Customer.ViewCustomer());
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Bill.ViewingBill(StaffId)); // StaffId cho phép lọc các hóa đơn của nhân viên hiện tại
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Statistics.ViewingStatictis()); // Thống kê chỉ dành cho Admin
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Warehouse.ViewingWarehouse(isAdmin));
        }

        private void btnImportBill_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ImportBill.ViewingImportBill(isAdmin));
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Staff.ViewingStaff());
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Brand.ViewingBrand(isAdmin));
        }

        // Đóng chương trình
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void PanelForm_Paint(object sender, PaintEventArgs e)
        {
            // Code vẽ trên panel nếu cần
        }
    }
}
