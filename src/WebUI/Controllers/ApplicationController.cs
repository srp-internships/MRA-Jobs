﻿using Microsoft.AspNetCore.Mvc;
using MRA.Jobs.Application.Contracts.Applications.Commands;
using MRA.Jobs.Application.Contracts.Applications.Queries;
using MRA.Jobs.Application.Contracts.Applications.Responses;
using MRA.Jobs.Infrastructure.Common;

namespace MRA.Jobs.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ApiControllerBase
{
    private readonly ILogger<ApplicationController> _logger;

    public ApplicationController(ILogger<ApplicationController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<ApplicationListDTO>>> GetApplications([FromQuery] SieveQuery sieveQuery)
    {
        var query = new GetApplicationsQuery(sieveQuery);
        var applications = await Mediator.Send(query);

        return Ok(applications);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ApplicationDetailsDTO>> GetApplicationById(GetByIdApplicationQuery request, CancellationToken cancellationToken)
    {
        return await Mediator.Send(request, cancellationToken);
    }


    [HttpPost]
    public async Task<ActionResult<Guid>> CreateApplication(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        return await Mediator.Send(request, cancellationToken);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Guid>> UpdateApplication(Guid Id, UpdateApplicationCommand request, CancellationToken cancellationToken)
    {
        request.Id = Id;
        return await Mediator.Send(request, cancellationToken);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> DeleteApplication(Guid Id, CancellationToken cancellationToken)
    {
        var request = new DeleteApplicationCommand { Id = Id };
        return await Mediator.Send(request, cancellationToken);
    }
}
