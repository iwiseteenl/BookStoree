using System;
using System.Collections.Generic;

namespace BookStoree.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? EMail { get; set; }

    public string? PhoneNumber { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
