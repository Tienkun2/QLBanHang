using ShopManagement.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagement.Product
{
    public partial class ViewingProduct : Form
    {
        private bool isAdmin;
        private FlowLayoutPanel flp_Products;
        private int _currentPage = 1; // Trang hiện tại
        private int _pageSize = 10;  // Số sản phẩm mỗi trang
        private int _totalRecords = 0; // Tổng số sản phẩm
        private int _totalPages = 0;  // Tổng số trang

        public ViewingProduct(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            if (!isAdmin)
                btn_AddProduct.Visible = false;
            LoadBrands();
            LoadPagedProducts();
            trackBarPrice.Value = 500000;
            lblPriceRange.Text = $"Giá từ: 0 đến {trackBarPrice.Value} VND";
        }

        private void LoadBrands()
        {
            using (var context = new AppDbContext())
            {
                // Lấy danh sách tất cả các Brand từ cơ sở dữ liệu
                var brands = context.Brands.OrderBy(b => b.Name).ToList();

                // Thêm một item mặc định cho ComboBox, ví dụ "Tất cả"
                cmbBrandFilter.Items.Clear();
                cmbBrandFilter.Items.Add(new { Id = (int?)null, Name = "Tất cả" });

                // Thêm các Brand vào ComboBox
                foreach (var brand in brands)
                {
                    cmbBrandFilter.Items.Add(new { Id = brand.BrandId, Name = brand.Name });
                }

                // Cấu hình các thuộc tính của ComboBox
                cmbBrandFilter.DisplayMember = "Name";  // Hiển thị tên Brand
                cmbBrandFilter.ValueMember = "Id";      // Lưu trữ Id của Brand

                // Chọn item mặc định
                cmbBrandFilter.SelectedIndex = 0; // Mặc định chọn "Tất cả"
            }
        }

        private void cmbBrandFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPage = 1; // Reset lại trang về đầu tiên
            LoadPagedProducts(); // Gọi lại phương thức tải sản phẩm
        }


        // Sử dụng LINQ để lấy danh sách sản phẩm
        private void LoadPagedProducts()
        {
            using (var context = new AppDbContext())
            {
                // Lấy BrandId được chọn từ ComboBox
                var selectedBrand = cmbBrandFilter.SelectedItem as dynamic;
                int? brandId = selectedBrand?.Id;

                // Lọc sản phẩm theo Brand và Giá
                var productsQuery = context.Products.AsQueryable();

                // Lọc theo Brand
                if (brandId.HasValue)
                {
                    productsQuery = productsQuery.Where(p => p.BrandId == brandId.Value);
                }

                // Lọc theo giá trị của TrackBar (Giá tối đa)
                int maxPrice = trackBarPrice.Value;
                productsQuery = productsQuery.Where(p => p.Price <= maxPrice); // Lọc sản phẩm có giá nhỏ hơn hoặc bằng giá trị TrackBar

                // Tổng số sản phẩm
                _totalRecords = productsQuery.Count();

                // Tính số trang
                _totalPages = (int)Math.Ceiling((double)_totalRecords / _pageSize);

                // Lấy sản phẩm cho trang hiện tại
                var products = productsQuery
                    .OrderBy(p => p.ProductId)
                    .Skip((_currentPage - 1) * _pageSize) // Bỏ qua sản phẩm của các trang trước
                    .Take(_pageSize)                     // Lấy đúng số sản phẩm của trang hiện tại
                    .ToList();

                // Cập nhật giao diện
                flp_Products.Controls.Clear(); // Xóa các sản phẩm cũ

                foreach (var product in products)
                {
                    var productCard = new ProductCard();
                    productCard.SetProduct(product); // Cung cấp thông tin sản phẩm
                    flp_Products.Controls.Add(productCard); // Thêm card vào FlowLayoutPanel
                }

                // Cập nhật thông tin trang
                lbl_PageInfo.Text = $"Trang {_currentPage}/{_totalPages}";
            }
        }


        // Phân trang
        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadPagedProducts();
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadPagedProducts();
            }
        }

        // Tìm kiếm sản phẩm
        private void Search_Product()
        {
            string keyword = txtSearch.Text.Trim();

            using (var context = new AppDbContext())
            {
                var products = context.Products
                    .Where(p => p.ProductName.Contains(keyword))
                    .OrderBy(p => p.ProductId)
                    .Take(_pageSize)  // Lấy một số lượng sản phẩm giới hạn theo tìm kiếm
                    .ToList();

                flp_Products.Controls.Clear();

                foreach (var product in products)
                {
                    var productCard = new ProductCard();
                    productCard.SetProduct(product);  // Cung cấp thông tin sản phẩm
                    flp_Products.Controls.Add(productCard); // Thêm card vào FlowLayoutPanel
                }
            }
        }

        // Tìm kiếm khi người dùng nhập vào ô tìm kiếm
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            Search_Product(); // Gọi lại phương thức tìm kiếm
        }

        // Thêm sản phẩm mới
        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            new ImportBill.btnAddBrand().ShowDialog();
            LoadPagedProducts(); // Cập nhật danh sách sau khi thêm sản phẩm
        }

        private void trackBarPrice_Scroll(object sender, EventArgs e)
        {
            // Cập nhật giá trị Label khi kéo TrackBar
            lblPriceRange.Text = $"Giá từ: 0 đến {trackBarPrice.Value} VND";
            _currentPage = 1; // Reset lại trang về đầu tiên
            LoadPagedProducts(); // Tải lại danh sách sản phẩm sau khi thay đổi giá
        }

        private void ViewingProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
