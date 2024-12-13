using System;
using System.Linq;
using System.Windows.Forms;
using ShopManagement.Models; // Đảm bảo bạn đã khai báo đúng namespace chứa mô hình
using Microsoft.EntityFrameworkCore;
using ShopManagement;
using ShopManagement.ImportBill; // Để sử dụng Entity Framework

namespace ShopManagement.Brand
{
    public partial class ViewingBrand : Form
    {
        private bool isAdmin;
        public ViewingBrand(bool isAdmin)
        {
            InitializeComponent();
            if (!isAdmin)
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void ViewingBrand_Load(object sender, EventArgs e)
        {
            LoadBrandData();
        }

        private void LoadBrandData()
        {
            using (var context = new AppDbContext())
            {
                var brands = context.Brands.Select(b => new
                {
                    b.BrandId,
                    b.Name,
                    b.Address,
                    b.PhoneNumber
                }).ToList();

                dataGridView1.DataSource = brands;
                StyleSet.DataGridViewStyle(dataGridView1);
                dataGridView1.Columns["BrandId"].HeaderText = "Mã thương hiệu";
                dataGridView1.Columns["Name"].HeaderText = "Tên thương hiệu";
                dataGridView1.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
                dataGridView1.Columns["Address"].HeaderText = "Địa chỉ";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            using (var context = new AppDbContext())
            {
                var brands = context.Brands
                    .Where(b => b.Name.Contains(searchValue))
                    .Select(b => new
                    {
                        b.BrandId,
                        b.Name,
                        b.Address,
                        b.PhoneNumber
                    })
                    .ToList();

                dataGridView1.DataSource = brands;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                var brandIdString = selectedRow.Cells["BrandId"].Value.ToString();

                // Chuyển đổi string sang int
                if (int.TryParse(brandIdString, out int brandId))
                {
                    using (var context = new AppDbContext())
                    {
                        var brand = context.Brands.FirstOrDefault(b => b.BrandId == brandId);
                        if (brand != null)
                        {
                            using (var editBrandForm = new EditBrand(brandId))
                            {
                                if (editBrandForm.ShowDialog() == DialogResult.OK)
                                {
                                    LoadBrandData();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thương hiệu.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã thương hiệu không hợp lệ.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var brandIdString = selectedRow.Cells["BrandId"].Value.ToString();

                // Chuyển đổi string sang int
                if (int.TryParse(brandIdString, out int brandId))
                {
                    // Confirm deletion
                    DialogResult confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa thương hiệu {brandId}?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        using (var context = new AppDbContext())
                        {
                            var brand = context.Brands.FirstOrDefault(b => b.BrandId == brandId);
                            if (brand != null)
                            {
                                context.Brands.Remove(brand);
                                context.SaveChanges();
                                MessageBox.Show("Xóa thương hiệu thành công");
                                LoadBrandData();
                            }
                            else
                            {
                                MessageBox.Show("Thương hiệu không tồn tại.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã thương hiệu không hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thương hiệu muốn xóa");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var brandIdString = selectedRow.Cells["BrandId"].Value.ToString();

                // Chuyển đổi string sang int
                if (int.TryParse(brandIdString, out int brandId))
                {
                    using (var context = new AppDbContext())
                    {
                        var brand = context.Brands.FirstOrDefault(b => b.BrandId == brandId);
                        if (brand != null)
                        {
                            using (var editBrandForm = new EditBrand(brandId))
                            {
                                if (editBrandForm.ShowDialog() == DialogResult.OK)
                                {
                                    LoadBrandData();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn thương hiệu để chỉnh sửa.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã thương hiệu không hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thương hiệu để chỉnh sửa.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddingBrand addingBrand = new AddingBrand();
            addingBrand.ShowDialog();
        }
    }
}
