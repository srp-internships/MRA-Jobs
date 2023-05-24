using MRA.Jobs.Application.Contracts.MyProfile.Commands;
using MRA.Jobs.Application.Contracts.MyProfile.Queries;
using MRA.Jobs.Application.Contracts.MyProfile.Responses;
using MRA.Jobs.Infrastructure.Shared.Me.Commands;
using MRA.Jobs.Infrastructure.Shared.Users.Commands.Verifications;

namespace MRA.Jobs.Web.IdentityControllers;


public class MeController : AuthApiControllerBase
{
    private readonly ICurrentUserService _currentUserService;

    public MeController(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    [HttpGet]
    public async Task<ActionResult<MyProfileResponse>> MyProfile()
    {
        return Ok(await Mediator.Send(new GetMyProfileQuery()));
    }

    [HttpPut]
    public async Task<ActionResult<MyProfileResponse>> UpdateMyProfile(UpdateMyProfileCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("identity/change-password")]
    public async Task<IActionResult> ChangeMyPassword(ChangeMyPasswordCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("identity/verify/phone/send")]
    public async Task<IActionResult> SendVerificationCodeForMyPhone([FromQuery] string phone)
    {
        return Ok(await Mediator.Send(new ChangePhoneNumberCommand()
        {
            NewPhoneNumber = phone,
            UserId = _currentUserService.GetId() ?? Guid.Empty
        }));
    }

    [HttpGet("identity/verify/phone")]
    public async Task<IActionResult> VerifyMyPhone([FromQuery] string phone, [FromQuery] string code)
    {
        return Ok(await Mediator.Send(new ConfirmPhoneNumberChangeCommand()
        {
            NewPhoneNumber = phone,
            Code = code,
            UserId = _currentUserService.GetId() ?? Guid.Empty
        }));
    }

    [HttpGet("identity/verify/email/send")]
    public async Task<IActionResult> SendVerificationTokenForMyEmail([FromQuery] string newEmail)
    {
        return Ok(await Mediator.Send(new ChangeEmailCommand()
        {
            UserId = _currentUserService.GetId() ?? Guid.Empty,
            NewEmail = newEmail,
        }));
    }

    [HttpGet("identity/verify/email")]
    public async Task<IActionResult> VerifyMyEmail([FromQuery] string token, [FromQuery] string newEmail)
    {
        return Ok(await Mediator.Send(new ConfirmEmailChangeCommand()
        {
            UserId = _currentUserService.GetId() ?? Guid.Empty,
            NewEmail = newEmail,
            Token = token
        }));
    }
}