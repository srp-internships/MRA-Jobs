﻿using MRA.Jobs.Application.Common.Converter;
using Newtonsoft.Json;

using MRA.Jobs.Domain.Enums;

namespace MRA.Jobs.Application.Contracts.JobVacancies.Responses;

public class JobVacancyListDTO
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    [JsonConverter(typeof(DateTimeToUnixConverter))]
    public DateTime PublishDate { get; set; }
    [JsonConverter(typeof(DateTimeToUnixConverter))]
    public DateTime EndDate { get; set; }
    public WorkSchedule WorkSchedule { get; set; }
}