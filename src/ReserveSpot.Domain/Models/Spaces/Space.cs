using ReserveSpot.Domain.Shared;

namespace ReserveSpot.Domain.Models.Spaces;
public class Space : Entity, IAggregateRoot
{
    public required long Id
    {
        get; init;
    }
    public required string Location
    {
        get; init;
    }
    public required bool IsAvailable
    {
        get; init;
    }
}
