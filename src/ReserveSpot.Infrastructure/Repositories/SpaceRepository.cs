using ReserveSpot.Application.Space.V1.Queries.Repository;
using ReserveSpot.Domain.Repositories;
using ReserveSpot.Infrastructure.Persistence;
using ReserveSpot.Infrastructure.Shared.Repositories;

namespace ReserveSpot.Infrastructure.Repositories;
internal sealed class SpaceRepository : DataRepository<ReserveSpotDbContext, Domain.Models.Spaces.Space>,
      ISpaceDomainRepository,
    ISpaceQueryRepository
{
    public SpaceRepository(ReserveSpotDbContext db)
      : base(db) { }

    public Task Delete(long id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<Domain.Models.Spaces.Space> Find(long id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<Domain.Models.Spaces.Space> GetDetailsById(long id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
