using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MRA.Jobs.Application.Common.Interfaces;
using MRA.Jobs.Application.Contracts.SocialMedias.Queries;
using MRA.Jobs.Application.Contracts.SocialMedias.Responses;

namespace MRA.Jobs.Application.Features.SocialMedias.Queries;
public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, GetSocialMediasResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdSocialMediaQueryHandler(IApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetSocialMediasResponse> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var socialMedia = await _context.SocialMedias
            .FirstOrDefaultAsync(s=>s.Id.Equals(request.Id))
            ?? throw new NullReferenceException();

        return _mapper.Map<GetSocialMediasResponse>(socialMedia);
    }
}
