﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRA.Jobs.Domain.Entities;

namespace MRA.Jobs.Infrastructure.Persistence.Configurations;
public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();
        builder.HasMany(s => s.SocialMedia)
            .WithOne(s=>s.Applicant)
            .HasForeignKey(s=>s.UserId);
    }
}
