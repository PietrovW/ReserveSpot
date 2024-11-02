namespace ReserveSpot.Application.Contracts.Reservation.V1;
internal record ReservationResponse
{
    public long Id
    {
        get; init;
    }

    public long LocationSpaceId
    {
        get;init;
    }

    public DateTimeOffset BookingDate
    {
        get; init;
    }

    public DateTimeOffset StartTime
    {
        get; init;
    }

    public DateTimeOffset EndTime
    {
        get; init;
    }
}
