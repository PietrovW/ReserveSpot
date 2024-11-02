using ReserveSpot.Domain.Shared.Events;

namespace ReserveSpot.Infrastructure.Shared.Events;
public interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent);
}
