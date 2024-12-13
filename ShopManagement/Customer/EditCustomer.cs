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

namespace ShopManagement.Customer
{
    public partial class EditCustomer : Form
    {
        private int customerId;
        public EditCustomer(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
            LoadCustomerData();
        }
        private void LoadCustomerData()
        {
            using (var context = new AppDbContext())
            {
                // Truy vấn khách hàng theo ID
                var customer = context.Customers
                    .FirstOrDefault(c => c.CustomerId == customerId);

                if (customer != null)
                {
                    // Điền dữ liệu vào các trường trong form
                    txtName.Text = customer.Name;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                    txtEmail.Text = customer.Email;
                    dtp_CreateDate.Value = customer.CreatedDate;
                }
            }
        }


        private void EditCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                // Lấy khách hàng từ cơ sở dữ liệu theo ID
                var customer = context.Customers
                    .FirstOrDefault(c => c.CustomerId == customerId);

                if (customer != null)
                {
                    // Cập nhật các giá trị của khách hàng
                    customer.Name = txtName.Text;
                    customer.PhoneNumber = txtPhoneNumber.Text;
                    customer.Email = txtEmail.Text;
                    customer.CreatedDate = dtp_CreateDate.Value;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    MessageBox.Show("Customer updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}