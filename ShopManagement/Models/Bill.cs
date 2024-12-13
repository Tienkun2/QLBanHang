using System;
using System.Collections.Generic;

namespace ShopManagement.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int StaffId { get; set; }

    public int CustomerId { get; set; }

    public decimal? SalesPercent { get; set; }

    public DateTime CreatedDate { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
