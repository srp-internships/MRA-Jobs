using MediatR;

namespace MRA.Jobs.Infrastructure.Shared.Auth.Queries;

public class EmailExistQuery : IRequest
{
    public string Email { get; set; }
}
