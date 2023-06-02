﻿using MRA.Jobs.Application.Contracts.Common;
using MRA.Jobs.Application.Contracts.Tests.Commands;

namespace MRA.Jobs.Application.Features.Tests.Commands.CreateTestResult;
public class CreateTestResultCommandHandler : IRequestHandler<CreateTestResultCommand, TestResultDTO>
{
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _currentUserService;
    private readonly ITestHttpClientService _httpClient;
    private readonly IApplicationDbContext _context;

    public CreateTestResultCommandHandler(IDateTime dateTime, ICurrentUserService currentUserService, ITestHttpClientService httpClient, IApplicationDbContext context)
    {
        _dateTime = dateTime;
        _currentUserService = currentUserService;
        _httpClient = httpClient;
        _context = context;
    }
    public Task<TestResultDTO> Handle(CreateTestResultCommand request, CancellationToken cancellationToken)
    {

    }
}
