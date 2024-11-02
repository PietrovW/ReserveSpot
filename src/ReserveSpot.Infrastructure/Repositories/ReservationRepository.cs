using ReserveSpot.Application.Reservation.V1.Queries.Repository;
using ReserveSpot.Domain.Models.Reservations;
using ReserveSpot.Domain.Repositories;
using ReserveSpot.Infrastructure.Persistence;
using ReserveSpot.Infrastructure.Shared.Repositories;

namespace ReserveSpot.Infrastructure.Repositories;
internal sealed class ReservationRepository : DataRepository<ReserveSpotDbContext, Domain.Models.Reservations.Reservation>,
      IReservationDomainRepository,
    IReservationQueryRepository
{
    public ReservationRepository(ReserveSpotDbContext db)
      : base(db) {
    
    
    }

    public Task Delete(long id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<Reservation> Find(long id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<Reservation> GetDetailsById(long id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
