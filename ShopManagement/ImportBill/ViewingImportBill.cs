using ShopManagement;
using Microsoft.EntityFrameworkCore;
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

namespace ShopManagement.ImportBill
{
    public partial class ViewingImportBill : Form
    {
        private bool isAdmin;
        public ViewingImportBill(bool isAdmin)
        {
            InitializeComponent();
            if (!isAdmin)
            {
                btn_AddImportBill.Visible = false;
                btn_UpdateImportBill.Visible = false;
                btn_DeleteImportBill.Visible = false;
            }
            LoadImportBill();
        }

        private void LoadImportBill()
        {
            using (var context = new AppDbContext())
            {
                var importBills = context.ImportBills
                    .Select(b => new
                    {
                        b.ImportBillId,
                        BrandName = b.Brand.Name,
                        b.TotalPayment,
                        b.ImportDate
                    })
                    .ToList();

                dgv_ViewImportBill.DataSource = importBills;
                StyleSet.DataGridViewStyle(dgv_ViewImportBill);

                dgv_ViewImportBill.Columns["ImportBillId"].HeaderText = "Mã hóa đơn nhập";
                dgv_ViewImportBill.Columns["BrandName"].HeaderText = "Nhà cung cấp";
                dgv_ViewImportBill.Columns["TotalPayment"].HeaderText = "Tổng hóa đơn";
                dgv_ViewImportBill.Columns["ImportDate"].HeaderText = "Ngày nhập";

                dgv_ViewImportBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void btn_AddImportBill_Click(object sender, EventArgs e)
        {
            new btnAddBrand().ShowDialog();
            LoadImportBill();
        }

        private void btn_DeleteImportBill_Click(object sender, EventArgs e)
        {
            if (dgv_ViewImportBill.SelectedRows.Count > 0)
            {
                int idImportBill = Convert.ToInt32(dgv_ViewImportBill.SelectedRows[0].Cells["ImportBillId"].Value);

                using (var context = new AppDbContext())
                {
                    var importBill = context.ImportBills
                        .Include(b => b.ImportBillDetails) // Include các chi tiết hóa đơn
                        .ThenInclude(d => d.Product)      // Include các sản phẩm liên quan
                        .FirstOrDefault(b => b.ImportBillId == idImportBill);

                    if (importBill != null)
                    {
                        // Xóa các sản phẩm liên quan
                        var products = importBill.ImportBillDetails.Select(d => d.Product).ToList();
                        context.Products.RemoveRange(products);

                        // Xóa các chi tiết hóa đơn
                        context.ImportBillDetails.RemoveRange(importBill.ImportBillDetails);

                        // Xóa hóa đơn
                        context.ImportBills.Remove(importBill);

                        context.SaveChanges();
                        MessageBox.Show("Hóa đơn và các sản phẩm liên quan đã được xóa thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn để xóa.");
                    }
                }

                // Cập nhật lại DataGridView
                LoadImportBill();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.");
            }
        }

        private void btn_UpdateImportBill_Click(object sender, EventArgs e)
        {
            if (dgv_ViewImportBill.SelectedRows.Count > 0)
            {
                int idImportBill = Convert.ToInt32(dgv_ViewImportBill.SelectedRows[0].Cells["ImportBillId"].Value);

                new EditingImportBill(idImportBill).ShowDialog();
                LoadImportBill();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa.");
            }
        }

        private void dgv_ViewImportBill_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int importBillId = Convert.ToInt32(dgv_ViewImportBill.Rows[e.RowIndex].Cells["ImportBillId"].Value);

                new ViewingImportBillDetail(importBillId).ShowDialog();
            }
        }

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    string searchKeyword = txtSearch.Text.Trim().ToLower();

        //    using (var context = new AppDbContext())
        //    {
        //        // Truy vấn danh sách hóa đơn nhập và lọc theo từ khóa tìm kiếm
        //        var importBills = context.ImportBills
        //            .Join(context.Brands, b => b.BrandId, br => br.BrandId, (b, br) => new
        //            {
        //                b.ImportBillId,
        //                BrandName = br.Name,
        //                b.TotalPayment,
        //                b.ImportDate
        //            })
        //            .Where(b => b.BrandName.ToLower().Contains(searchKeyword) ||
        //                        b.ImportDate.ToString("yyyy-MM-dd").Contains(searchKeyword))  // Lọc theo BrandName hoặc ImportDate
        //            .ToList();

        //        dgv_ViewImportBill.DataSource = importBills;
        //    }
        //}
    }
}
