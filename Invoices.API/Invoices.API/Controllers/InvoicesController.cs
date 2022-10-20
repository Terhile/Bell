using Invoices.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InvoicesController : Controller
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly IInvoiceService _invoiceService;
        public InvoicesController(ILogger<InvoicesController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }
        [HttpGet("/invoices")]
        public async Task<ActionResult> Invoices(DateTime date)
        {

            await _invoiceService.GenerateInvoice(date);
            return Created("/invoices", "");
        }
        [HttpPost("/invoices/{date}")]
        public async Task<ActionResult> GenerateInvoice(DateTime date)
        {

            await _invoiceService.GenerateInvoice(date);
            return Created("/invoices","");
        }
    }
}
