using ReserveSpot.Domain.Models.Reservations;
using ReserveSpot.Domain.Shared;

namespace ReserveSpot.Domain.Repositories;
public interface IReservationDomainRepository : IDomainRepository<Reservation>
{
    Task<Reservation> Find(long id, CancellationToken cancellationToken = default);
    Task Delete(long id, CancellationToken cancellationToken = default);
}
