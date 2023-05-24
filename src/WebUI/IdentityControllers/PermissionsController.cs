using MediatR;
using Microsoft.AspNetCore.Mvc;
using MRA.Jobs.Application.Contracts.Common;
using MRA.Jobs.Infrastructure.Shared.Pemission.Responces;
using MRA.Jobs.Web.Controllers;

namespace MRA.Jobs.Web.IdentityControllers;

public class PermissionsController : AuthApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaggedList<PermissionResponse>>> Get([FromQuery] PaggedListQuery<PermissionResponse> request)
    {
        return Ok(await Mediator.Send(request));
    }
}