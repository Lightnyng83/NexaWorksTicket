using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Data;

public partial class Os
{
    public int OsId { get; set; }

    public string OsName { get; set; } = null!;

    public virtual ICollection<ProductsVersion> ProductsVersions { get; set; } = new List<ProductsVersion>();
}
