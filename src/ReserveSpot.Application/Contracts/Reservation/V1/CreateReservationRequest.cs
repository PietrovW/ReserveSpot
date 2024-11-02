namespace ReserveSpot.Application.Contracts.Reservation.V1;
public record CreateReservationRequest
{
    public required long LocationSpaceId
    {
        get; init;
    }
    public required string Name
    {
        get; init;
    }
}
