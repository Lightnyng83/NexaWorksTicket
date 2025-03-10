using NexaWorksTicket.Models.Bdd;

namespace NexaWorksTicket.Core.Repositories
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetAllTickets();
    }
}
