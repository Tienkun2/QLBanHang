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

namespace ShopManagement.Bill
{
    public partial class ViewingBillDetail : Form
    {
        private int BillId;
        public ViewingBillDetail(int billid)
        {
            BillId = billid;
            InitializeComponent();
        }
        private void LoadBillDetail()
        {
            using (var context = new AppDbContext()) // Sử dụng DbContext
            {
                // Lấy thông tin hóa đơn, nhân viên và khách hàng
                var bill = (from b in context.Bills
                            join s in context.Staff on b.StaffId equals s.StaffId
                            join c in context.Customers on b.CustomerId equals c.CustomerId
                            where b.BillId == BillId
                            select new
                            {
                                StaffName = s.Name,
                                CustomerName = c.Name,
                                b.CreatedDate,
                                b.SalesPercent,
                                b.Total
                            }).FirstOrDefault();

                if (bill != null)
                {
                    lblStaffname.Text += bill.StaffName;
                    lblCustomerName.Text += bill.CustomerName;
                    lblCreatedDate.Text += bill.CreatedDate.ToString("dd/MM/yyyy");
                    lblSalesPercent.Text += bill.SalesPercent.ToString();
                    lblTotal.Text += bill.Total.ToString();
                }

                // Lấy chi tiết hóa đơn, kết hợp với bảng Product để lấy giá bán
                var billDetails = (from bd in context.BillDetails
                                   join p in context.Products on bd.ProductId equals p.ProductId
                                   where bd.BillId == BillId
                                   select new
                                   {
                                       p.ProductName,
                                       bd.Quantity,
                                       p.Size,
                                       Price = p.Price, // Lấy giá từ bảng Product
                                       Total = bd.Quantity * p.Price // Tính tổng tiền cho mỗi sản phẩm
                                   }).ToList();

                dgvBillDetail.DataSource = billDetails;
                StyleSet.DataGridViewStyle(dgvBillDetail);
            }
        }



        private void ViewingBillDetail_Load(object sender, EventArgs e)
        {
            LoadBillDetail();
            LoadDGV();
        }
        private void LoadDGV()
        {
            if (dgvBillDetail.Columns["ProductName"] != null) dgvBillDetail.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            if (dgvBillDetail.Columns["Quantity"] != null) dgvBillDetail.Columns["Quantity"].HeaderText = "Số lượng";
            if (dgvBillDetail.Columns["Size"] != null) dgvBillDetail.Columns["Size"].HeaderText = "Size";
            if (dgvBillDetail.Columns["Price"] != null) dgvBillDetail.Columns["Price"].HeaderText = "Giá bán";
            if (dgvBillDetail.Columns["Total"] != null) dgvBillDetail.Columns["Total"].HeaderText = "Tổng";
        }
    }
}
