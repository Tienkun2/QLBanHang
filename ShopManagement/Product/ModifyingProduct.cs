using ShopManagement.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagement.Product
{
    public partial class ModifyingProduct : Form
    {
        private int importBill_Id;
        private int productId;
        private readonly AppDbContext _context;

        public ModifyingProduct(int idImportBill, int product_id)
        {
            InitializeComponent();
            importBill_Id = idImportBill;
            productId = product_id;
            _context = new AppDbContext(); // Khởi tạo DbContext
            LoadData();
        }

        // Load dữ liệu sản phẩm
        public void LoadData()
        {
            var product = _context.Products
                .Where(p => p.ProductId == productId)
                .FirstOrDefault();

            if (product != null)
            {
                txtName.Text = product.ProductName;
                txtSize.Text = product.Size;
                txtPrice.Text = product.Price.ToString();
                txtMaterial.Text = product.Material;
                txtQuantity.Text = product.Quantity.ToString();
            }
        }

        // Chỉnh sửa sản phẩm
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var product = _context.Products
                    .Where(p => p.ProductId == productId)
                    .FirstOrDefault();

                if (product != null)
                {
                    // Cập nhật thông tin sản phẩm
                    product.ProductName = txtName.Text;
                    product.Size = txtSize.Text;
                    product.Price = Convert.ToDecimal(txtPrice.Text); // Chỉnh sửa cho phù hợp với kiểu dữ liệu decimal
                    product.Material = txtMaterial.Text;
                    product.Quantity = Convert.ToInt32(txtQuantity.Text);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _context.SaveChanges();

                    // Cập nhật ImportBillDetail
                    var importBillDetail = _context.ImportBillDetails
                        .Where(ibd => ibd.ProductId == productId && ibd.ImportBillId == importBill_Id)
                        .FirstOrDefault();

                    if (importBillDetail != null)
                    {
                        importBillDetail.Quantity = Convert.ToInt32(txtQuantity.Text);
                        importBillDetail.Price = Convert.ToDecimal(txtPrice.Text);
                        _context.SaveChanges(); // Lưu ImportBillDetail
                    }

                    // Cập nhật tổng thanh toán cho ImportBill
                    var importBill = _context.ImportBills
                        .Where(ib => ib.ImportBillId == importBill_Id)
                        .FirstOrDefault();

                    if (importBill != null)
                    {
                        importBill.TotalPayment = _context.ImportBillDetails
                            .Where(ibd => ibd.ImportBillId == importBill_Id)
                            .Sum(ibd => ibd.Quantity * ibd.Price);

                        _context.SaveChanges(); // Lưu tổng thanh toán cho ImportBill
                    }

                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa sản phẩm
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var importBillDetail = _context.ImportBillDetails
                    .Where(ibd => ibd.ProductId == productId && ibd.ImportBillId == importBill_Id)
                    .FirstOrDefault();

                if (importBillDetail != null)
                {
                    _context.ImportBillDetails.Remove(importBillDetail); // Xóa ImportBillDetail
                }

                var product = _context.Products
                    .Where(p => p.ProductId == productId)
                    .FirstOrDefault();

                if (product != null)
                {
                    _context.Products.Remove(product); // Xóa sản phẩm
                }

                var importBill = _context.ImportBills
                    .Where(ib => ib.ImportBillId == importBill_Id)
                    .FirstOrDefault();

                if (importBill != null)
                {
                    importBill.TotalPayment = _context.ImportBillDetails
                        .Where(ibd => ibd.ImportBillId == importBill_Id)
                        .Sum(ibd => ibd.Quantity * ibd.Price);

                    _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }

                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
