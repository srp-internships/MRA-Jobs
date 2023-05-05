using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using MRA.Jobs.Application.Common.Interfaces;
using MRA.Jobs.Application.Contracts.SocialMedias.Commands;
using MRA.Jobs.Application.Features.SocialMedias.Commands;
using MRA.Jobs.Domain.Entities;
using MRA.Jobs.Infrastructure.Persistence;
using NUnit.Framework;

namespace MRA.Jobs.Application.IntegrationTests.SocialMedias.Commands
{
    [TestFixture]
    public class UnitTestDeleteSocialMediaCommand
    {
        [Test]
        public async Task Handle_DeleteSocialMediaCommand_ShouldReturnTrue()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var mockSocialMedia = new Mock<SocialMedia>();
            var mockSet = new Mock<DbSet<SocialMedia>>();
            mockSet.Setup(m => m.FindAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(mockSocialMedia.Object);
            mockContext.Setup(m => m.SocialMedias).Returns(mockSet.Object);
            var handler = new DeleteSocialMediaCommandHander(mockContext.Object);
            var command = new DeleteSocialMediaCommand { Id = 1 };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsTrue(result);
            mockSet.Verify(m => m.FindAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
            mockSet.Verify(m => m.Remove(It.IsAny<SocialMedia>()), Times.Once);
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
