using MRA.Jobs.Application.Contracts.Reviewer.Command;
using MRA.Jobs.Application.Contracts.Reviewer.Response;

namespace MRA.Jobs.Application.Features.Reviewer;
using Domain.Entities;

public class ReviewerProfile : Profile
{
    public ReviewerProfile()
    {
        CreateMap<Reviewer, ReviewerListItemResponce>();
        CreateMap<Reviewer, ReviewerDetailsDto>();
        CreateMap<CreateReviewerCommand, Reviewer>();
        CreateMap<UpdateReviewerCommand, Reviewer>();
    }
}