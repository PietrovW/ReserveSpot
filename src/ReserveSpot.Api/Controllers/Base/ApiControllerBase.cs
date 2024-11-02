using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace ReserveSpot.Application.Shared;
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private IMessageBus? _bus;

    protected IMessageBus bus => _bus ??= HttpContext.RequestServices.GetService<IMessageBus>()!;
}
