﻿using MRA.Jobs.Application.Contracts.Applicant.Commands;

namespace MRA.Jobs.Application.Features.Applicant.Command.CreateApplicant;

public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
{
    public CreateApplicantCommandValidator()
    {
        RuleFor(a => a.Avatar).NotEmpty();
        RuleFor(a => a.FirstName)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(a => a.LastName)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(a => a.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(a => a.Patronymic)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(a => a.BirthDay)
            .NotEmpty();
        RuleFor(a => a.PhoneNumber)
            .NotEmpty();
        
    }
}