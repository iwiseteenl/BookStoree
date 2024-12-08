using System;
using System.Collections.Generic;

namespace BookStoree.Models;

public partial class Supplier
{
    public int SipplierId { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
