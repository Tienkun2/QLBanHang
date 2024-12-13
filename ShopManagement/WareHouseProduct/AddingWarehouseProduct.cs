using ShopManagement;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Models;
using ShopManagement.Warehouse;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagement.WareHouseProduct
{
    public partial class AddingWarehouseProduct : Form
    {
        private readonly AppDbContext dbContext; // Entity Framework context
        public int WarehouseId { get; set; }

        public AddingWarehouseProduct(int warehouseId)
        {
            InitializeComponent();
            WarehouseId = warehouseId;
            dbContext = new AppDbContext(); // Initialize the EF context
            LoadProductDataToComboBox();
        }

        private bool isLoading = false; // Flag to prevent unnecessary data reloads

        private void LoadProductDataToComboBox()
        {
            isLoading = true;
            var importBills = dbContext.ImportBills.ToList();

            comboBox1.DataSource = importBills;
            comboBox1.DisplayMember = "ImportBillId";
            comboBox1.ValueMember = "ImportBillId";
            LoadUnaddedImportBills();
            isLoading = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            int selectedImportBillId = Convert.ToInt32(comboBox1.SelectedValue);

            var productDetails = dbContext.ImportBillDetails
                .Where(ibd => ibd.ImportBillId == selectedImportBillId)
                .Select(ibd => new { ibd.ProductId, ibd.Quantity })
                .ToList();

            if (productDetails.Any())
            {
                comboBox2.DataSource = productDetails;
                comboBox2.DisplayMember = "ProductId";
                comboBox2.ValueMember = "ProductId";
            }
            else
            {
                comboBox2.DataSource = null;
                MessageBox.Show("Không tìm thấy sản phẩm trong hóa đơn nhập.");
            }
        }

        private void AddingWarehouseProduct_Load(object sender, EventArgs e)
        {
            LoadProductDataToComboBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedImportBillId = Convert.ToInt32(comboBox1.SelectedValue);

            // Check if the import bill has already been added to another warehouse
            bool billExistsInWarehouse = dbContext.WarehouseProducts
                .Any(wp => wp.ProductId == selectedImportBillId);

            if (billExistsInWarehouse)
            {
                MessageBox.Show("Hóa đơn nhập này đã được nhập vào một nhà kho trước đó và không thể nhập thêm vào bất kỳ nhà kho nào khác.");
                return;
            }

            // Get the product details from the selected import bill
            var productDetails = dbContext.ImportBillDetails
                .Where(ibd => ibd.ImportBillId == selectedImportBillId)
                .Select(ibd => new { ibd.ProductId, ibd.Quantity })
                .ToList();

            int totalQuantityInBill = productDetails.Sum(pd => pd.Quantity);

            // Check if the warehouse has enough stock capacity
            int availableStock = dbContext.Warehouses
                .Where(w => w.WarehouseId == WarehouseId)
                .Select(w => w.Stock)
                .FirstOrDefault()
                .GetValueOrDefault(); // Returns 0 if null

            if (totalQuantityInBill > availableStock)
            {
                MessageBox.Show("Không thể thêm hóa đơn nhập này vào kho. Tổng số lượng sản phẩm vượt quá sức chứa hiện tại.");
                return;
            }

            // Add products to the warehouse if enough stock is available
            foreach (var detail in productDetails)
            {
                dbContext.WarehouseProducts.Add(new WarehouseProduct
                {
                    WarehouseId = WarehouseId,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity
                });
            }

            // Commit the changes to the database
            dbContext.SaveChanges();

            MessageBox.Show("Sản phẩm đã được thêm vào kho.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadUnaddedImportBills()
        {
            var unaddedImportBillDetails = dbContext.ImportBillDetails
                .Where(ibd => !dbContext.WarehouseProducts.Any(wp => wp.ProductId == ibd.ProductId))
                .Join(
                    dbContext.Products,
                    ibd => ibd.ProductId,
                    p => p.ProductId,
                    (ibd, p) => new
                    {
                        ibd.ImportBillId,
                        ibd.ProductId,
                        ibd.Quantity,
                        ibd.Price,
                        p.Size // Thêm thông tin Size từ bảng Products
                    }
                )
                .ToList();

            dataGridView1.DataSource = unaddedImportBillDetails;

            // Styling the DataGridView
            StyleSet.DataGridViewStyle(dataGridView1);
            dataGridView1.Columns["ImportBillId"].HeaderText = "Mã Hóa Đơn Nhập";
            dataGridView1.Columns["ProductId"].HeaderText = "Mã Sản Phẩm";
            dataGridView1.Columns["Quantity"].HeaderText = "Số Lượng";
            dataGridView1.Columns["Price"].HeaderText = "Đơn Giá";
            dataGridView1.Columns["Size"].HeaderText = "Kích Thước"; // Thêm tiêu đề cho cột Size
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int selectedProductId))
            {
                var productDetails = dbContext.ImportBillDetails
                    .Where(ibd => ibd.ProductId == selectedProductId)
                    .Select(ibd => new { ibd.Quantity })
                    .FirstOrDefault();

                if (productDetails != null)
                {
                    textBox1.Text = productDetails.Quantity.ToString();

                    var productName = dbContext.Products
                        .Where(p => p.ProductId == selectedProductId)
                        .Select(p => p.ProductName)
                        .FirstOrDefault();

                    if (productName != null)
                    {
                        textBox2.Text = productName;
                    }
                    else
                    {
                        textBox2.Clear();
                        MessageBox.Show("Không tìm thấy tên sản phẩm.");
                    }
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("Không tìm thấy chi tiết sản phẩm.");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                comboBox1.SelectedValue = selectedRow.Cells["ImportBillId"].Value;
                comboBox2.Text = selectedRow.Cells["ProductId"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
