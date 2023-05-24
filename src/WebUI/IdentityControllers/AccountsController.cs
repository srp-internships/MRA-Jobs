using MediatR;
using Microsoft.AspNetCore.Mvc;
using MRA.Jobs.Infrastructure.Shared.Users.Commands;
using MRA.Jobs.Infrastructure.Shared.Users.Commands.Roles;
using MRA.Jobs.Infrastructure.Shared.Users.Commands.Verifications;
using MRA.Jobs.Infrastructure.Shared.Users.Queries;
using MRA.Jobs.Web.Controllers;

namespace MRA.Jobs.Web.IdentityControllers;

using Microsoft.AspNetCore.Authorization
    ;

[Authorize]
[Route("api/[controller]")]
public class AccountsController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    #region Roles
    [HttpGet("{id}/roles")]
    public async Task<ActionResult<IEnumerable<string>>> UpdateRole([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetUserRolesQuery() { Id = id }));
    }

    [HttpPost("{id}/roles")]
    public async Task<ActionResult<IEnumerable<string>>> GrantRole([FromRoute] Guid id, [FromBody] AddUserToRolesCommand request)
    {
        request.Id = id;
        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id}/roles")]
    public async Task<ActionResult<IEnumerable<string>>> RevokeRole([FromRoute] Guid id, [FromBody] RemoveUserFromRolesCommand request)
    {
        request.Id = id;
        return Ok(await Mediator.Send(request));
    }
    #endregion

    [HttpGet("verify/phone/send")]
    public async Task<IActionResult> SendPhoneVerificationCode([FromQuery] ChangePhoneNumberCommand command)
    {

        return Ok(await Mediator.Send(command));
    }

    [HttpGet("verify/phone")]
    public async Task<IActionResult> VerifyPhone([FromQuery] ConfirmPhoneNumberChangeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("verify/email/exist")]
    public async Task<ActionResult<bool>> GetById([FromQuery] string email)
    {
        return Ok(await Mediator.Send(new EmailExistQuery() { Email = email }));
    }

    [HttpGet("verify/email/send")]
    public async Task<IActionResult> SendEmailVerificationToken([FromQuery] ChangeEmailCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("verify/email")]
    public async Task<IActionResult> VerifyEmail([FromQuery] ConfirmEmailChangeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}

[Route("api/[controller]")]
public class verifyController : ApiControllerBase
{
    [HttpGet("phone/send")]
    public async Task<IActionResult> SendPhoneVerificationCode([FromQuery] ChangePhoneNumberCommand command)
    {

        return Ok(await Mediator.Send(command));
    }

    [HttpGet("phone")]
    public async Task<IActionResult> VerifyPhone([FromQuery] ConfirmPhoneNumberChangeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("email/exist")]
    public async Task<ActionResult> GetById([FromQuery] string email)
    {
        return Ok(await Mediator.Send(new EmailExistQuery() { Email = email }));
    }

    [HttpGet("email/send")]
    public async Task<IActionResult> SendEmailVerificationToken([FromQuery] ChangeEmailCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("email")]
    public async Task<IActionResult> VerifyEmail([FromQuery] ConfirmEmailChangeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}