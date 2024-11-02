using Microsoft.EntityFrameworkCore;
using ReserveSpot.Domain.Shared;

namespace ReserveSpot.Infrastructure.Shared.Repositories;
public abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
    where TDbContext : DbContext
    where TEntity : Entity, IAggregateRoot
{
    protected DataRepository(TDbContext db) => Data = db;

    protected TDbContext Data
    {
        get;
    }

    protected IQueryable<TEntity> All() => Data.Set<TEntity>();

    protected IQueryable<TEntity> AllAsNoTracking() => All().AsNoTracking();

    public async Task SaveAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Data.Update(entity);
            await Data.AddAsync(entity,cancellationToken: cancellationToken);
          //  Data.SaveChanges();
           
             await Data.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
        }
    }
}