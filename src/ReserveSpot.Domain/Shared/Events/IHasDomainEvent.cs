namespace ReserveSpot.Domain.Shared.Events;
public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents
    {
        get;
    }
}