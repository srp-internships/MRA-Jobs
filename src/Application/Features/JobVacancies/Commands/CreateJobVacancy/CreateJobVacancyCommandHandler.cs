﻿using MRA.Jobs.Application.Common.Security;
using MRA.Jobs.Application.Contracts.JobVacancies.Commands;

namespace MRA.Jobs.Application.Features.JobVacancies.Commands.CreateJobVacancy;

public class CreateJobVacancyCommandHandler : IRequestHandler<CreateJobVacancyCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _currentUserService;

    public CreateJobVacancyCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IDateTime dateTime, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _dateTime = dateTime;
        _currentUserService = currentUserService;
    }
        
    public async Task<Guid> Handle(CreateJobVacancyCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FindAsync(request.CategoryId);
        _ = category ?? throw new EntityNotFoundException(nameof(VacancyCategory), request.CategoryId);

        var jobVacancy = _mapper.Map<JobVacancy>(request);
        jobVacancy.Category = category;
        await _dbContext.JobVacancies.AddAsync(jobVacancy, cancellationToken);

        var timelineEvent = new VacancyTimelineEvent
        {
            VacancyId = jobVacancy.Id,
            EventType = TimelineEventType.Created,
            Time = _dateTime.Now,
            Note = "Job vacancy created",
            CreateBy = _currentUserService.GetId().Value
        };
        await _dbContext.VacancyTimelineEvents.AddAsync(timelineEvent, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return jobVacancy.Id;
    }
}
