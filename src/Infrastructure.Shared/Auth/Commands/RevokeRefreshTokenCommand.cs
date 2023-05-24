using MediatR;

namespace MRA.Jobs.Infrastructure.Shared.Auth.Commands;

public class RevokeRefreshTokenCommand : IRequest<Unit>
{
    public string RefreshToken { get; set; }
}
