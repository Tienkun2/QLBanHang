using System;
using System.Collections.Generic;

namespace ShopManagement.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<ImportBill> ImportBills { get; set; } = new List<ImportBill>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
