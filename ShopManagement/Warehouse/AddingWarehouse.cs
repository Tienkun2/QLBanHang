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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopManagement.Warehouse
{
    public partial class AddingWarehouse : Form
    {
        public AddingWarehouse()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox1.Enabled = false; // Alternatively, disable the textbox completely
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Retrieve values from the textboxes
            string name = textBox2.Text.Trim();    // Assuming textBox2 is for Warehouse Name
            string address = textBox3.Text.Trim(); // Assuming textBox3 is for Warehouse Address
            string phoneNumber = textBox4.Text.Trim(); // Assuming textBox4 is for Warehouse Phone Number
            string email = textBox5.Text.Trim();

            // Default stock value is 0
            int stock = 0; // Default value for stock

            // Validate that the name, address, phone number, and email are not empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập vào các trường dữ liệu.");
                return;
            }

            // Try parsing the stock value entered by the user
            if (!int.TryParse(textBox6.Text.Trim(), out stock))
            {
                // If parsing fails, stock remains 0. You could also prompt the user to enter a valid number.
                MessageBox.Show("Giá trị sức chứa lỗi. Sức chứa sẽ được đặt bằng 0.");
            }

            // Create the new Warehouse object
            var warehouse = new Models.Warehouse
            {
                Name = name,
                Address = address,
                Phone = phoneNumber,
                Email = email,
                Stock = stock
            };

            try
            {
                using (var context = new AppDbContext())
                {
                    // Add the warehouse object to the DbSet and save changes to the database
                    context.Warehouses.Add(warehouse);
                    context.SaveChanges();

                    MessageBox.Show("Warehouse added successfully!");
                    this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                    this.Close(); // Close the form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
