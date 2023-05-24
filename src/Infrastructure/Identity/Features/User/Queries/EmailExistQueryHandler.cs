using Microsoft.AspNetCore.Identity;
using MRA.Jobs.Application.Common.Exceptions;
using MRA.Jobs.Infrastructure.Identity.Entities;
using MRA.Jobs.Infrastructure.Shared.Auth.Queries;

namespace MRA.Jobs.Infrastructure.Identity.Features.User.Queries;

public class EmailExistQueryHandler : IRequestHandler<EmailExistQuery, Unit>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public EmailExistQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(EmailExistQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new EntityNotFoundException("", request.Email);
        }
        return await Unit.Task;
    }
}
