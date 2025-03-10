using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NexaWorksTicket.Data;
using NexaWorksTicket.Models.Bdd;

namespace NexaWorksTicket.Core.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContext;

        public TicketRepository(IDbContextFactory<AppDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Ticket> GetAllTickets()
        {
            var context = _dbContext.CreateDbContext();
            return context.Tickets.Include(x => x.ProductVersionOs).AsQueryable();
        }
    }
}
