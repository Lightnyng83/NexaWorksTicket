using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Models.Bdd;

public partial class Os
{
    public int OsId { get; set; }

    public string OsName { get; set; } = null!;

    public virtual ICollection<ProductVersionOs> ProductVersionOs { get; set; } = new List<ProductVersionOs>();
}
