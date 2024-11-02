using ReserveSpot.Domain.Shared.Events;

namespace ReserveSpot.Domain.Events.Reservation.V1;
public sealed class ReservationCreatedEvent : IDomainEvent
{
    public required long Id { get; set; }
    public required string Name
    {
        get; init;
    }
    public required long LocationSpaceId
    {
        get; init;
    }

    public DateTimeOffset BookingDate
    {
        get; init;
    }

    public DateTimeOffset? StartTime
    {
        get; init;
    }

    public DateTimeOffset? EndTime
    {
        get; init;
    }
}
