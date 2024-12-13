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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var customer = new Models.Customer
                {
                    Name = txtName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Email = txtEmail.Text,
                    CreatedDate = dtp_CreateDate.Value
                };

                context.Customers.Add(customer);
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}