﻿using MRA.Jobs.Application.Contracts.Applicant.Queries;
using MRA.Jobs.Application.Contracts.Applicant.Responses;

namespace MRA.Jobs.Application.Features.Applicants.Query.GetApplicantById;

using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class GetApplicantByIdQueryHandler : IRequestHandler<GetApplicantByIdQuery, ApplicantDetailsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetApplicantByIdQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApplicantDetailsDto> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
    {
        var applicant = await _context.Applicants.FindAsync(new object[] { request.Id }, cancellationToken: cancellationToken);
        _ = applicant ?? throw new EntityNotFoundException(nameof(Applicant), request.Id);    
        return _mapper.Map<ApplicantDetailsDto>(applicant);
    }
}