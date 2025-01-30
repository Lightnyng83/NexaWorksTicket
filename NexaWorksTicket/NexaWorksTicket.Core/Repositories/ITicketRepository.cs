using NexaWorksTicket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaWorksTicket.Core.Repositories
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetAllTickets();
    }
}
