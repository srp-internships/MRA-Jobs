using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using MRA.Jobs.Application.Common.Interfaces;
using MRA.Jobs.Application.Contracts.SocialMedias.Commands;
using MRA.Jobs.Domain.Entities;

namespace MRA.Jobs.Application.Features.SocialMedias.Commands;
public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, long>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateSocialMediaCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<long> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = await _context.SocialMedias
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NullReferenceException(
                $"{nameof(SocialMedia)} {nameof(request.Id)}");

        _context.SocialMedias.Attach(
            _mapper.Map<SocialMedia>(request))
            .State =Microsoft.EntityFrameworkCore.EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);
        return request.Id;
    }
}
public class UpdateSocialMediaCommandValidator : AbstractValidator<UpdateSocialMediaCommand>
{
    public UpdateSocialMediaCommandValidator()
    {

    }
}
