﻿using MRA.Jobs.Application.Contracts.Reviewer.Commands;

namespace MRA.Jobs.Application.Features.Reviewer.Command.Tags;

public class AddTagToReviewerCommandValidator : AbstractValidator<AddTagToReviewerCommand>
{
    public AddTagToReviewerCommandValidator()
    {
        RuleFor(x => x.ReviewerId).NotEmpty();
        RuleFor(x => x.TagId).NotEmpty();
    }
}
