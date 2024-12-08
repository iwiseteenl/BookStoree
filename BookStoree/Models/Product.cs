using System;
using System.Collections.Generic;

namespace BookStoree.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? NameProduct { get; set; }

    public string? Price { get; set; }

    public int? SupplierId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Supplier? Supplier { get; set; }
}
