using System;
using System.Collections.Generic;

namespace ShopManagement.Models;

public partial class ImportBill
{
    public int ImportBillId { get; set; }

    public int BrandId { get; set; }

    public decimal? TotalPayment { get; set; }

    public DateTime ImportDate { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; } = new List<ImportBillDetail>();
}
