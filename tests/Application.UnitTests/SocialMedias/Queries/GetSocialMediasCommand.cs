using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Moq;
using MRA.Jobs.Application.Common.Interfaces;
using MRA.Jobs.Application.Contracts.SocialMedias.Commands;
using MRA.Jobs.Application.Contracts.SocialMedias.Queries;
using MRA.Jobs.Application.Contracts.SocialMedias.Responses;
using MRA.Jobs.Application.Contracts.VacancyCategories.Commands;
using MRA.Jobs.Application.Features.SocialMedias.Commands;
using MRA.Jobs.Application.Features.SocialMedias.Queries;
using MRA.Jobs.Domain.Entities;
using MRA.Jobs.Infrastructure.Persistence;
using NUnit.Framework;

namespace MRA.Jobs.Application.UnitTests.SocialMedias.Queries
{
    [TestFixture]
    public class GetSocialMediasCommand
    {
        private readonly IMapper _mapper;

        [Test]
        public void GetSocialMediasQuery_Returns_ListOfSocialMedias()
        {
            var mockContext = new Mock<IApplicationDbContext>();
            var mockMapper = new Mock<IMapper>();
            var queryHandler = new GetSocialMediasQueryHandler(mockContext.Object, mockMapper.Object);
            var query = new GetSocialMediasQuery { ApplicantId = 1 };
            var result = queryHandler.Handle(query, CancellationToken.None);
            result.Should().NotBeNull();
        }


    }
}
