
namespace ReserveSpot.Application.Contracts.Space.V1;
internal record SpaceResponse
{
    public long Id 
    { 
        get; init; 
    }
    public string Location 
    { 
        get; init; 
    }
    public bool IsAvailable
    {
        get; init;
    }
}
