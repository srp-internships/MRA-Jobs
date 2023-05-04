﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRA.Jobs.Domain.Entities;

namespace MRA.Jobs.Infrastructure.Persistence.Configurations;
public class InternshipConfiguration : IEntityTypeConfiguration<Internship>
{
    public void Configure(EntityTypeBuilder<Internship> builder)
    {
        builder.ToTable(nameof(Vacancy));

        builder.HasOne(i => i.Category)
            .WithMany(c => c.Internships)
            .HasForeignKey(i => i.CategoryId);
    }
}