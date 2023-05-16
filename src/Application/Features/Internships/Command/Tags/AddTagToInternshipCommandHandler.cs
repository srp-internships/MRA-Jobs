﻿using MRA.Jobs.Application.Contracts.Internships.Commands;
using MRA.Jobs.Domain.Enums;

namespace MRA.Jobs.Application.Features.Internships.Command.Tags;
public class AddTagToInternshipCommandHandler : IRequestHandler<AddTagToInternshipCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _currentUserService;

    public AddTagToInternshipCommandHandler(IApplicationDbContext context, IDateTime dateTime, ICurrentUserService currentUserService)
    {
        _context = context;
        _dateTime = dateTime;
        _currentUserService = currentUserService;
    }
    public async Task<bool> Handle(AddTagToInternshipCommand request, CancellationToken cancellationToken)
    {
        var internship = await _context.Internships.FindAsync(new object[] { request.InternshipId }, cancellationToken);
        var tag = await _context.Tags.FindAsync(new object[] { request.TagId }, cancellationToken);

        var vacancyTag = new VacancyTag
        {
            VacancyId = internship?.Id ?? throw new NotFoundException(nameof(JobVacancy), request.InternshipId),
            TagId = tag?.Id ?? throw new NotFoundException(nameof(Tag), request.TagId)
        };

        var timelineEvent = new VacancyTimelineEvent
        {
            VacancyId = internship.Id,
            EventType = TimelineEventType.Created,
            Time = _dateTime.Now,
            Note = $"Added '{tag.Name}' tag",
            CreateBy = _currentUserService.UserId
        };

        await _context.VacancyTimelineEvents.AddAsync(timelineEvent, cancellationToken);

        await _context.VacancyTags.AddAsync(vacancyTag, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}