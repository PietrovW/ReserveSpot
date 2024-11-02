using ReserveSpot.Domain.Shared.Events;

namespace ReserveSpot.Domain.Shared;
public interface IEntity
{
    //public IReadOnlyCollection<IDomainEvent> Events { get; set; }
  

    public void ClearEvents();
}
