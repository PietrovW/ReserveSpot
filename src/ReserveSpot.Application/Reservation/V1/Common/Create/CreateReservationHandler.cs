using ReserveSpot.Domain.Events.Reservation.V1;
using ReserveSpot.Domain.Repositories;

namespace ReserveSpot.Application.Reservation.V1.Common.Create;
public sealed class CreateReservationHandler(IReservationDomainRepository reservationDomainRepository)
{
    public async Task<ReservationCreatedEvent> Handle(CreateReservationCommand command, CancellationToken cancellationToken = default)
      {
        ReserveSpot.Domain.Models.Reservations.Reservation entity = new ()
        {
            LocationSpaceId= command.LocationSpaceId,
            BookingDate= command.BookingDate,
            EndTime= command.EndTime,
            Name= command.Name,
        };
        await reservationDomainRepository.SaveAsync(entity: entity, cancellationToken: cancellationToken);
        
        return new ReservationCreatedEvent()
        {

            LocationSpaceId = command.LocationSpaceId,
            BookingDate = command.BookingDate,
            EndTime = command.EndTime,
            Name = command.Name,
            Id = entity.Id
        };
    }
}
