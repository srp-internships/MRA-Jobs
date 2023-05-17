﻿using MRA.Jobs.Application.Contracts.Applicant.Commands;
using MRA.Jobs.Application.Contracts.Applicant.Responses;

namespace MRA.Jobs.Application.Features.Applicant;
using Domain.Entities;
public class ApplicantProfile : Profile
{
    public ApplicantProfile()
    {
        CreateMap<CreateApplicantCommand, Applicant>();
        CreateMap<UpdateApplicantCommand, Applicant>();
        CreateMap<Applicant, ApplicantListDto>();
        CreateMap<Applicant, ApplicantDetailsDto>();
    }
}