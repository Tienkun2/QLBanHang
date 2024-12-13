using ShopManagement;
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

namespace ShopManagement.Customer
{
    public partial class ViewCustomer : Form
    {
        public ViewCustomer()
        {
            InitializeComponent();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            StyleSet.DataGridViewStyle(dgv_ViewCus);
            Load_Staff();
            dgv_ViewCus.Columns["CustomerId"].HeaderText = "Mã khách hàng";
            dgv_ViewCus.Columns["Name"].HeaderText = " Họ Tên";
            dgv_ViewCus.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dgv_ViewCus.Columns["Email"].HeaderText = "Email";
            dgv_ViewCus.Columns["CreatedDate"].HeaderText = "Ngày tạo";
        }
        private void Load_Staff()
        {
            using (var context = new AppDbContext())
            {
                var customers = context.Customers
                    .Select(c => new
                    {
                        c.CustomerId,
                        c.Name,
                        c.PhoneNumber,
                        c.Email,
                        c.CreatedDate
                    })
                    .ToList();

                dgv_ViewCus.DataSource = customers;
            }
        }



        private void btn_AddCus_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomerForm = new AddCustomer();
            if (addCustomerForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh data grid view after adding a new customer
                Load_Staff();
            }
        }

        private void btn_UpdateCus_Click(object sender, EventArgs e)
        {
            if (dgv_ViewCus.CurrentRow == null) return;

            int customerId = Convert.ToInt32(dgv_ViewCus.CurrentRow.Cells["CustomerId"].Value);

            using (var context = new AppDbContext())
            {
                var customer = context.Customers.Find(customerId);
                if (customer != null)
                {
                    EditCustomer editForm = new EditCustomer(customerId);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        context.SaveChanges(); // Lưu thay đổi sau khi sửa
                        Load_Staff();
                    }
                }
            }
        }


        private void btn_DeleteCus_Click(object sender, EventArgs e)
        {
            if (dgv_ViewCus.CurrentRow == null) return;

            int customerId = Convert.ToInt32(dgv_ViewCus.CurrentRow.Cells["CustomerId"].Value);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new AppDbContext())
                {
                    var customer = context.Customers.Find(customerId);
                    if (customer != null)
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges(); // Lưu thay đổi
                        Load_Staff();
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim().ToLower();

            using (var context = new AppDbContext())
            {
                // Truy vấn danh sách khách hàng và lọc theo từ khóa tìm kiếm
                var customers = context.Customers
                    .Where(c => c.Name.ToLower().Contains(searchKeyword) ||
                                c.PhoneNumber.Contains(searchKeyword) ||
                                c.Email.ToLower().Contains(searchKeyword))
                    .Select(c => new
                    {
                        c.CustomerId,
                        c.Name,
                        c.PhoneNumber,
                        c.Email,
                        c.CreatedDate
                    })
                    .ToList();

                dgv_ViewCus.DataSource = customers;
            }
        }

    }
}



