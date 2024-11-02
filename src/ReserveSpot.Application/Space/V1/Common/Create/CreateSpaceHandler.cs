using ReserveSpot.Domain.Events.Spaces.V1;
using ReserveSpot.Domain.Repositories;

namespace ReserveSpot.Application.Space.V1.Common.Create;
public sealed class CreateSpaceHandler(ISpaceDomainRepository spaceDomainRepository)
{
    public async Task<SpaceCreatedEvent> Handle(CreateSpaceCommand command, CancellationToken cancellationToken = default)
    {
        ReserveSpot.Domain.Models.Spaces.Space entity = new()
        {
            Location = command.location,
            Id = 0,
            IsAvailable =false,
        };
        await spaceDomainRepository.SaveAsync(entity: entity, cancellationToken: cancellationToken);

        return new SpaceCreatedEvent(Id: entity.Id, location: entity.Location);
        
    }
}
