using Wolverine;
namespace ReserveSpot.Application.Reservation.V1.Common.Create;
public record CreateReservationCommand(long Id, long LocationSpaceId, DateTime BookingDate, DateTime StartTime, DateTime? EndTime, string Name) : ICommand;

