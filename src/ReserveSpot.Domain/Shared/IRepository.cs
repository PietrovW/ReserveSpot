namespace ReserveSpot.Domain.Shared;
public interface IRepository<in TEntity> where TEntity : IAggregateRoot
{
    Task Save(TEntity entity);
}
