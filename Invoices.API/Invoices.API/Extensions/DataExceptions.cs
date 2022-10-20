
using Invoices.API.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Invoices.API.Extensions
{
    public static class DataExceptions
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();
            db.Database.Migrate();
            return app;
        }
    }
}
