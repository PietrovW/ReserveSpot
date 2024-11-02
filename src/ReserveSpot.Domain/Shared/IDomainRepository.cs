namespace ReserveSpot.Domain.Shared;
public interface IDomainRepository<TEntity>
    where TEntity : IAggregateRoot
{
    Task SaveAsync(TEntity entity, CancellationToken cancellationToken = default);
}
