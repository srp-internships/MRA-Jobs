﻿using MRA.Jobs.Application.Contracts.Applications.Queries;

namespace MRA.Jobs.Application.Features.Applications.Query.GetApplicationById;
public class GetApplicationByIdQueryValidator : AbstractValidator<GetByIdApplicationQuery>
{
    public GetApplicationByIdQueryValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}
