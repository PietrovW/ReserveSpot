using ReserveSpot.Application.Shared.Interfaces;

namespace ReserveSpot.Application.Space.V1.Queries.Repository;
public interface ISpaceQueryRepository : IQueryRepository<Domain.Models.Spaces.Space>
{
}
