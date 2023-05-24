using MediatR;

namespace MRA.Jobs.Infrastructure.Shared.Users.Queries;

public class EmailExistQuery : IRequest
{
    public string Email { get; set; }
}
