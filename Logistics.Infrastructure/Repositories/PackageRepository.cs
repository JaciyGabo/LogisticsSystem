using Logistics.Domain.Entities;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Persistence;

namespace Logistics.Infrastructure.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly LogisticsDbContext _context;

    public PackageRepository(LogisticsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Package package)
    {
        await _context.Packages.AddAsync(package);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}