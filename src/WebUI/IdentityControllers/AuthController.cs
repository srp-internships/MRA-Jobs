using MRA.Jobs.Infrastructure.Shared.Auth.Commands;
using MRA.Jobs.Infrastructure.Shared.Auth.Responses;

namespace MRA.Jobs.Web.IdentityControllers;

public class AuthController : AuthApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<JwtTokenResponse>> Login([FromBody] BasicAuthenticationCommand command, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [HttpGet("token/refresh")]
    public async Task<ActionResult<JwtTokenResponse>> RefreshToken([FromQuery] RefreshTokenCommand command, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [HttpGet("token/token")]
    public async Task<ActionResult<JwtTokenResponse>> RevokeRefreshToken([FromQuery] RevokeRefreshTokenCommand command, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
