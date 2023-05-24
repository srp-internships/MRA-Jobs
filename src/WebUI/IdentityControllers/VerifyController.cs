using MRA.Jobs.Infrastructure.Shared.Auth.Queries;
using MRA.Jobs.Infrastructure.Shared.Users.Commands.Verifications;
using MRA.Jobs.Infrastructure.Shared.Users.Queries;

namespace MRA.Jobs.Web.IdentityControllers;

public class VerifyController : AuthApiControllerBase
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