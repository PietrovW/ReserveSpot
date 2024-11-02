namespace ReserveSpot.Domain.Shared.Events;
public abstract class DomainEvent
{
    protected DomainEvent()
    {
        DateOccurred = DateTime.Now;
    }

    public bool IsPublished
    {
        get; set;
    }
    public DateTime DateOccurred { get; protected set; } = DateTime.Now;
}
