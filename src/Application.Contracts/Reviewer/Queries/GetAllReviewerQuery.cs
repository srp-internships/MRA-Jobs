﻿using MediatR;
using MRA.Jobs.Application.Contracts.Reviewer.Response;

namespace MRA.Jobs.Application.Contracts.Reviewer.Queries;

public class GetAllReviewerQuery : IRequest<ReviewerListDTO>
{
    public Guid Id { get; set; }
}