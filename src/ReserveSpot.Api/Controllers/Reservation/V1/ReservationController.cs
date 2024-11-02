using Microsoft.AspNetCore.Mvc;
using ReserveSpot.Application.Contracts.Reservation.V1;
using ReserveSpot.Application.Reservation.V1.Common.Create;
using ReserveSpot.Application.Reservation.V1.Queries.Responses;
using ReserveSpot.Application.Shared;
using ReserveSpot.Domain.Events.Reservation.V1;

namespace ReserveSpot.Api.Controllers.Reservation.V1;

public class ReservationController: ApiControllerBase
{
    /// <summary>
    /// You can search for Accounts here.
    /// </summary>

    /// <remarks>
    /// All the parameters in the request body can be null. 
    ///
    ///  You can search by using any of the parameters in the request.
    ///  
    ///  NOTE: You can only search by one parameter at a time
    ///  
    /// Sample request:
    ///
    ///     POST /Account
    ///     {
    ///        "userId": null,
    ///        "bankId": null,
    ///        "dateCreated": null
    ///     }
    ///     OR
    ///     
    ///     POST /Account
    ///     {
    ///        "userId": null,
    ///        "bankId": 000,
    ///        "dateCreated": null
    ///     } 
    /// </remarks>
    /// <param name="request"></param>
    /// <returns> This endpoint returns a list of Accounts.</returns>
    ///
    [HttpPost]
    [ProducesResponseType(typeof(ReservationResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Created(CreateReservationRequest request, CancellationToken cancellationToken)
    {
        return await bus.InvokeAsync<ReservationCreatedEvent>(message: new CreateReservationCommand(Id:0,LocationSpaceId:0,BookingDate:DateTime.Now,StartTime: DateTime.Now,EndTime:null,Name:request.Name), cancellation: cancellationToken) is ReservationCreatedEvent reservationCreated ?
         Results.Created($"/exceptionInfoItems/{reservationCreated.Id}", request) : Results.BadRequest();
     }
}


//dotnet ef migrations add InitialMigration --context "StatisticsDbContext" --project Statistics/Statistics.Infrastructure --startup-project ProjectStartup