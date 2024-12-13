using System;
using System.Collections.Generic;

namespace ShopManagement.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Size { get; set; } = null!;

    public decimal Price { get; set; }

    public string Material { get; set; } = null!;

    public int Quantity { get; set; }

    public int BrandId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; } = new List<ImportBillDetail>();

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new List<WarehouseProduct>();
}
