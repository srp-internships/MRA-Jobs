using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRA.Jobs.Domain.Entities;

namespace MRA.Jobs.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.Id).ValueGeneratedOnAdd();
        builder.Property(x=>x.FirstName).HasMaxLength(256);
        builder.Property(x=>x.LastName).HasMaxLength(256);
        builder.Property(x=>x.Email).HasMaxLength(256);

    }
}
