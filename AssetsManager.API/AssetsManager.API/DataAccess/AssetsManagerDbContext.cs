using AssetsManager.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AssetsManager.API.DataAccess
{
    public class AssetsManagerDbContext : DbContext
    {

        public AssetsManagerDbContext(DbContextOptions<AssetsManagerDbContext> options) : base(options)
        {

        }
        public DbSet<Asset> Assets => Set<Asset>();
    }
}