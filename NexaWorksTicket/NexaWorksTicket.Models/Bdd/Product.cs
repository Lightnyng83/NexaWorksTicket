using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Data;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int VersionId { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ProductsVersion Version { get; set; } = null!;
}
