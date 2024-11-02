using ReserveSpot.Domain.Shared;

namespace ReserveSpot.Domain.Models.Reservations;
public class Reservation : Entity, IAggregateRoot
{
    public required string Name
    {
        get;init;
    }
    public required long LocationSpaceId
    {
        get; init;
    }

    public required DateTime BookingDate
    {
        get; init;
    }

    public DateTime? StartTime
    {
        get; init;
    }

    public DateTime? EndTime
    {
        get; init;
    }
}
