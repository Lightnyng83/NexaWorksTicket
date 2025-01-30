using Microsoft.EntityFrameworkCore;
using NexaWorksTicket.Core.Repositories;
using NexaWorksTicket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _ticketRepository.GetAllTickets().Where(t => t.ProductId == productId && t.FixingStatus == status).ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductAndVersionAsync(int productId, string version, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.ProductId == productId && t.Product.Version.Version == version && t.FixingStatus == status)
                                          .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductInPeriodAsync(int productId, DateTime start, DateTime end, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.ProductId == productId && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.FixingStatus == status)
                                          .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByProductAndVersionInPeriodAsync(int productId, string version, DateTime start, DateTime end, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.ProductId == productId && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.Product.Version.ToString() == version && t.FixingStatus == status)
                                          .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsWithKeywordsAsync(List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return await _ticketRepository.GetAllTickets()
                                          .Where(t => t.FixingStatus == status && keywords.Any(keyword => t.Problem.Contains(keyword)))
                                          .ToListAsync();
        }

        public Task<List<Ticket>> GetTicketsByProductWithKeywordsAsync(int productId, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return _ticketRepository.GetAllTickets()
                                     .Where(t => t.FixingStatus == status && t.ProductId == productId && keywords.Any(keyword => t.Problem.Contains(keyword)))
                                     .ToListAsync();
        }

        public Task<List<Ticket>> GetTicketsByProductAndVersionWithKeywordsAsync(int productId, string version, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return _ticketRepository.GetAllTickets()
                                    .Where(t => t.FixingStatus == status && t.ProductId == productId && t.Product.Version.Version == version && keywords.Any(keyword => t.Problem.Contains(keyword)))
                                    .ToListAsync();
        }

        public Task<List<Ticket>> GetTicketsByProductInPeriodWithKeywordsAsync(int productId, DateTime start, DateTime end, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return _ticketRepository.GetAllTickets()
                                                .Include(t => t.Product)
                                                .Include(v => v.Product.Version)
                                                .Where(t => t.ProductId == productId && keywords.Any(keyword => t.Problem.Contains(keyword) && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.FixingStatus == status))
                                                .ToListAsync();
        }

        public Task<List<Ticket>> GetTicketsByProductAndVersionInPeriodWithKeywordsAsync(int productId, int versionId, DateTime start, DateTime end, List<string> keywords, FixingStatus status = FixingStatus.Open)
        {
            return _ticketRepository.GetAllTickets()
                                    .Include(t => t.Product)
                                    .Include(v => v.Product.Version)
                                    .Where(t => t.ProductId == productId && t.Product.VersionId == versionId && keywords.Any(keyword => t.Problem.Contains(keyword) && t.CreationDate >= DateOnly.FromDateTime(start) && t.CreationDate <= DateOnly.FromDateTime(end) && t.FixingStatus == status))
                                    .ToListAsync();
        }
        #endregion
    }

}
