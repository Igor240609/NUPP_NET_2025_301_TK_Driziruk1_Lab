using Microsoft.EntityFrameworkCore;
using TechnologiesOnPlatformNET.Infrastructure.Models;

namespace TechnologiesOnPlatformNET.Infrastructure.Context
{
    public class TechnologiesDbContext : DbContext
    {
        public DbSet<DotNetTechnologyModel> DotNetTechnologies { get; set; }
        public DbSet<WebTechnologyModel> WebTechnologies { get; set; }
        public DbSet<AspNetCoreModel> AspNetCores { get; set; }

        public TechnologiesDbContext(DbContextOptions<TechnologiesDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:1 — DotNetTechnology <-> WebTechnology
            modelBuilder.Entity<DotNetTechnologyModel>()
                .HasOne(d => d.WebTechnology)
                .WithOne(w => w.DotNetTechnology)
                .HasForeignKey<WebTechnologyModel>(w => w.DotNetTechnologyId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:1 — WebTechnology <-> AspNetCore
            modelBuilder.Entity<WebTechnologyModel>()
                .HasOne(w => w.AspNetCore)
                .WithOne(a => a.WebTechnology)
                .HasForeignKey<AspNetCoreModel>(a => a.WebTechnologyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}