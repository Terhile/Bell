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
        public async Task<ActionResult> Invoices()
        {

            var invoices =await _invoiceService.AllInvoices();
            return Ok(invoices);
        }
        [HttpPost("/invoices/{date:DateTime}")]
        public async Task<ActionResult> GenerateInvoice(DateTime date)
        {

            await _invoiceService.GenerateInvoice(date);
            return Created("/invoices","");
        }
    }
}
