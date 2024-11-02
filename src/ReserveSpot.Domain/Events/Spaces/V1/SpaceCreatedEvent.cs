using ReserveSpot.Domain.Shared.Events;

namespace ReserveSpot.Domain.Events.Spaces.V1;

public sealed record SpaceCreatedEvent(long Id,string location) : IDomainEvent;
