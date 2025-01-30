using Microsoft.AspNetCore.Mvc.RazorPages;
using NexaWorksTicket.Core.Services;
using NexaWorksTicket.Data;

namespace NexaWorksTicket.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITicketService _ticketService;

        public IndexModel(ILogger<IndexModel> logger , ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        public void OnGet()
        {
            _ticketService.GetTicketsAsync(FixingStatus.Fixed);
            _ticketService.GetTicketsByProductAsync(1, FixingStatus.Fixed);
            _ticketService.GetTicketsByProductAndVersionAsync(1, "1.0", FixingStatus.Fixed);
            _ticketService.GetTicketsByProductInPeriodAsync(1, DateTime.Now.AddYears(-5), DateTime.Now);
            _ticketService.GetTicketsByProductAndVersionInPeriodAsync(1, "1.0", DateTime.Now.AddYears(-5), DateTime.Now, FixingStatus.Fixed);
            _ticketService.GetTicketsWithKeywordsAsync(new List<string> { "le" }, FixingStatus.Fixed);
            _ticketService.GetTicketsByProductWithKeywordsAsync(1, new List<string> { "le" });
            _ticketService.GetTicketsByProductAndVersionWithKeywordsAsync(1, "1.0", new List<string> { "le" }, FixingStatus.Fixed);
            _ticketService.GetTicketsByProductInPeriodWithKeywordsAsync(1, DateTime.Now, DateTime.Now.AddYears(-5), new List<string> { "le" }, FixingStatus.Fixed);
            _ticketService.GetTicketsByProductAndVersionInPeriodWithKeywordsAsync(1, 1, DateTime.Now.AddYears(-5), DateTime.Now, new List<string> { "la" });
        }
    }
}
