using System;
using System.Collections.Generic;

namespace ShopManagement.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
