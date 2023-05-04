
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRA.Jobs.Application.Contracts.VacancyCategories.Commands;
using MRA.Jobs.Application.Contracts.VacancyCategories.Queries;

namespace MRA.Jobs.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ApiControllerBase
{
    private readonly ILogger<OidcConfigurationController> _logger;

    public CategoryController(ILogger<OidcConfigurationController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await Mediator.Send(new GetVacancyCategoriesQuery());
        return Ok(categories);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = Mediator.Send(new GetByIdVacancyCategoryQuery { Id = id });
        return Ok(category);
    }
    [HttpPost]
    public async Task<IActionResult> Add(CreateVacancyCategoryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }
    [HttpPut]
    public async Task<IActionResult>Update(UpdateVacancyCategoryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteVacancyCategoryCommand { Id = id }, cancellationToken);
        return Ok();
    }
}
