﻿using MRA.Jobs.Application.Contracts.InternshipVacancies.Commands;
using MRA.Jobs.Application.Contracts.InternshipVacancies.Responses;

namespace MRA.Jobs.Client.Services.InternshipsServices;

public class InternshipService : IInternshipService
{
    private readonly HttpClient _http;

    public InternshipService(HttpClient http)
    {
        _http = http;
    }

    public CreateInternshipVacancyCommand createCommand { get; set; }
    public UpdateInternshipVacancyCommand UpdateCommand { get; set; }
    public DeleteInternshipVacancyCommand DeleteCommand { get; set; }

    public async Task<HttpResponseMessage> Create(CreateInternshipVacancyCommand createCommand)
    {
        return await _http.PostAsJsonAsync("internships", createCommand);
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<InternshipVacancyListResponce>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<InternshipVacancyResponce> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateInternshipVacancyCommand updateCommand)
    {
        throw new NotImplementedException();
    }
}
