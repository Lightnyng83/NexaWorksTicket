using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Data;

public partial class ProductsVersion
{
    public int VersionId { get; set; }

    public string Version { get; set; } = null!;

    public int OsId { get; set; }

    public virtual Os Os { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
