using ShopManagement.Bill;
using ShopManagement.ImportBill;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ShopManagement;
using ShopManagement.Models;
using ClosedXML.Excel;

namespace ShopManagement.Statistics
{
    public partial class ViewingStatictis : Form
    {
        private string currentDgv = "";
        private AppDbContext _context;

        public ViewingStatictis()
        {
            InitializeComponent();
            _context = new AppDbContext();

            LoadStatisticsType();
            UpdateStatistics();
            ConfigureDateTimePicker();
            comboBox1.SelectedIndex = 0;
        }

        private void UpdateStatistics()
        {
            // Display total number of customers
            var customerCount = _context.Customers.Count();
            labelSection2.Text = $"{customerCount}";

            // Display total number of bills
            var billCount = _context.Bills.Count();
            labelSection1.Text = $"{billCount}";

            // Calculate total revenue
            var totalRevenue = _context.Bills.Sum(b => b.Total);
            labelSection3.Text = $"{totalRevenue:N0}₫";
        }

        private void LoadStatisticsType()
        {
            comboBox1.Items.Add("Các sản phẩm bán chạy");
            comboBox1.Items.Add("Hóa đơn bán");
            comboBox1.Items.Add("Hóa đơn nhập");
        }

        private void ConfigureDateTimePicker()
        {
            dateTimePicker1.Visible = true;
            btnFilter.Visible = true;
            labelInfo.Visible = true;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void LoadTopSellingProducts()
        {
            var query = _context.BillDetails
                .Join(_context.Products, od => od.ProductId, p => p.ProductId, (od, p) => new { od, p })
                .GroupBy(g => new { g.p.ProductId, g.p.ProductName })
                .Select(g => new
                {
                    ProductName = g.Key.ProductName,
                    TotalSold = g.Sum(x => x.od.Quantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(10)
                .ToList();

            dataGridView1.DataSource = query;
            StyleSet.DataGridViewStyle(dataGridView1);

            dataGridView1.Columns["ProductName"].HeaderText = "Tên quần áo";
            dataGridView1.Columns["TotalSold"].HeaderText = "Số lượng đã bán";

        }

        private void DisplayBill()
        {
            var query = _context.Bills
                .Join(_context.Staff, b => b.StaffId, s => s.StaffId, (b, s) => new { b, s })
                .Join(_context.Customers, bs => bs.b.CustomerId, c => c.CustomerId, (bs, c) => new
                {
                    bs.b.BillId,
                    StaffName = bs.s.Name,
                    CustomerName = c.Name,
                    bs.b.SalesPercent,
                    bs.b.CreatedDate,
                    bs.b.Total
                }).ToList();

            dataGridView1.DataSource = query;
            StyleSet.DataGridViewStyle(dataGridView1);

            if (query.Any())
            {
                dataGridView1.Columns["BillId"].HeaderText = "Mã hóa đơn";
                dataGridView1.Columns["StaffName"].HeaderText = "Tên nhân viên";
                dataGridView1.Columns["CustomerName"].HeaderText = "Tên khách hàng";
                dataGridView1.Columns["SalesPercent"].HeaderText = "Chiết khấu";
                dataGridView1.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                dataGridView1.Columns["Total"].HeaderText = "Tổng hóa đơn";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu hóa đơn bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayImportBill()
        {
            var query = _context.ImportBills
                .Join(_context.Brands, ib => ib.BrandId, b => b.BrandId, (ib, b) => new
                {
                    ib.ImportBillId,
                    BrandName = b.Name,
                    ib.TotalPayment,
                    ib.ImportDate
                }).ToList();

            dataGridView1.DataSource = query;
            StyleSet.DataGridViewStyle(dataGridView1);

            if (query.Any())
            {
                dataGridView1.Columns["ImportBillId"].HeaderText = "Mã hóa đơn nhập";
                dataGridView1.Columns["BrandName"].HeaderText = "Nhà cung cấp";
                dataGridView1.Columns["TotalPayment"].HeaderText = "Tổng hóa đơn";
                dataGridView1.Columns["ImportDate"].HeaderText = "Ngày nhập";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu hóa đơn nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại thống kê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int month = dateTimePicker1.Value.Month;
            int year = dateTimePicker1.Value.Year;

            if (comboBox1.SelectedItem.ToString() == "Hóa đơn bán")
            {
                var filteredQuery = _context.Bills
                    .Where(b => b.CreatedDate.Month == month && b.CreatedDate.Year == year)
                    .Join(_context.Staff, b => b.StaffId, s => s.StaffId, (b, s) => new { b, s })
                    .Join(_context.Customers, bs => bs.b.CustomerId, c => c.CustomerId, (bs, c) => new
                    {
                        bs.b.BillId,
                        StaffName = bs.s.Name,
                        CustomerName = c.Name,
                        bs.b.SalesPercent,
                        bs.b.CreatedDate,
                        bs.b.Total
                    }).ToList();

                dataGridView1.DataSource = filteredQuery;
                StyleSet.DataGridViewStyle(dataGridView1);

                if (!filteredQuery.Any())
                {
                    MessageBox.Show("Không tìm thấy dữ liệu hóa đơn bán cho tháng/năm đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Hóa đơn nhập")
            {
                var filteredQuery = _context.ImportBills
                    .Where(ib => ib.ImportDate.Month == month && ib.ImportDate.Year == year)
                    .Join(_context.Brands, ib => ib.BrandId, b => b.BrandId, (ib, b) => new
                    {
                        ib.ImportBillId,
                        BrandName = b.Name,
                        ib.TotalPayment,
                        ib.ImportDate
                    }).ToList();

                dataGridView1.DataSource = filteredQuery;
                StyleSet.DataGridViewStyle(dataGridView1);

                if (!filteredQuery.Any())
                {
                    MessageBox.Show("Không tìm thấy dữ liệu hóa đơn nhập cho tháng/năm đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) // Các sản phẩm bán chạy
            {
                LoadTopSellingProducts();
            }
            else if (comboBox1.SelectedIndex == 1) // Hóa đơn bán
            {
                DisplayBill();
            }
            else if (comboBox1.SelectedIndex == 2) // Hóa đơn nhập
            {
                DisplayImportBill();
            }
        }

        // Sự kiện khi click vào một dòng trong DataGridView để hiển thị chi tiết hóa đơn
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                if (currentDgv == "bill")
                {
                    DisplayBillDetail(id);
                }
                else if (currentDgv == "importbill")
                {
                    DisplayImportBillDetail(id);
                }
            }
        }

        // Hiển thị chi tiết hóa đơn bán
        private void DisplayBillDetail(int id)
        {
            var billDetail = _context.Bills
                .Where(b => b.BillId == id)
                .FirstOrDefault();

            if (billDetail != null)
            {
                // Hiển thị chi tiết hóa đơn bán (Có thể thay đổi theo UI của bạn)
                MessageBox.Show($"Hóa đơn ID: {billDetail.BillId}");
            }
        }

        // Hiển thị chi tiết hóa đơn nhập
        private void DisplayImportBillDetail(int id)
        {
            var importBillDetail = _context.ImportBills
                .Where(ib => ib.ImportBillId == id)
                .FirstOrDefault();



            if (importBillDetail != null)
            {
                // Hiển thị chi tiết hóa đơn nhập
                MessageBox.Show($"Hóa đơn nhập ID: {importBillDetail.ImportBillId}");
            }
        }

        // Sự kiện khi double-click vào dòng trong DataGridView để mở chi tiết hóa đơn bán
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                int billId = Convert.ToInt32(selectedRow.Cells[0].Value);
                new ViewingBillDetail(billId).ShowDialog();
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu báo cáo",
                FileName = "BaoCao_ThongKe.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Báo Cáo");

                        // Thêm tiêu đề cột
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                        }

                        // Thêm dữ liệu từ DataGridView
                        // Thêm dữ liệu từ DataGridView
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                                worksheet.Cell(i + 2, j + 1).Value = cellValue?.ToString() ?? ""; // Chuyển đổi giá trị về chuỗi hoặc để trống nếu null
                            }
                        }


                        // Lưu file Excel
                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
