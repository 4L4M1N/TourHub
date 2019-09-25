using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TourHub.Controllers.Api;
using TourHub.Core;
using TourHub.Core.Repositories;
using TourHub.Tests.Extentions;

using  System.Xml.Linq;

namespace TourHub.Tests.Controllers.Api
{
    [TestClass]
    public class TourControllerTests
    {
        private TourController _controller;

        public TourControllerTests()
        {
            //MoQ  unit of work
            var mockRepository = new Mock<ITourRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Tours).Returns(mockRepository.Object);
            _controller = new TourController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user@domain.com");

        }
        [TestMethod]
        public void Cancel_NoTourWithGivenIdExists_ShouldReturnNotfound()
        {
            var result = _controller.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();

        }
    }
}
