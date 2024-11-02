using ReserveSpot.Application.Shared.Interfaces;

namespace ReserveSpot.Application.Reservation.V1.Queries.Repository;
public interface IReservationQueryRepository : IQueryRepository<Domain.Models.Reservations.Reservation>
{
    Task<Domain.Models.Reservations.Reservation> GetDetailsById(long id, CancellationToken cancellationToken = default);
}
