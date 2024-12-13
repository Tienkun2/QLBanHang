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
    public partial class AddProductToBill : Form
    {

        public AddProductToBill()
        {
            InitializeComponent();
        }
        private void LoadWarehouses()
        {
            using (var context = new AppDbContext()) // Sử dụng DbContext
            {
                var warehouses = context.Warehouses
                    .Select(w => new { w.WarehouseId, w.Name }) // Lấy các kho hàng cần thiết
                    .ToList();

                cmbWarehouse.DataSource = warehouses;
                cmbWarehouse.DisplayMember = "Name";
                cmbWarehouse.ValueMember = "WarehouseId";
            }
        }

        private void AddProductToBill_Load(object sender, EventArgs e)
        {
            StyleSet.DataGridViewStyle(dgvProducts);
            LoadWarehouses();
            int warehouseId = 0;
            if (cmbWarehouse.SelectedValue != null && int.TryParse(cmbWarehouse.SelectedValue.ToString(), out warehouseId))
            {
                LoadProduct(warehouseId);
            }
            LoadDGV();
        }

        private void LoadDGV()
        {
            if (dgvProducts.Columns["ProductId"] != null) dgvProducts.Columns["ProductId"].Visible = false;
            if (dgvProducts.Columns["WarehouseProductId"] != null) dgvProducts.Columns["WarehouseProductId"].Visible = false;
            if (dgvProducts.Columns["ProductName"] != null) dgvProducts.Columns["ProductName"].HeaderText = "Tên quần áo";
            if (dgvProducts.Columns["Size"] != null) dgvProducts.Columns["Size"].HeaderText = "Kích cỡ";
            if (dgvProducts.Columns["Price"] != null) dgvProducts.Columns["Price"].HeaderText = "Đơn giá";
            if (dgvProducts.Columns["Quantity"] != null) dgvProducts.Columns["Quantity"].HeaderText = "Số lượng";

            // Kiểm tra nếu cột ProductImage chưa tồn tại
            if (dgvProducts.Columns["ProductImage"] == null)
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    Name = "ProductImage",
                    HeaderText = "Hình ảnh",
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Tùy chỉnh hiển thị ảnh
                };
                dgvProducts.Columns.Add(imgColumn);
            }

            // Xóa cột ImageUrl nếu tồn tại
            if (dgvProducts.Columns["ImageUrl"] != null)
            {
                dgvProducts.Columns.Remove("ImageUrl");
            }
        }

        private void LoadProduct(int warehouseId)
        {
            using (var context = new AppDbContext())
            {
                var products = (from wp in context.WarehouseProducts
                                join p in context.Products on wp.ProductId equals p.ProductId
                                where wp.WarehouseId == warehouseId
                                select new
                                {
                                    wp.WarehouseProductId,
                                    p.ProductId,
                                    p.ProductName,
                                    p.Size,
                                    p.Price,
                                    wp.Quantity,
                                    p.ImageUrl // Đường dẫn ảnh
                                }).ToList();

                dgvProducts.DataSource = products;

                // Kiểm tra và thêm cột ProductImage nếu chưa tồn tại
                if (dgvProducts.Columns["ProductImage"] == null)
                {
                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                    {
                        Name = "ProductImage",
                        HeaderText = "Hình ảnh",
                        ImageLayout = DataGridViewImageCellLayout.Zoom // Cách hiển thị ảnh
                    };
                    dgvProducts.Columns.Insert(0, imgColumn); // Thêm vào đầu bảng
                }

                // Xóa cột ImageUrl nếu tồn tại
                if (dgvProducts.Columns["ImageUrl"] != null)
                {
                    dgvProducts.Columns.Remove("ImageUrl");
                }

                // Thêm ảnh vào cột ProductImage
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.DataBoundItem != null) // Kiểm tra dữ liệu hàng
                    {
                        var data = (dynamic)row.DataBoundItem;
                        string imageUrl = data.ImageUrl;
                        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), imageUrl);

                        // Kiểm tra và tải ảnh
                        if (!string.IsNullOrEmpty(imageUrl) && File.Exists(imagePath))
                        {
                            try
                            {
                                row.Cells["ProductImage"].Value = Image.FromFile(imagePath);
                            }
                            catch
                            {
                                // Sử dụng ảnh mặc định nếu lỗi khi tải ảnh
                                row.Cells["ProductImage"].Value = GetDefaultImage();
                            }
                        }
                        else
                        {
                            // Hiển thị ảnh mặc định nếu ảnh không tồn tại
                            row.Cells["ProductImage"].Value = GetDefaultImage();
                        }
                    }
                }

                StyleSet.DataGridViewStyle(dgvProducts);
            }
        }


        private Image GetDefaultImage()
        {
            string defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", "FFFF00.jpg");
            if (File.Exists(defaultImagePath))
            {
                return Image.FromFile(defaultImagePath);
            }
            else
            {
                MessageBox.Show("Ảnh mặc định không tìm thấy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }





        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int warehouseId = 0;
            if (cmbWarehouse.SelectedValue != null && int.TryParse(cmbWarehouse.SelectedValue.ToString(), out warehouseId))
            {
                LoadProduct(warehouseId);
                LoadDGV();
            }
        }

        public List<Models.AddProduct> addProducts { get; private set; } = new List<Models.AddProduct>();

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(txtQuanity.Text))
                {
                    MessageBox.Show("Vui lòng nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuanity.Focus();
                    return;
                }

                if (!int.TryParse(txtQuanity.Text, out int checkQuanity) || checkQuanity <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuanity.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSellingPrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSellingPrice.Focus();
                    return;
                }

                if (!float.TryParse(txtSellingPrice.Text, out float sellingPrice) || sellingPrice <= 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSellingPrice.Focus();
                    return;
                }

                int checkQuanity_2 = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Quantity"].Value);

                if (checkQuanity > checkQuanity_2)
                {
                    MessageBox.Show("Không thể bán số lượng lớn hơn số lượng trong kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giá bán lớn hơn giá nhập
                float importPrice = Convert.ToSingle(dgvProducts.SelectedRows[0].Cells["Price"].Value);

                if (sellingPrice <= importPrice)
                {
                    MessageBox.Show("Giá bán phải lớn hơn giá nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSellingPrice.Focus();
                    return;
                }

                // Giảm số lượng sản phẩm trong kho
                using (var context = new AppDbContext())
                {
                    var warehouseProduct = context.WarehouseProducts
                        .FirstOrDefault(wp => wp.WarehouseProductId == Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["WarehouseProductId"].Value));

                    if (warehouseProduct != null)
                    {
                        // Cập nhật lại số lượng trong kho
                        warehouseProduct.Quantity -= checkQuanity;

                        // Kiểm tra nếu số lượng còn lại = 0
                        if (warehouseProduct.Quantity <= 0)
                        {
                            MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Lưu lại thay đổi vào cơ sở dữ liệu
                        context.SaveChanges();
                    }
                }

                var selectedRow = dgvProducts.SelectedRows[0];

                AddProduct addProduct = new AddProduct
                {
                    WarehouseProductId = Convert.ToInt32(selectedRow.Cells["WarehouseProductId"].Value),
                    ProductId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value),
                    ProductName = selectedRow.Cells["ProductName"].Value.ToString(),
                    Size = selectedRow.Cells["Size"].Value.ToString(),
                    Price = sellingPrice,
                    Quanity = checkQuanity,
                };

                addProducts.Add(addProduct);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để thêm.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {

        }


        private void SearchProducts(string keyword)
        {
            using (var context = new AppDbContext())
            {
                int warehouseId = 0;
                if (cmbWarehouse.SelectedValue != null && int.TryParse(cmbWarehouse.SelectedValue.ToString(), out warehouseId))
                {
                    var filteredProducts = (from wp in context.WarehouseProducts
                                            join p in context.Products on wp.ProductId equals p.ProductId
                                            where wp.WarehouseId == warehouseId &&
                                                  (p.ProductName.ToLower().Contains(keyword.ToLower()) ||
                                                   p.ProductId.ToString().Contains(keyword))
                                            select new
                                            {
                                                wp.WarehouseProductId,
                                                p.ProductId,
                                                p.ProductName,
                                                p.Size,
                                                p.Price,
                                                wp.Quantity,
                                                p.ImageUrl
                                            }).ToList();

                    dgvProducts.DataSource = filteredProducts;
                    LoadDGV(); // Cập nhật lại cài đặt hiển thị DataGridView
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            SearchProducts(keyword);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Columns[e.ColumnIndex].Name == "ProductImage")
            {
                var cell = dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value is Image clickedImage)
                {
                    // Hiển thị ảnh trong form phóng to
                    ImagePreviewForm previewForm = new ImagePreviewForm();
                    previewForm.SetImage(clickedImage);
                    previewForm.ShowDialog();
                }
            }
        }
    }
}
