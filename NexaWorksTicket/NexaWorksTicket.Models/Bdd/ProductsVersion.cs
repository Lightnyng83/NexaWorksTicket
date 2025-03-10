using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Models.Bdd;

public partial class ProductsVersion
{
    public int VersionId { get; set; }

    public string Version { get; set; } = null!;

    public virtual ICollection<ProductVersionOs> ProductVersionOs { get; set; } = new List<ProductVersionOs>();
}
