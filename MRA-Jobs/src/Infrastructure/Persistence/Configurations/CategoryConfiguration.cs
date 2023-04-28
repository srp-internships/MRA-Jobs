using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRA_Jobs.Domain.Entities;

namespace MRA_Jobs.Infrastructure.Persistence.Configurations;
internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(s=>s.Name).HasMaxLength(300);
        builder.HasMany(s=>s.JobVacancies).WithOne(s=>s.Category);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.HasKey(s=>s.Id);
        builder.HasMany(s => s.EducationVacancies).WithOne(s => s.Category);
    }
}
