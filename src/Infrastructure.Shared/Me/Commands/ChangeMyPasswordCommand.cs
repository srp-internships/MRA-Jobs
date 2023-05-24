using MediatR;

namespace MRA.Jobs.Infrastructure.Shared.Me.Commands;

public class ChangeMyPasswordCommand : IRequest<Unit>
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
