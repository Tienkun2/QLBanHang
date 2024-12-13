using ShopManagement;
using ShopManagement.Models;
using ShopManagement.Product;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagement.ImportBill
{
    public partial class EditingImportBill : Form
    {
        private int importBill_Id;

        public EditingImportBill(int idImportBill)
        {
            InitializeComponent();
            importBill_Id = idImportBill;

            labelTotal.Text = importBill_Id.ToString();
            LoadData();
            LoadImportedProduct();
        }

        public void LoadImportedProduct()
        {
            using (var context = new AppDbContext())
            {
                var productList = context.ImportBillDetails
                    .Where(ibd => ibd.ImportBillId == importBill_Id)
                    .Select(ibd => new
                    {
                        ibd.Product.ProductId,
                        ibd.Product.ProductName,
                        ibd.Product.Size,
                        ibd.Product.Price,
                        ibd.Product.Material,
                        ibd.Quantity
                    })
                    .ToList();

                dgvProduct.DataSource = productList;

                StyleSet.DataGridViewStyle(dgvProduct);

                dgvProduct.Columns["ProductId"].HeaderText = "Mã quần áo";
                dgvProduct.Columns["ProductName"].HeaderText = "Tên quần áo";
                dgvProduct.Columns["Size"].HeaderText = "Kích cỡ";
                dgvProduct.Columns["Price"].HeaderText = "Đơn giá";
                dgvProduct.Columns["Material"].HeaderText = "Chất liệu";
                dgvProduct.Columns["Quantity"].HeaderText = "Số lượng";

                dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public void LoadData()
        {
            using (var context = new AppDbContext())
            {
                // Lấy tổng số lượng
                var totalQuantity = context.ImportBillDetails
                    .Where(ibd => ibd.ImportBillId == importBill_Id)
                    .Sum(ibd => (int?)ibd.Quantity) ?? 0;

                if (totalQuantity == 0)
                {
                    MessageBox.Show("Hóa đơn nhập không có sản phẩm nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtQuantity.Text = totalQuantity.ToString();

                // Lấy thông tin hóa đơn nhập
                var importBillInfo = context.ImportBills
                    .Where(ib => ib.ImportBillId == importBill_Id)
                    .Select(ib => new
                    {
                        BrandName = ib.Brand.Name,
                        TotalPayment = ib.TotalPayment,
                        ImportDate = ib.ImportDate
                    })
                    .FirstOrDefault();

                if (importBillInfo != null)
                {
                    var index = cmbBrand.FindStringExact(importBillInfo.BrandName);
                    if (index >= 0)
                    {
                        cmbBrand.SelectedIndex = index;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thương hiệu tương ứng với hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    labelTotal.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:N2} VND", importBillInfo.TotalPayment);
                    dateTimePicker1.Value = importBillInfo.ImportDate;
                }

                // Load danh sách thương hiệu
                var brands = context.Brands
                    .Select(b => new { b.BrandId, b.Name })
                    .ToList();

                cmbBrand.DataSource = brands;
                cmbBrand.DisplayMember = "Name";
                cmbBrand.ValueMember = "BrandId";
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (cmbBrand.Items.Count == 0)
                {
                    MessageBox.Show("Không có thương hiệu(nhãn hàng)! Vui lòng thêm thương hiệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dgvProduct.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một dòng trước khi chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!dgvProduct.Columns.Contains("ProductId"))
                {
                    MessageBox.Show("Không tìm thấy cột 'ProductId'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int productId = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["ProductId"].Value);
                new ModifyingProduct(importBill_Id, productId).ShowDialog();

                // Load lại dữ liệu sau khi chỉnh sửa
                LoadData();
                LoadImportedProduct();
            }
        }

        private void btnSubmitBill_Click(object sender, EventArgs e)
        {
            int selectedBrandId = (int)cmbBrand.SelectedValue;

            using (var context = new AppDbContext())
            {
                // Cập nhật hóa đơn nhập
                var importBill = context.ImportBills.FirstOrDefault(ib => ib.ImportBillId == importBill_Id);
                if (importBill == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nhập để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                importBill.BrandId = selectedBrandId;
                importBill.ImportDate = DateTime.Now;

                // Cập nhật BrandId của sản phẩm trong hóa đơn nhập
                var productsToUpdate = context.ImportBillDetails
                    .Where(ibd => ibd.ImportBillId == importBill_Id)
                    .Select(ibd => ibd.Product)
                    .ToList();

                if (!productsToUpdate.Any())
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào trong hóa đơn nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var product in productsToUpdate)
                {
                    product.BrandId = selectedBrandId;
                }

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật hóa đơn thành công.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
