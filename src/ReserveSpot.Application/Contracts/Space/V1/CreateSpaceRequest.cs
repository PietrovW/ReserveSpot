namespace ReserveSpot.Application.Contracts.Space.V1;

public sealed record CreateSpaceRequest
{
    public required string Location
    {
        get; init;
    }
}
