using NexaWorksTicket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaWorksTicket.Core.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _dbContext;

        public TicketRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Ticket> GetAllTickets()
        {
            return _dbContext.Tickets.AsQueryable();
        }
    }
}
