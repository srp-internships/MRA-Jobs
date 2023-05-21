﻿using MRA.Jobs.Application.Contracts.JobVacancies.Commands;

namespace MRA.Jobs.Application.Features.Applicant.Command.Tags;

public class RemoveTagFromApplicantCommandValidator : AbstractValidator<RemoveTagFromJobVacancyCommand>
{
    public RemoveTagFromApplicantCommandValidator()
    {
        RuleFor(x => x.JobVacancyId).NotEmpty();
        RuleFor(x => x.TagId).NotEmpty();
    }
}