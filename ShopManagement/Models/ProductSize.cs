using System;
using System.Collections.Generic;

namespace ShopManagement.Models;

public partial class ProductSize
{
    public int ProductSizeId { get; set; }

    public int? ProductId { get; set; }

    public int? SizeId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
