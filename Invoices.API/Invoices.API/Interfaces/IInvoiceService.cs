using Invoices.API.Models;

namespace Invoices.API.Interfaces
{
    public interface IInvoiceService
    {
        public Task GenerateInvoice(DateTime date);
        public Task<IEnumerable<Invoice>> AllInvoices();
    }
}
