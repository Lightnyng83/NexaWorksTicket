using NexaWorksTicket.Models.Bdd;

namespace NexaWorksTicket.Core.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetTicketsAsync(FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductAsync(int productId, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductAndVersionAsync(int productId, string version, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductInPeriodAsync(int productId, DateTime start, DateTime end, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductAndVersionInPeriodAsync(int productId, string version, DateTime start, DateTime end, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsWithKeywordsAsync(List<string> keywords, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductWithKeywordsAsync(int productId, List<string> keywords, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductAndVersionWithKeywordsAsync(int productId, string version, List<string> keywords, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductInPeriodWithKeywordsAsync(int productId, DateTime start, DateTime end, List<string> keywords, FixingStatus status = FixingStatus.Open);
        Task<List<Ticket>> GetTicketsByProductAndVersionInPeriodWithKeywordsAsync(int productId, int versionId, DateTime start, DateTime end, List<string> keywords, FixingStatus status = FixingStatus.Open);
    }
}
