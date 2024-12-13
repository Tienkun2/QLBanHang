using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShopManagement.Customer;
using ShopManagement;

namespace ShopManagement.Bill
{
    public partial class AddingBill : Form
    {
        private int StaffId;
        public List<Models.AddProduct> addProducts { get; private set; } = new List<Models.AddProduct>();

        public AddingBill(int staffid)
        {
            StaffId = staffid;
            InitializeComponent();
        }

        private void AddingBill_Load(object sender, EventArgs e)
        {
            LoadCmbCustomer();
            StyleSet.DataGridViewStyle(dgvBillDetail);
            LoadDGV();
        }

        private void LoadDGV()
        {
            if (dgvBillDetail.Columns["WarehouseProduct_Id"] != null) dgvBillDetail.Columns["WarehouseProduct_Id"].Visible = false;
            if (dgvBillDetail.Columns["ProductId"] != null) dgvBillDetail.Columns["ProductId"].HeaderText = "Mã quần áo";
            if (dgvBillDetail.Columns["ProductName"] != null) dgvBillDetail.Columns["ProductName"].HeaderText = "Tên quần áo";
            if (dgvBillDetail.Columns["Size"] != null) dgvBillDetail.Columns["Size"].HeaderText = "Kích cỡ";
            if (dgvBillDetail.Columns["Price"] != null) dgvBillDetail.Columns["Price"].HeaderText = "Giá bán";
            if (dgvBillDetail.Columns["Quanity"] != null) dgvBillDetail.Columns["Quanity"].HeaderText = "Số lượng";
            if (dgvBillDetail.Columns["Total"] != null) dgvBillDetail.Columns["Total"].HeaderText = "Tổng tiền";
        }

        private void LoadCmbCustomer()
        {
            using (var context = new AppDbContext())
            {
                var customers = context.Customers.Select(c => new { c.CustomerId, c.Name }).ToList();
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "CustomerId";
                cmbCustomer.SelectedIndex = customers.Count - 1;
            }

            if (cmbCustomer.Items.Count > 0)
            {
                CalculationDiscount();
            }
        }

        private void LoadBillDetail()
        {
            dgvBillDetail.DataSource = null;
            dgvBillDetail.DataSource = addProducts;
            LoadDGV();
        }

        private void btnAddProductToBill_Click(object sender, EventArgs e)
        {
            AddProductToBill addProductToBill = new AddProductToBill();
            var result = addProductToBill.ShowDialog();
            if (result == DialogResult.OK)
            {
                addProducts.AddRange(addProductToBill.addProducts);
                MessageBox.Show("Đã thêm sản phẩm vào danh sách hóa đơn.");
                LoadBillDetail();
                CalculateTotalAmount();
            }
        }

        private void CalculationDiscount()
        {
            // Lấy đối tượng Customer từ SelectedItem
            var selectedCustomer = cmbCustomer.SelectedItem as dynamic;

            if (selectedCustomer != null)
            {
                // Lấy CustomerId từ đối tượng đã được chọn
                int customerID = selectedCustomer.CustomerId;

                using (var context = new AppDbContext())
                {
                    // Tính toán số lượng hóa đơn của khách hàng
                    int count = context.Bills.Count(b => b.CustomerId == customerID);

                    // Nếu khách hàng có ít nhất một hóa đơn trước đó, giảm giá 10%, nếu không thì là 0%
                    txtSale.Text = count > 0 ? "10" : "0";
                }
            }
        }


        private void CalculateTotalAmount()
        {
            decimal totalAmount = addProducts.Sum(item => item.Total);

            int sale;
            if (int.TryParse(txtSale.Text, out sale))
            {
                totalAmount = totalAmount * (1 - (sale / 100.0m));
            }
            txtTotal.Text = totalAmount.ToString("N2");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Staff_Id = StaffId;
            var selectedCustomer = cmbCustomer.SelectedItem as dynamic;
            int Customer_Id = selectedCustomer?.CustomerId ?? 0;  // Lấy CustomerId từ SelectedItem
            decimal SalesPercent = Convert.ToDecimal(txtSale.Text.Trim());
            DateTime CreatedDate = dateTimePicker1.Value;
            decimal Total = Convert.ToDecimal(txtTotal.Text.Trim());

            if (Customer_Id == 0 || Total == 0 || CreatedDate == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            using (var context = new AppDbContext())
            {
                var newBill = new Models.Bill
                {
                    StaffId = Staff_Id,
                    CustomerId = Customer_Id,
                    SalesPercent = SalesPercent,
                    CreatedDate = CreatedDate,
                    Total = Total
                };

                // Thêm mới hóa đơn
                context.Bills.Add(newBill);
                context.SaveChanges();

                foreach (var product in addProducts)
                {
                    // Thêm chi tiết hóa đơn
                    var billDetail = new BillDetail
                    {
                        BillId = newBill.BillId,
                        ProductId = product.ProductId,
                        Quantity = product.Quanity
                    };

                    context.BillDetails.Add(billDetail);

                    // Cập nhật số lượng sản phẩm trong kho
                    var productToUpdate = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                    if (productToUpdate != null)
                    {
                        productToUpdate.Quantity -= product.Quanity;
                    }
                }

                context.SaveChanges();

                MessageBox.Show("Đã thêm hóa đơn thành công.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculationDiscount();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            var result = addCustomer.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadCmbCustomer();
            }
        }
    }
}
