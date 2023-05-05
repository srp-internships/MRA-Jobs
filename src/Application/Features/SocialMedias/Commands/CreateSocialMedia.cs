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
public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, long>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateSocialMediaCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<long> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = _mapper.Map<SocialMedia>(request);
        var result = await _context.SocialMedias.AddAsync(socialMedia);
        await _context.SaveChangesAsync(cancellationToken);
        return result.Entity.Id;
    }
}
public class CreateSocialMediaCommandValidator : AbstractValidator<CreateSocialMediaCommand>
{
    public CreateSocialMediaCommandValidator()
    {

    }
}
