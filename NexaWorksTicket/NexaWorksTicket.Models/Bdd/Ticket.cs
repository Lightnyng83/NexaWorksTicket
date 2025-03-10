using System;
using System.Collections.Generic;

namespace NexaWorksTicket.Models.Bdd;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int ProductVersionOsId { get; set; }

    public DateOnly CreationDate { get; set; }

    public DateOnly? FixingDate { get; set; }

    public FixingStatus FixingStatus { get; set; }

    public string? Problem { get; set; }

    public string? ResolutionReport { get; set; }

    public virtual ProductVersionOs ProductVersionOs { get; set; } = null!;
}
public enum FixingStatus
{
    Open = 0,
    Fixed = 1,
}