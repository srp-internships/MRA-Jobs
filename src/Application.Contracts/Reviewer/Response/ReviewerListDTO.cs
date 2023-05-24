﻿namespace MRA.Jobs.Application.Contracts.Reviewer.Response;

public class ReviewerListDto
{
    public Guid Id { get; set; }
    public string Avatar { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string JobTitle { get; set; }
}

public class ReviewerDetailsDto 
{
    public Guid Id { get; set; }
    public string Avatar { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string JobTitle { get; set; }
}