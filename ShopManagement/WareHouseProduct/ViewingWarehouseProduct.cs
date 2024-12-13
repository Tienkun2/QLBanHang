using ShopManagement.Warehouse;
using ShopManagement;
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
using ShopManagement.Models;

namespace ShopManagement.WareHouseProduct
{
    public partial class ViewingWarehoueProduct : Form
    {
        private HomeForm hp;
        public ViewingWarehoueProduct()
        {
            InitializeComponent();
        }
        public ViewingWarehoueProduct(HomeForm formA)
        {
            InitializeComponent();
            hp = formA;
        }
        public void SetWarehouseId(int warehouseId)
        {
            textBox1.Text = warehouseId.ToString();
            load();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int warehouseId = Convert.ToInt32(textBox1.Text.Trim());  // Get the WarehouseId from textBox1

            // Tạo một instance của form AddingWarehouseProduct và truyền WarehouseId
            using (var addingProductForm = new AddingWarehouseProduct(warehouseId))
            {
                // Hiển thị form như một dialog
                if (addingProductForm.ShowDialog() == DialogResult.OK)
                {
                    load(); // Tải lại dữ liệu sau khi form AddingWarehouseProduct đóng và trả về DialogResult.OK
                }
            }
        }

        private void load()
        {
            int warehouseId = Convert.ToInt32(textBox1.Text);  // Get the WarehouseId from textBox1

            // Sử dụng Entity Framework để lấy dữ liệu từ bảng WarehouseProduct và Product
            using (var context = new AppDbContext())
            {
                var query = from wp in context.WarehouseProducts
                            join p in context.Products on wp.ProductId equals p.ProductId
                            where wp.WarehouseId == warehouseId
                            group wp by new { wp.WarehouseId, wp.ProductId, p.ProductName } into g
                            select new
                            {
                                g.Key.WarehouseId,
                                g.Key.ProductId,
                                g.Key.ProductName,
                                TotalQuantity = g.Sum(x => x.Quantity),
                                TotalValue = g.Sum(x => x.Quantity * x.Product.Price) // Giả sử bạn có thuộc tính Price trong Product
                            };

                // Đổ dữ liệu vào DataGridView
                dataGridView1.DataSource = query.ToList();
                StyleSet.DataGridViewStyle(dataGridView1);

                // Đặt tiêu đề cho các cột
                dataGridView1.Columns["WarehouseId"].HeaderText = "Mã kho";
                dataGridView1.Columns["ProductId"].HeaderText = "Mã sản phẩm";
                dataGridView1.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dataGridView1.Columns["TotalQuantity"].HeaderText = "Tổng số lượng";
                dataGridView1.Columns["TotalValue"].HeaderText = "Tổng giá trị";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void ViewingWarehoueProduct_Load(object sender, EventArgs e)
        {
            load();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // Lấy WarehouseId từ textBox1
                int warehouseId = Convert.ToInt32(textBox1.Text);

                // Hiển thị xác nhận trước khi xóa
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa tất cả các sản phẩm trong kho có ID {warehouseId}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new AppDbContext())
                        {
                            // Lấy tất cả các bản ghi trong WarehouseProduct cho WarehouseId đã cho
                            var warehouseProductsToDelete = context.WarehouseProducts
                                .Where(wp => wp.WarehouseId == warehouseId)
                                .ToList();

                            // Xóa các bản ghi này
                            context.WarehouseProducts.RemoveRange(warehouseProductsToDelete);

                            // Lưu thay đổi vào cơ sở dữ liệu
                            context.SaveChanges();

                            MessageBox.Show("Tất cả sản phẩm trong kho đã được xóa thành công.");
                            load(); // Tải lại dữ liệu sau khi xóa
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã kho cần xóa.");
            }
        }

    }

}
