using Invoices.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Invoices.API.DataAccess
{
    public class InvoiceDbContext : DbContext
    {

        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {

        }
        public DbSet<Invoice> Invoices => Set<Invoice>();
    }
}
