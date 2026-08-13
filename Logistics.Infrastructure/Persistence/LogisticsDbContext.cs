using Logistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Infrastructure.Persistence;

public class LogisticsDbContext : DbContext
{
  public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options) : base(options)
  {
  }

  public DbSet<Shipment> Shipments { get; set; }
  public DbSet<Package> Packages { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}