﻿namespace MRA.Jobs.Application.Contracts.JobVacancies.Responses;

using MRA.Jobs.Domain.Enums;

public class JobVacancyFullResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime EndDate { get; set; }
    public long? CategoryId { get; set; }
    public DateTime ApplicationDeadline { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public JobType JobType { get; set; }
    public int SalaryRange { get; set; }
}