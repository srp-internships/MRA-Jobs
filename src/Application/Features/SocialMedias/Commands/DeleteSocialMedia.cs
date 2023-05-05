using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MRA.Jobs.Application.Common.Interfaces;
using MRA.Jobs.Application.Contracts.SocialMedias.Commands;

namespace MRA.Jobs.Application.Features.SocialMedias.Commands;
public class DeleteSocialMediaCommandHander : IRequestHandler<DeleteSocialMediaCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteSocialMediaCommandHander(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = await _context.SocialMedias
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NullReferenceException();
        _context.SocialMedias.Remove(socialMedia);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

}
