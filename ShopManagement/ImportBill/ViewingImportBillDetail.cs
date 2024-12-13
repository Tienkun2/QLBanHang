using System;
using System.Linq;
using System.Windows.Forms;
using ShopManagement;
using ShopManagement.Models;  // Assuming the namespace where your models are defined

namespace ShopManagement.ImportBill
{
    public partial class ViewingImportBillDetail : Form
    {
        int id_ImportBill;

        public ViewingImportBillDetail(int importBill_Id)
        {
            InitializeComponent();
            id_ImportBill = importBill_Id;

            LoadImportedProduct();
            LoadDataRelated();
        }

        public void LoadImportedProduct()
        {
            StyleSet.DataGridViewStyle(dgvImportedProduct);

            using (var context = new AppDbContext())  // Using DbContext within a using statement
            {
                // Querying ImportBillDetail and joining with Product using LINQ
                var importedProducts = context.ImportBillDetails
                    .Where(ibd => ibd.ImportBillId == id_ImportBill)
                    .Select(ibd => new
                    {
                        ibd.Product.ProductId,
                        ibd.Product.ProductName,
                        ibd.Product.Size,
                        ibd.Product.Price,
                        ibd.Product.Material,
                        ibd.Quantity
                    }).ToList();

                dgvImportedProduct.DataSource = importedProducts;
                dgvImportedProduct.Columns["ProductId"].HeaderText = "Mã quần áo";
                dgvImportedProduct.Columns["ProductName"].HeaderText = "Tên quần áo";
                dgvImportedProduct.Columns["Size"].HeaderText = "Kích cỡ";
                dgvImportedProduct.Columns["Price"].HeaderText = "Đơn giá";
                dgvImportedProduct.Columns["Material"].HeaderText = "Chất liệu";
                dgvImportedProduct.Columns["Quantity"].HeaderText = "Số lượng";
                dgvImportedProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public void LoadDataRelated()
        {
            using (var context = new AppDbContext())  // Using DbContext within a using statement
            {
                // Querying ImportBill and related data using LINQ
                var importBill = context.ImportBills
                    .Where(ib => ib.ImportBillId == id_ImportBill)
                    .Select(ib => new
                    {
                        ib.Brand.Name,
                        ib.TotalPayment,
                        ib.ImportDate
                    }).FirstOrDefault();

                if (importBill != null)
                {
                    lblBrand.Text = importBill.Name;

                    // Display total payment with null check
                    lblTotal.Text = importBill.TotalPayment.HasValue
                        ? importBill.TotalPayment.Value.ToString("N2") + " VND"
                        : "0.00 VND";

                    lblImportDate.Text = importBill.ImportDate.ToString("yyyy-MM-dd HH:mm:ss");
                }

                // Querying total quantity using LINQ
                var totalQuantity = context.ImportBillDetails
                    .Where(ibd => ibd.ImportBillId == id_ImportBill)
                    .Sum(ibd => ibd.Quantity);

                lblQuantity.Text = totalQuantity.ToString();
            }
        }
    }
}
