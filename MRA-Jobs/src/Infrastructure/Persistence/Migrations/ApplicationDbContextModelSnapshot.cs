﻿// <auto-generated />
using System;
using MRA_Jobs.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MRA_Jobs.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MRA_Jobs.Domain.Entities.Vacancy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Vacancy", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vacancy");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MRA_Jobs.Domain.Entities.EducationVacancy", b =>
                {
                    b.HasBaseType("MRA_Jobs.Domain.Entities.Vacancy");

                    b.Property<DateTime>("ClassEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ClassStartDate")
                        .HasColumnType("datetime2");

                    b.ToTable("Vacancy", (string)null);

                    b.HasDiscriminator().HasValue("EducationVacancy");

                    b.HasData(
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "tersd",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDescription = "sad",
                            Title = "Training class",
                            ClassEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClassStartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MRA_Jobs.Domain.Entities.JobVacancy", b =>
                {
                    b.HasBaseType("MRA_Jobs.Domain.Entities.Vacancy");

                    b.Property<int>("RequeredYearOfExperience")
                        .HasColumnType("int");

                    b.ToTable("Vacancy", (string)null);

                    b.HasDiscriminator().HasValue("JobVacancy");

                    b.HasData(
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "tersd",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDescription = "sad",
                            Title = "Senior C# backend developer",
                            RequeredYearOfExperience = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}