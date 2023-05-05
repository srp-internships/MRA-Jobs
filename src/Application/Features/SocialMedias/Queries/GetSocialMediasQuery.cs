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
public class GetSocialMediasQueryHandler : IRequestHandler<GetSocialMediasQuery, List<GetSocialMediasResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSocialMediasQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetSocialMediasResponse>> Handle(GetSocialMediasQuery request, CancellationToken cancellationToken)
    {
        var socialMedias = await _context.SocialMedias
            .Where(s => s.ApplicantId == request.ApplicantId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        var response = _mapper.Map<List<GetSocialMediasResponse>>(socialMedias);
        return response;
    }
}
