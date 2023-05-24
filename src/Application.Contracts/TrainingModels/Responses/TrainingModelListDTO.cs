﻿using MRA.Jobs.Application.Common.Converter;
using Newtonsoft.Json;

namespace MRA.Jobs.Application.Contracts.TrainingModels.Responses;
public class TrainingModelListDTO
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(DateTimeToUnixConverter))]
    public DateTime PublishDate { get; set; }
    [JsonConverter(typeof(DateTimeToUnixConverter))]
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
    public int Fees { get; set; }
}
