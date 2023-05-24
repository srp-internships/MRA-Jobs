using Microsoft.AspNetCore.Identity;
using MRA.Jobs.Infrastructure.Shared.Me.Commands;

namespace MRA.Jobs.Infrastructure.Identity.Features.User.Commands;

public class ChangePasswordCommandHandler : IRequestHandler<ChangeMyPasswordCommand, Unit>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICurrentUserService _currentUserService;

    public ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService)
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
    }

    public async Task<Unit> Handle(ChangeMyPasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetId() ?? Guid.Empty;
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            throw new EntityNotFoundException(nameof(ApplicationUser), userId);

        var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        if (!result.Succeeded)
            throw new ValidationException(string.Join('\n', result.Errors.Select(r => r.Description)));

        return Unit.Value;
    }
}
