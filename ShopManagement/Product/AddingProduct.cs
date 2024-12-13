using ShopManagement.ImportBill;
using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagement.Product
{
    public partial class AddingProduct : Form
    {
        private int idBrand;

        // Khai báo sự kiện gửi về Import form
        public event Action<List<Models.Product>> ProductsAdded;

        // Khai báo sự kiện gửi số lượng về Import form
        public event Action<int> QuantityUpdated;

        // Khai báo sự kiện gửi tổng tiền về Import form
        public event Action<float> TotalPriceUpdated;

        private List<Models.Product> productList = new List<Models.Product>();

        private List<string> GetSelectedSizes()
        {
            return clbSizes.CheckedItems.Cast<string>().ToList();
        }


        private void LoadSizes()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var sizes = context.Sizes.Select(s => s.SizeName).ToList();
                    clbSizes.Items.AddRange(sizes.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách kích cỡ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public AddingProduct(int selectedBrand_Id)
        {
            InitializeComponent();
            idBrand = selectedBrand_Id;
            LoadBrand();
            LoadSizes();
            // Trong constructor, đăng ký sự kiện ItemCheck
            clbSizes.ItemCheck += clbSizes_ItemCheck;


            cmbBrand.SelectedValue = idBrand;
            cmbBrand.Enabled = false;
        }

        // Sử dụng Entity Framework để tải danh sách thương hiệu
        private void LoadBrand()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thương hiệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GetBrandName()
        {
            // Lấy đối tượng ẩn danh từ SelectedItem
            var selectedBrand = (dynamic)cmbBrand.SelectedItem;
            // Truy cập vào BrandId
            int selectedBrandId = selectedBrand.BrandId;

            using (var context = new AppDbContext())
            {
                // Truy vấn tên thương hiệu dựa trên selectedBrandId
                var brandName = context.Brands
                    .Where(b => b.BrandId == selectedBrandId)
                    .Select(b => b.Name)
                    .FirstOrDefault();

                //if (brandName != null)
                //{
                //    MessageBox.Show("Tên thương hiệu đã chọn: " + brandName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Không tìm thấy thương hiệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedValue != null)
            {
                GetBrandName(); // Gọi hàm để lấy tên thương hiệu khi người dùng chọn
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            btnAddProduct.Enabled = false; // Vô hiệu hóa nút để ngăn kích hoạt nhiều lần

            try
            {
                // Các bước kiểm tra và thêm sản phẩm
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtMaterial.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy danh sách kích cỡ được chọn
                var selectedSizes = GetSelectedSizes();
                if (!selectedSizes.Any())
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một kích cỡ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var size in selectedSizes)
                {
                    if (productList.Any(p => p.ProductName == txtName.Text.Trim() && p.Size == size))
                    {
                        MessageBox.Show($"Sản phẩm với kích cỡ '{size}' đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    var product = new Models.Product
                    {
                        ProductName = txtName.Text.Trim(),
                        Size = size,
                        Price = price,
                        Material = txtMaterial.Text.Trim(),
                        Quantity = quantity,
                        BrandId = Convert.ToInt32(cmbBrand.SelectedValue),
                        ImageUrl = txtImagePath.Text.Trim()
                    };

                    productList.Add(product);
                }


                // Cập nhật tổng số lượng và tổng tiền
                UpdateTotalQuantity();
                UpdateTotalPrice();

                MessageBox.Show("Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa các trường nhập liệu
                ClearInputs();
            }
            finally
            {
                btnAddProduct.Enabled = true; // Bật lại nút sau khi xử lý xong
            }
        }



        private void UpdateTotalQuantity()
        {
            int totalQuantity = productList.Sum(p => p.Quantity);
            QuantityUpdated?.Invoke(totalQuantity);
        }

        private void UpdateTotalPrice()
        {
            decimal totalPrice = productList.Sum(p => p.Quantity * p.Price);
            TotalPriceUpdated?.Invoke((float)totalPrice);
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtSize.Clear();
            txtPrice.Clear();
            txtMaterial.Clear();
            txtQuantity.Clear();
            txtImagePath.Clear();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (productList == null || productList.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào được thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kích hoạt sự kiện ProductsAdded để gửi dữ liệu về form cha
            ProductsAdded?.Invoke(productList);

            MessageBox.Show("Danh sách sản phẩm đã được gửi về.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_AddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif" // Lọc file ảnh
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName; // Lấy đường dẫn ảnh được chọn

                // Đường dẫn thư mục lưu ảnh trong dự án
                var imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "images", "product");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                }

                // Lấy tên file ảnh gốc (không sử dụng GUID)
                var fileName = Path.GetFileName(imagePath); // Lấy tên file từ đường dẫn ảnh gốc
                var filePath = Path.Combine(imageDirectory, fileName);

                // Kiểm tra nếu file đã tồn tại, thay đổi tên file nếu cần (tránh ghi đè)
                if (File.Exists(filePath))
                {
                    // Tạo tên mới bằng cách thêm số đếm vào tên file
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var count = 1;

                    // Tạo tên file mới nếu trùng lặp
                    while (File.Exists(filePath))
                    {
                        var newFileName = $"{fileNameWithoutExtension}({count}){fileExtension}";
                        filePath = Path.Combine(imageDirectory, newFileName);
                        count++;
                    }
                }

                // Sao chép ảnh vào thư mục
                File.Copy(imagePath, filePath);

                // Lưu đường dẫn tương đối vào TextBox
                var imageUrl = Path.Combine("images", "product", fileName).Replace("\\", "/");
                txtImagePath.Text = imageUrl; // Hiển thị đường dẫn vào TextBox

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm ảnh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void clbSizes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Sử dụng BeginInvoke để đảm bảo trạng thái Checked đã được cập nhật
            this.BeginInvoke(new Action(() =>
            {
                // Lấy danh sách các kích cỡ được chọn
                var selectedSizes = GetSelectedSizes();

                // Cập nhật txtSize.Text (hiển thị các kích cỡ được chọn)
                txtSize.Text = string.Join(", ", selectedSizes);

            }));
        }


        private void UpdateProductListWithSizes(List<string> selectedSizes)
        {
            foreach (var size in selectedSizes)
            {
                // Kiểm tra sản phẩm đã tồn tại chưa
                if (productList.Any(p => p.ProductName == txtName.Text.Trim() && p.Size == size))
                {
                    continue; // Nếu sản phẩm đã tồn tại, bỏ qua
                }

                var product = new Models.Product
                {
                    ProductName = txtName.Text.Trim(),
                    Size = size,
                    Price = decimal.Parse(txtPrice.Text),
                    Material = txtMaterial.Text.Trim(),
                    Quantity = int.Parse(txtQuantity.Text),
                    BrandId = Convert.ToInt32(cmbBrand.SelectedValue),
                    ImageUrl = txtImagePath.Text.Trim()
                };

                // Thêm sản phẩm mới vào danh sách
                productList.Add(product);
            }

            // Cập nhật lại tổng số lượng và tổng tiền
            UpdateTotalQuantity();
            UpdateTotalPrice();
        }

    }
}
