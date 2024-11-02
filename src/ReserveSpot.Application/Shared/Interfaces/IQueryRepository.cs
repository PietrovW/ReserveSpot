using ReserveSpot.Domain.Shared;

namespace ReserveSpot.Application.Shared.Interfaces;
public interface IQueryRepository<in TEntity>
    where TEntity : IAggregateRoot
{
}
