using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MRA.Jobs.Application.Common.Exceptions;
using MRA.Jobs.Application.Common.Interfaces;
using MRA.Jobs.Application.Contracts.VacancyCategories.Commands;

namespace MRA.Jobs.Application.Features.VacancyCategories.Command;
public class DeleteVacancyCategoryCommandHandler : IRequestHandler<DeleteVacancyCategoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteVacancyCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    async Task<bool> IRequestHandler<DeleteVacancyCategoryCommand, bool>.Handle(DeleteVacancyCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _context.Categories.FindAsync(request.Id, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
