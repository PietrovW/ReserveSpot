using ReserveSpot.Domain.Shared.Events;

namespace ReserveSpot.Application.Shared.Interfaces;
public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
