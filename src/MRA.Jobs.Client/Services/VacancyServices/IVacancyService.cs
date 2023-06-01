﻿using MRA.Jobs.Application.Contracts.JobVacancies.Commands;
using MRA.Jobs.Application.Contracts.VacancyCategories.Commands;
using MRA.Jobs.Application.Contracts.VacancyCategories.Responses;

namespace MRA.Jobs.Client.Services.VacancyServices;

public interface IVacancyService
{
    string guidId { get; set; }
    List<CategoryResponse> Category { get; set; }
    CreateJobVacancyCommand creatingNewJob { get; set; }
    CreateVacancyCategoryCommand creatingEntity { get; set; }
    Task<List<CategoryResponse>> GetAllCategory();
    Task OnSaveCreateClick();
}