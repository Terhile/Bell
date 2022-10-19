using AssetsManager.API.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AssetsManager.API.Extensions
{
    public static class DataExceptions
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AssetsManagerDbContext>();
            db.Database.Migrate();
            return app;
        }
    }
}
