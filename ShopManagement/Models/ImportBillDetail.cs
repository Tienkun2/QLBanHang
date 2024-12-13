using System;
using System.Collections.Generic;

namespace ShopManagement.Models;

public partial class ImportBillDetail
{
    public int ImportBillDetailId { get; set; }

    public int ImportBillId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual ImportBill ImportBill { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
