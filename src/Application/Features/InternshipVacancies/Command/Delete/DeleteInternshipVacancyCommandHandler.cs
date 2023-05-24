﻿using MRA.Jobs.Application.Contracts.InternshipVacancies.Commands;

namespace MRA.Jobs.Application.Features.InternshipVacancies.Command.Delete;
public class DeleteInternshipVacancyCommandHandler : IRequestHandler<DeleteInternshipVacancyCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteInternshipVacancyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteInternshipVacancyCommand request, CancellationToken cancellationToken)
    {
        var internship = await _context.Internships.FindAsync(new object[] { request.Id }, cancellationToken);

        if (internship == null)
            throw new EntityNotFoundException(nameof(InternshipVacancy), request.Id);

        _context.Internships.Remove(internship);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
