using ShopManagement;
using ShopManagement.Brand;
using ShopManagement.Models;
using ShopManagement.Product;
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

namespace ShopManagement.ImportBill
{
    public partial class btnAddBrand : Form
    {
        private List<Models.Product> newProducts = new List<Models.Product>();
        private float totalPayment = 0;
        private int totalAmount = 0;

        public btnAddBrand()
        {
            InitializeComponent();
            LoadBrand();
        }

        private void LoadBrand()
        {
            using (var context = new AppDbContext())
            {
                var brands = context.Brands
                    .Select(b => new { b.BrandId, b.Name })
                    .ToList();

                cmbBrand.DataSource = brands;
                cmbBrand.DisplayMember = "Name";
                cmbBrand.ValueMember = "BrandId";
            }
        }


        //Adding Product form
        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            if (cmbBrand.Items.Count != 0)
            {
                //Lay id da chon trong comboBox Brand
                int selectedBrand_Id = Convert.ToInt32(cmbBrand.SelectedValue);


                // Tạo instance của form AddingProduct
                var addingProductForm = new AddingProduct(selectedBrand_Id);

                // Đăng ký sự kiện ProductsAdded để nhận danh sách sản phẩm khi form đóng
                addingProductForm.ProductsAdded += products =>
                {
                    newProducts.AddRange(products);
                    UpdateDataGridView();
                };


                //Đăng ký sự kiện nhân tổng số lượng
                addingProductForm.QuantityUpdated += UpdateQuantityStatus;

                //Đămng ký sự kiện lấy tổng số tiền
                addingProductForm.TotalPriceUpdated += UpdateTotalPrice;

                addingProductForm.ShowDialog();
                UpdateBrandSelection();
            }
            else
            {
                MessageBox.Show("Không có thương hiệu(nhãn hàng)! Vui lòng thêm thương hiệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateDataGridView()
        {
            // Đặt lại nguồn dữ liệu
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = newProducts;

            // Thiết lập tiêu đề các cột
            dgvProduct.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            dgvProduct.Columns["Size"].HeaderText = "Kích Thước"; // Đảm bảo kích thước được hiển thị
            dgvProduct.Columns["Price"].HeaderText = "Đơn Giá";
            dgvProduct.Columns["Material"].HeaderText = "Chất Liệu";
            dgvProduct.Columns["Quantity"].HeaderText = "Số Lượng";

            // Thêm cột "Tên Thương Hiệu"
            if (!dgvProduct.Columns.Contains("BrandName"))
            {
                dgvProduct.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tên Thương Hiệu",
                    Name = "BrandName",
                    DataPropertyName = "BrandName"
                });
            }

            // Ẩn các cột không cần thiết
            dgvProduct.Columns["ProductId"].Visible = false;
            dgvProduct.Columns["BrandId"].Visible = false;
            dgvProduct.Columns["BillDetails"].Visible = false;
            dgvProduct.Columns["ImportBillDetails"].Visible = false;
            dgvProduct.Columns["WarehouseProducts"].Visible = false;
            dgvProduct.Columns["ImageUrl"].Visible = false;
            dgvProduct.Columns["Brand"].Visible = false;


            // Cập nhật tên thương hiệu cho từng dòng
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                var product = row.DataBoundItem as Models.Product;
                if (product != null)
                {
                    using (var context = new AppDbContext())
                    {
                        var brand = context.Brands
                            .Where(b => b.BrandId == product.BrandId)
                            .FirstOrDefault();
                        if (brand != null)
                        {
                            row.Cells["BrandName"].Value = brand.Name;
                        }
                    }
                }
            }

            // Tùy chỉnh hiển thị
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduct.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void UpdateQuantityStatus(int totalQuantity)
        {
            totalAmount = totalQuantity;
            txtQuantity.Text = totalQuantity.ToString();
        }
        private void UpdateTotalPrice(float totalPrice)
        {
            totalPayment = totalPrice;
            labelTotal.Text = totalPrice.ToString("C", new System.Globalization.CultureInfo("vi-VN"));
        }

        public void UpdateBrandSelection()
        {
            cmbBrand.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmitBill_Click(object sender, EventArgs e)
        {
            if (newProducts.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập sản phẩm trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var context = new AppDbContext())
            {
                var importBill = new ShopManagement.Models.ImportBill
                {
                    BrandId = Convert.ToInt32(cmbBrand.SelectedValue),
                    TotalPayment = (decimal)totalPayment,
                    ImportDate = DateTime.Now
                };

                context.ImportBills.Add(importBill);

                foreach (var product in newProducts)
                {
                    var newProduct = new Models.Product
                    {
                        ProductName = product.ProductName,
                        Size = product.Size,
                        Price = (decimal)product.Price,
                        Material = product.Material,
                        Quantity = product.Quantity,
                        BrandId = product.BrandId,
                        ImageUrl = product.ImageUrl
                    };

                    context.Products.Add(newProduct);

                    var importBillDetail = new ImportBillDetail
                    {
                        ImportBill = importBill,
                        Product = newProduct,
                        Quantity = product.Quantity,
                        Price = (decimal)product.Price
                    };

                    context.ImportBillDetails.Add(importBillDetail);
                }

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Hàng đã nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu thay đổi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }


        private void btn_DeleteImportBill_Click(object sender, EventArgs e)
        {
            new AddingBrand().ShowDialog();
            LoadBrand();
        }
    }
}
