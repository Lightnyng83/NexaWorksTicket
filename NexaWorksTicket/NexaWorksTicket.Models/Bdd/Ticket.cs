using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Data;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int ProductId { get; set; }

    public DateOnly CreationDate { get; set; }

    public DateOnly? FixingDate { get; set; }

    public FixingStatus FixingStatus { get; set; } = FixingStatus.Open;

    public string Problem { get; set; } = null!;

    public string? ResolutionReport { get; set; }

    public virtual Product Product { get; set; } = null!;
}

public enum FixingStatus
{
    Open = 0,
    Fixed = 1,
}