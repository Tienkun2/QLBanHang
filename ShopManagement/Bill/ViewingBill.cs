using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShopManagement;
using ShopManagement.Bill;
using ShopManagement.Models;

namespace ShopManagement.Bill
{
    public partial class ViewingBill : Form
    {
        private List<(int ProductId, int Quantity)> billDetailsList = new List<(int ProductId, int Quantity)>();
        private int StaffId;

        public ViewingBill(int staffid)
        {
            StaffId = staffid;
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim().ToLower();

            using (var context = new AppDbContext())
            {
                // Truy vấn danh sách hóa đơn mà không dùng ToLower trong LINQ
                var bills = context.Bills
                    .Join(context.Staff, b => b.StaffId, s => s.StaffId, (b, s) => new { b, s })
                    .Join(context.Customers, bs => bs.b.CustomerId, c => c.CustomerId, (bs, c) => new
                    {
                        bs.b.BillId,
                        StaffName = bs.s.Name,
                        CustomerName = c.Name,
                        bs.b.SalesPercent,
                        bs.b.CreatedDate,
                        bs.b.Total
                    })
                    .ToList()  // Thực hiện truy vấn trước khi lọc theo từ khóa
                    .Where(b => b.CustomerName.ToLower().Contains(searchKeyword) ||
                                b.StaffName.ToLower().Contains(searchKeyword) ||
                                b.CreatedDate.ToString("yyyy-MM-dd").Contains(searchKeyword))
                    .ToList();

                dgv_Bill.DataSource = bills;
            }
        }


        private void ViewingBill_Load(object sender, EventArgs e)
        {
            StyleSet.DataGridViewStyle(dgv_Bill);
            Load_Bill();

            if (dgv_Bill.Columns["BillId"] != null) dgv_Bill.Columns["BillId"].HeaderText = "Mã hóa đơn";
            if (dgv_Bill.Columns["StaffName"] != null) dgv_Bill.Columns["StaffName"].HeaderText = "Tên nhân viên";
            if (dgv_Bill.Columns["CustomerName"] != null) dgv_Bill.Columns["CustomerName"].HeaderText = "Tên khách hàng";
            if (dgv_Bill.Columns["SalesPercent"] != null) dgv_Bill.Columns["SalesPercent"].HeaderText = "Chiết khấu";
            if (dgv_Bill.Columns["CreatedDate"] != null) dgv_Bill.Columns["CreatedDate"].HeaderText = "Ngày tạo";
            if (dgv_Bill.Columns["Total"] != null) dgv_Bill.Columns["Total"].HeaderText = "Tổng hóa đơn";
        }

        private void Load_Bill()
        {
            using (var context = new AppDbContext())
            {
                var bills = context.Bills
                    .Join(context.Staff, b => b.StaffId, s => s.StaffId, (b, s) => new { b, s })
                    .Join(context.Customers, bs => bs.b.CustomerId, c => c.CustomerId, (bs, c) => new
                    {
                        bs.b.BillId,
                        StaffName = bs.s.Name,
                        CustomerName = c.Name,
                        bs.b.SalesPercent,
                        bs.b.CreatedDate,
                        bs.b.Total
                    }).ToList();

                dgv_Bill.DataSource = bills;
            }
        }

        private int GetCustomerIdByName(string customerName)
        {
            using (var context = new AppDbContext())
            {
                var customer = context.Customers
                    .Where(c => c.Name == customerName)
                    .FirstOrDefault();

                return customer?.CustomerId ?? -1;
            }
        }

        private void btn_DeleteBill_Click(object sender, EventArgs e)
        {
            if (dgv_Bill.CurrentRow == null) return;

            int billId = Convert.ToInt32(dgv_Bill.CurrentRow.Cells["BillId"].Value);
            string customerName = dgv_Bill.CurrentRow.Cells["CustomerName"].Value.ToString();

            int customerId = GetCustomerIdByName(customerName);
            if (customerId == -1)
            {
                MessageBox.Show("Không thể tìm thấy thông tin khách hàng.");
                return;
            }

            using (var context = new AppDbContext())
            {
                var billCount = context.Bills
                    .Where(b => b.CustomerId == customerId && b.BillId != billId)
                    .Count();

                if (billCount > 0)
                {
                    DeleteBillAndDetails(billId, context);
                    MessageBox.Show("Hóa đơn đã bị xóa.");
                }
                else
                {
                    DeleteBillAndDetails(billId, context);
                    var customer = context.Customers.Find(customerId);
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                    MessageBox.Show("Khách hàng và các dữ liệu liên quan đã bị xóa.");
                }

                Load_Bill();
            }
        }

        private void DeleteBillAndDetails(int billId, AppDbContext context)
        {
            var billDetails = billDetailsList.Where(b => b.ProductId != 0).ToList();

            if (billDetails.Count > 0)
            {
                StringBuilder productList = new StringBuilder();
                foreach (var detail in billDetails)
                {
                    productList.AppendLine($"ProductId: {detail.ProductId}, Quantity: {detail.Quantity}");
                }
                MessageBox.Show("Các mã sản phẩm trong hóa đơn:\n" + productList.ToString(), "Thông tin sản phẩm");

                foreach (var detail in billDetails)
                {
                    int productId = detail.ProductId;
                    int quantity = detail.Quantity;

                    // Update Product quantity
                    var product = context.Products.Find(productId);
                    if (product != null)
                    {
                        product.Quantity += quantity;
                    }

                    // Update WarehouseProduct quantity if exists
                    var warehouseProduct = context.WarehouseProducts
                        .Where(wp => wp.ProductId == productId)
                        .FirstOrDefault();

                    if (warehouseProduct != null)
                    {
                        warehouseProduct.Quantity += quantity;
                    }
                }

                // Remove BillDetails and Bill
                var billDetailsToDelete = context.BillDetails
                    .Where(bd => bd.BillId == billId)
                    .ToList();

                context.BillDetails.RemoveRange(billDetailsToDelete);

                var billToDelete = context.Bills.Find(billId);
                if (billToDelete != null)
                {
                    context.Bills.Remove(billToDelete);
                }

                context.SaveChanges();
                MessageBox.Show("Hóa đơn và các chi tiết đã bị xóa, số lượng sản phẩm đã được cập nhật lại.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm trong hóa đơn bán này.");
            }
        }

        private void btn_AddBill_Click(object sender, EventArgs e)
        {
            AddingBill addingBill = new AddingBill(StaffId);
            var result = addingBill.ShowDialog();
            if (result == DialogResult.OK)
            {
                Load_Bill();
            }
        }

        private void dgv_Bill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_Bill.Rows[e.RowIndex];
                int billId = Convert.ToInt32(selectedRow.Cells[0].Value);
                new ViewingBillDetail(billId).ShowDialog();
            }
        }

        private int currentBillId = -1;

        private void LoadBillDetails(int billId)
        {
            billDetailsList.Clear();

            using (var context = new AppDbContext())
            {
                var billDetails = context.BillDetails
                    .Where(bd => bd.BillId == billId)
                    .Select(bd => new { bd.ProductId, bd.Quantity })
                    .ToList();

                foreach (var detail in billDetails)
                {
                    billDetailsList.Add((detail.ProductId, detail.Quantity));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (billDetailsList.Count > 0)
            {
                StringBuilder productList = new StringBuilder();

                foreach (var detail in billDetailsList)
                {
                    productList.AppendLine($"Mã sản phẩm: {detail.ProductId}, số lượng: {detail.Quantity}");
                }

                MessageBox.Show("Danh sách sản phẩm trong hóa đơn bán:\n" + productList.ToString(), "Thông tin hóa đơn bán");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm cho hóa đơn đã chọn.");
            }
        }

        private void dgv_Bill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentBillId = Convert.ToInt32(dgv_Bill.Rows[e.RowIndex].Cells["BillId"].Value);
                LoadBillDetails(currentBillId);
            }
        }
    }
}
