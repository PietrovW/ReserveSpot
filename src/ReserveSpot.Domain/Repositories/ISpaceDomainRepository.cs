using ReserveSpot.Domain.Models.Spaces;
using ReserveSpot.Domain.Shared;

namespace ReserveSpot.Domain.Repositories;
public interface ISpaceDomainRepository : IDomainRepository<Space>
{
    Task<Space> Find(long id, CancellationToken cancellationToken = default);
    Task Delete(long id, CancellationToken cancellationToken = default);
}
