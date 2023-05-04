﻿namespace MRA.Jobs.Domain.Entities;

public class Applicant : User
{
    public string SocialMediaHandles { get; set; }
    public ICollection<SocialMedia> SocialMedia { get; set;}
}
