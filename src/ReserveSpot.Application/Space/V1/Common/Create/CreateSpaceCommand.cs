using Wolverine;

namespace ReserveSpot.Application.Space.V1.Common.Create;
public record CreateSpaceCommand(string location) : ICommand;
