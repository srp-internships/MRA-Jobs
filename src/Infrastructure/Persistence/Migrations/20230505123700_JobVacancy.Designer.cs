﻿/*
// <auto-generated />
using System;
using MRA.Jobs.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MRA.Jobs.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230505123700_JobVacancy")]
    partial class JobVacancy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Application", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ApplicantAbout")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("ApplicantCvPath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("ApplicantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.Property<string>("TestResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VacancyId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("VacancyId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.TimelineEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TimelineEvent", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("TimelineEvent");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBrith")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.UserTag", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("UserTags");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Vacancy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
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

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.VacancyCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.VacancyTag", b =>
                {
                    b.Property<long>("VacancyId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("VacancyId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("VacancyTags");
                });

            modelBuilder.Entity("MRA.Jobs.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.ApplicationTimelineEvent", b =>
                {
                    b.HasBaseType("MRA.Jobs.Domain.Entities.TimelineEvent");

                    b.Property<long>("ApplicationId")
                        .HasColumnType("bigint");

                    b.HasIndex("ApplicationId");

                    b.HasDiscriminator().HasValue("ApplicationTimelineEvent");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.UserTimelineEvent", b =>
                {
                    b.HasBaseType("MRA.Jobs.Domain.Entities.TimelineEvent");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("UserTimelineEvent");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.VacancyTimelineEvent", b =>
                {
                    b.HasBaseType("MRA.Jobs.Domain.Entities.TimelineEvent");

                    b.Property<long>("VacancyId")
                        .HasColumnType("bigint");

                    b.HasIndex("VacancyId");

                    b.HasDiscriminator().HasValue("VacancyTimelineEvent");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Applicant", b =>
                {
                    b.HasBaseType("MRA.Jobs.Domain.Entities.User");

                    b.Property<string>("SocialMediaHandles")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("User", (string)null);

                    b.HasDiscriminator().HasValue("Applicant");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.EducationVacancy", b =>
                {
                    b.HasBaseType("MRA.Jobs.Domain.Entities.Vacancy");

                    b.Property<DateTime>("ClassEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ClassStartDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("CategoryId");

                    b.ToTable("Vacancy", (string)null);

                    b.HasDiscriminator().HasValue("EducationVacancy");

                    b.HasData(
                        new
                        {
                            Id = 5L,
                            CategoryId = 0L,
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

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.JobVacancy", b =>
                {
                    b.HasBaseType("MRA.Jobs.Domain.Entities.Vacancy");

                    b.Property<int>("RequiredYearOfExperience")
                        .HasColumnType("int");

                    b.Property<int>("WorkSchedule")
                        .HasColumnType("int");

                    b.HasIndex("CategoryId");

                    b.ToTable("Vacancy", (string)null);

                    b.HasDiscriminator().HasValue("JobVacancy");

                    b.HasData(
                        new
                        {
                            Id = 3L,
                            CategoryId = 0L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "tersd",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDescription = "sad",
                            Title = "Senior C# backend developer",
                            RequiredYearOfExperience = 0,
                            WorkSchedule = 0
                        });
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Application", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRA.Jobs.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany("Applications")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.UserTag", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.Tag", "Tag")
                        .WithMany("UserTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRA.Jobs.Domain.Entities.User", "User")
                        .WithMany("UserTags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.VacancyTag", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.Tag", "Tag")
                        .WithMany("VacancyTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRA.Jobs.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany("Tags")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MRA.Jobs.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MRA.Jobs.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRA.Jobs.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MRA.Jobs.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.ApplicationTimelineEvent", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.Application", "Application")
                        .WithMany("TimelineEvents")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.UserTimelineEvent", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.User", "User")
                        .WithMany("userTimelineEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.VacancyTimelineEvent", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany("VacancyTimelineEvents")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.EducationVacancy", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.VacancyCategory", "Category")
                        .WithMany("EducationVacancies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.JobVacancy", b =>
                {
                    b.HasOne("MRA.Jobs.Domain.Entities.VacancyCategory", "Category")
                        .WithMany("JobVacancies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Application", b =>
                {
                    b.Navigation("TimelineEvents");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Tag", b =>
                {
                    b.Navigation("UserTags");

                    b.Navigation("VacancyTags");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.User", b =>
                {
                    b.Navigation("UserTags");

                    b.Navigation("userTimelineEvents");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.Vacancy", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Tags");

                    b.Navigation("VacancyTimelineEvents");
                });

            modelBuilder.Entity("MRA.Jobs.Domain.Entities.VacancyCategory", b =>
                {
                    b.Navigation("EducationVacancies");

                    b.Navigation("JobVacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
*/
