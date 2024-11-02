using Microsoft.AspNetCore.Mvc;
using ReserveSpot.Application.Contracts.Space.V1;
using ReserveSpot.Application.Reservation.V1.Queries.Responses;
using ReserveSpot.Application.Shared;
using ReserveSpot.Domain.Events.Spaces.V1;

namespace ReserveSpot.Api.Controllers.Space.V1;


public class SpaceController : ApiControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ReservationResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Created(CreateSpaceRequest request, CancellationToken cancellationToken)
    {
        return await bus.InvokeAsync<SpaceCreatedEvent>(message: new SpaceCreatedEvent(Id:0,location: request.Location), cancellation: cancellationToken) is SpaceCreatedEvent spaceCreated ?
         Results.Created($"/exceptionInfoItems/{spaceCreated.Id}", request) : Results.BadRequest();
    }
}
