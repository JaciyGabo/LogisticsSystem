using Logistics.Domain.Entities;

namespace Logistics.Domain.Repositories;

public interface IPackageRepository
{
    Task AddAsync(Package package);
    Task SaveChangesAsync();
}