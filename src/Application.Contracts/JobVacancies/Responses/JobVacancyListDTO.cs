﻿using MRA.Jobs.Domain.Entities;
using MRA.Jobs.Domain.Enums;

namespace MRA.Jobs.Application.Contracts.JobVacancies.Responses;

public class JobVacancyListDTO
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime EndDate { get; set; }
    public WorkSchedule WorkSchedule { get; set; }
}

public class JobVacancyDetailsDTO
{
    public Guid Id { get; set; }
    public Guid? CategoryId { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime EndDate { get; set; }
    public WorkSchedule WorkSchedule { get; set; }
    public int RequiredYearOfExperience { get; set; }

    public DateTime CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public Guid? LastModifiedBy { get; set; }
}

