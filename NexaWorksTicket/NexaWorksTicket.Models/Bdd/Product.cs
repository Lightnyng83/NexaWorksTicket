using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Models.Bdd;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public virtual ICollection<ProductVersionOs> ProductVersionOs { get; set; } = new List<ProductVersionOs>();
}
