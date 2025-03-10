using Microsoft.EntityFrameworkCore;
using NexaWorksTicket.Core.Repositories;
using NexaWorksTicket.Models.Bdd;

namespace NexaWorksTicket.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }


        #region ----- Optimized Method-----
        public async Task<List<Ticket>> GetTicketsAsync(FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets().Where(t => t.FixingStatus == status).ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductAsync(int productId, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets().Where(t => t.ProductVersionOs.IdProduct == productId && t.FixingStatus == status).ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductAndVersionAsync(int productId, string version, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.ProductVersionOs.IdProduct == productId && t.ProductVersionOs.IdVersionNavigation.Version == version && t.FixingStatus == status)
                                          .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductInPeriodAsync(int productId, DateTime start, DateTime end, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.ProductVersionOs.IdProduct == productId && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.FixingStatus == status)
                                          .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductAndVersionInPeriodAsync(int productId, string version, DateTime start, DateTime end, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.ProductVersionOs.IdProduct == productId && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.ProductVersionOs.IdVersionNavigation.Version.ToString() == version && t.FixingStatus == status)
                                          .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsWithKeywordsAsync(List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.FixingStatus == status && keywords.Any(keyword => t.Problem.Contains(keyword)))
                                          .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductWithKeywordsAsync(int productId, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                     .Where(t => t.FixingStatus == status && t.ProductVersionOs.IdProduct == productId && keywords.Any(keyword => t.Problem.Contains(keyword)))
                                     .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductAndVersionWithKeywordsAsync(int productId, string version, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                    .Where(t => t.FixingStatus == status && t.ProductVersionOs.IdProduct == productId && t.ProductVersionOs.IdVersionNavigation.Version == version && keywords.Any(keyword => t.Problem.Contains(keyword)))
                                    .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductInPeriodWithKeywordsAsync(int productId, DateTime start, DateTime end, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                               
                                                .Where(t => t.ProductVersionOs.IdProduct == productId && keywords.Any(keyword => t.Problem.Contains(keyword) && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.FixingStatus == status))
                                                .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductAndVersionInPeriodWithKeywordsAsync(int productId, int versionId, DateTime start, DateTime end, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                    .Where(t => t.ProductVersionOs.IdProduct == productId && t.ProductVersionOs.IdVersionNavigation.VersionId == versionId && keywords.Any(keyword => t.Problem.Contains(keyword) && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.FixingStatus == status))
                                    .ToListAsync();
        }
        #endregion
    }

}
