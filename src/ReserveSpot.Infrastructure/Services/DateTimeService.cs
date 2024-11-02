using ReserveSpot.Application.Shared.Interfaces;

namespace ReserveSpot.Infrastructure.Services;
internal sealed class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
