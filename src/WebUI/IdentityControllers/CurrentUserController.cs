using Microsoft.AspNetCore.Mvc;
using MRA.Jobs.Application.Common.Security;
using MRA.Jobs.Application.Contracts.MyProfile.Queries;
using MRA.Jobs.Infrastructure.Shared.Users.Commands;
using MRA.Jobs.Infrastructure.Shared.Users.Commands.Verifications;
using MRA.Jobs.Web.Controllers;

namespace MRA.Jobs.Web.IdentityControllers;

using Microsoft.AspNetCore.Authorization
    ;
using MRA.Jobs.Application.Contracts.MyProfile.Commands;
using MRA.Jobs.Application.Contracts.MyProfile.Responses;

[Authorize]
[Route("api/me")]
public class CurrentUserController : ApiControllerBase
{
    private readonly ICurrentUserService _currentUserService;

    public CurrentUserController(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    [HttpGet("me")]
    public async Task<ActionResult<MyProfileResponse>> MyProfile()
    {
        return Ok(await Mediator.Send(new GetMyProfileQuery()));
    }

    [HttpPut("me")]
    public async Task<ActionResult<MyProfileResponse>> UpdateMyProfile(UpdateMyProfileCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("me/change-password")]
    public async Task<IActionResult> ChangeMyPassword(ChangePasswordCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("me/verify/phone/send")]
    public async Task<IActionResult> SendVerificationCodeForMyPhone([FromQuery] string phone)
    {
        return Ok(await Mediator.Send(new ChangePhoneNumberCommand()
        {
            NewPhoneNumber = phone,
            UserId = _currentUserService.GetId() ?? Guid.Empty
        }));
    }

    [HttpGet("me/verify/phone")]
    public async Task<IActionResult> VerifyMyPhone([FromQuery] string phone, [FromQuery] string code)
    {
        return Ok(await Mediator.Send(new ConfirmPhoneNumberChangeCommand()
        {
            NewPhoneNumber = phone,
            Code = code,
            UserId = _currentUserService.GetId() ?? Guid.Empty
        }));
    }

    [HttpGet("me/verify/email/send")]
    public async Task<IActionResult> SendVerificationTokenForMyEmail([FromQuery] string newEmail)
    {
        return Ok(await Mediator.Send(new ChangeEmailCommand()
        {
            UserId = _currentUserService.GetId() ?? Guid.Empty,
            NewEmail = newEmail,
        }));
    }

    [HttpGet("me/verify/email")]
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