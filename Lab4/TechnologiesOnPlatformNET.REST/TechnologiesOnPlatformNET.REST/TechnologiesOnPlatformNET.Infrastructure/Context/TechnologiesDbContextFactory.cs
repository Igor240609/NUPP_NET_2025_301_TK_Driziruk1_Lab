using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TechnologiesOnPlatformNET.Infrastructure.Context
{
    public class TechnologiesDbContextFactory : IDesignTimeDbContextFactory<TechnologiesDbContext>
    {
        public TechnologiesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TechnologiesDbContext>();
            builder.UseSqlite("Data Source=technologies.db");
            return new TechnologiesDbContext(builder.Options);
        }
    }
}