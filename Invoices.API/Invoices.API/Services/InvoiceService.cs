using Invoices.API.DataAccess;
using Invoices.API.HttpClients;
using Invoices.API.Interfaces;
using Invoices.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.API.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceDbContext _context;
        private readonly ILogger<InvoiceService> _logger;
        private readonly AssetsManagerServiceClient _assetsManagerService;
        public InvoiceService(InvoiceDbContext context, ILogger<InvoiceService> logger, AssetsManagerServiceClient assetsManagerService)
        {
            _context=context;
            _logger=logger;
            _assetsManagerService=assetsManagerService;

        }

        public async Task<IEnumerable<Invoice>> AllInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task GenerateInvoice(DateTime date)
        {
           var assets = await _assetsManagerService.InvoiceByDate(date);
            if (assets != null)
            {
                await _context.Invoices.AddAsync(new Invoice() { IssueDate = DateTime.Now, Total = assets.Sum(x => x.Price) });
                await _context.SaveChangesAsync();
            }
        }
    }
}
