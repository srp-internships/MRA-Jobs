﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MRA_Jobs.Infrastructure.Persistence.Configurations;
public class ApplicationConfiguration : IEntityTypeConfiguration<Domain.Entities.Application>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.ApplicantCvPath)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.ApplicantAbout)
            .HasMaxLength(3000)
            .IsRequired();

        builder.HasOne(a => a.Applicant)
            .WithMany(at => at.Applications)
            .HasForeignKey(a => a.ApplicantId);

        builder.HasOne(a => a.Status)
            .WithMany(s => s.Applications)
            .HasForeignKey(a => a.StatusId);
    }
}