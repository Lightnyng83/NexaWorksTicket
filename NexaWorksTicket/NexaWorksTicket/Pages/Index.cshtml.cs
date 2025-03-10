using Microsoft.AspNetCore.Mvc.RazorPages;
using NexaWorksTicket.Core.Services;
using NexaWorksTicket.Data;
using NexaWorksTicket.Models.Bdd;

namespace NexaWorksTicket.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITicketService _ticketService;

        public IndexModel(ILogger<IndexModel> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        public async  void OnGet()
        {
            await _ticketService.GetTicketsAsync(FixingStatus.Fixed);
             
            await _ticketService.GetTicketsByProductAsync(1, FixingStatus.Fixed);
             
            await _ticketService.GetTicketsByProductAndVersionAsync(1, "1.0", FixingStatus.Fixed);
             
            await _ticketService.GetTicketsByProductInPeriodAsync(1, DateTime.Now.AddYears(-5), DateTime.Now);
             
            await _ticketService.GetTicketsByProductAndVersionInPeriodAsync(1, "1.0", DateTime.Now.AddYears(-5), DateTime.Now, FixingStatus.Fixed);
             
            await _ticketService.GetTicketsWithKeywordsAsync(new List<string> { "le" }, FixingStatus.Fixed);
             
            await _ticketService.GetTicketsByProductWithKeywordsAsync(1, new List<string> { "le" });
             
            await _ticketService.GetTicketsByProductAndVersionWithKeywordsAsync(1, "1.0", new List<string> { "le" }, FixingStatus.Fixed);
             
            await _ticketService.GetTicketsByProductInPeriodWithKeywordsAsync(1, DateTime.Now, DateTime.Now.AddYears(-5), new List<string> { "le" }, FixingStatus.Fixed);
             
            await _ticketService.GetTicketsByProductAndVersionInPeriodWithKeywordsAsync(1, 1, DateTime.Now.AddYears(-5), DateTime.Now, new List<string> { "la" });
        }


    }
}
