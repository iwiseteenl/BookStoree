using System;
using System.Collections.Generic;

namespace BookStoree.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ClientId { get; set; }

    public int? ProductId { get; set; }

    public int? Status { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Product? Product { get; set; }
}
