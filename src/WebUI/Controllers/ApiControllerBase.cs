using MediatR;

namespace MRA.Jobs.Web.Controllers;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
