using ShopManagement;
using ShopManagement.Brand;
using ShopManagement.Models;
using ShopManagement.WareHouseProduct;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopManagement.Warehouse
{
    public partial class ViewingWarehouse : Form
    {
        private bool isAdmin;
        public ViewingWarehouse(bool isAdmin)
        {
            InitializeComponent();
            if (!isAdmin)
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        public void LoadWareHouse()
        {
            using (var context = new AppDbContext())
            {
                var warehouses = context.Warehouses
                    .Select(w => new
                    {
                        w.WarehouseId,
                        w.Name,
                        w.Address,
                        w.Phone,
                        w.Email,
                        w.Stock
                    })
                    .ToList();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = warehouses;
                StyleSet.DataGridViewStyle(dataGridView1);

                // Customize DataGridView (optional)
                dataGridView1.Columns["WarehouseId"].HeaderText = "Mã kho";
                dataGridView1.Columns["Name"].HeaderText = "Tên kho";
                dataGridView1.Columns["Phone"].HeaderText = "Số điện thoại";
                dataGridView1.Columns["Address"].HeaderText = "Địa chỉ";
                dataGridView1.Columns["Email"].HeaderText = "Email";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ViewingWarehouse_Load(object sender, EventArgs e)
        {
            LoadWareHouse();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (AddingWarehouse addBrandForm = new AddingWarehouse())
            {
                if (addBrandForm.ShowDialog() == DialogResult.OK)
                {
                    LoadWareHouse();

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            using (var context = new AppDbContext())
            {
                var query = context.Warehouses.AsQueryable();

                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(w => w.Name.Contains(searchValue));
                }

                var warehouses = query
                    .Select(w => new
                    {
                        w.WarehouseId,
                        w.Name,
                        w.Address,
                        w.Phone,
                        w.Email,
                        w.Stock
                    })
                    .ToList();

                dataGridView1.DataSource = warehouses;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int warehouseId = Convert.ToInt32(selectedRow.Cells["WarehouseId"].Value.ToString());

                // Confirm deletion
                DialogResult confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa nhà kho {warehouseId}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (var context = new AppDbContext())
                    {
                        var warehouse = context.Warehouses
                            .FirstOrDefault(w => w.WarehouseId == warehouseId);

                        if (warehouse != null)
                        {
                            context.Warehouses.Remove(warehouse);
                            context.SaveChanges();

                            MessageBox.Show("Xóa nhà kho thành công!");
                            LoadWareHouse(); // Refresh the data in DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Nhà kho không tìm thấy.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà kho để xóa.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                var selectedRow = dataGridView1.SelectedRows[0];
                var warehouseId = Convert.ToInt32(selectedRow.Cells["WarehouseId"].Value.ToString());

                using (var context = new AppDbContext())
                {
                    var warehouse = context.Warehouses
                        .FirstOrDefault(w => w.WarehouseId == warehouseId);

                    if (warehouse != null)
                    {
                        // Mở form sửa kho và truyền đối tượng Warehouse
                        using (var editWarehouseForm = new EditingWarehouse(warehouse))
                        {
                            if (editWarehouseForm.ShowDialog() == DialogResult.OK)
                            {
                                LoadWareHouse(); // Refresh the DataGridView after editing
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhà kho không tìm thấy.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà kho để sửa.");
            }
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Kiểm tra nếu người dùng double-click vào một dòng hợp lệ
            {
                // Lấy giá trị ID của nhà kho từ dòng đã chọn
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                int warehouseId = Convert.ToInt32(selectedRow.Cells["WarehouseId"].Value.ToString());

                // Mở form DetailWarehouse và truyền ID nhà kho vào TextBox
                using (var detailWarehouseForm = new ViewingWarehoueProduct())
                {
                    detailWarehouseForm.SetWarehouseId(warehouseId);  // Truyền ID nhà kho vào form chi tiết
                    detailWarehouseForm.ShowDialog();  // Hiển thị form chi tiết
                }
                using (AddingWarehouseProduct addBrandForm = new AddingWarehouseProduct(warehouseId))
                {

                    LoadWareHouse();


                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();  // Lấy từ khóa tìm kiếm và loại bỏ khoảng trắng

            using (var context = new AppDbContext())
            {
                var query = context.Warehouses.AsQueryable();

                // Kiểm tra nếu có từ khóa tìm kiếm
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(w => w.Name.Contains(searchValue) ||  // Tìm kiếm theo Tên kho
                                            w.Address.Contains(searchValue) ||  // Tìm kiếm theo Địa chỉ
                                            w.Phone.Contains(searchValue) ||  // Tìm kiếm theo Số điện thoại
                                            w.Email.Contains(searchValue));  // Tìm kiếm theo Email
                }

                // Truy vấn dữ liệu từ Warehouse và gán vào DataGridView
                var warehouses = query
                    .Select(w => new
                    {
                        w.WarehouseId,
                        w.Name,
                        w.Address,
                        w.Phone,
                        w.Email,
                        w.Stock
                    })
                    .ToList();

                dataGridView1.DataSource = warehouses;  // Cập nhật DataGridView
            }
        }

    }
}
