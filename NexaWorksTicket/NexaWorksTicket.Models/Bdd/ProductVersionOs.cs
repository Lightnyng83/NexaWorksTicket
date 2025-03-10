using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Models.Bdd;

public partial class ProductVersionOs
{
    public int IdProductVersionOs { get; set; }

    public int IdProduct { get; set; }

    public int IdVersion { get; set; }

    public int IdOs { get; set; }

    public virtual Os IdOsNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual ProductsVersion IdVersionNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
