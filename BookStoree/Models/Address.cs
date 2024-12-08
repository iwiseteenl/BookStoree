using System;
using System.Collections.Generic;

namespace BookStoree.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
