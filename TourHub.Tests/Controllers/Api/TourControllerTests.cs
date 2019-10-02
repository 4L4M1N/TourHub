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
using TourHub.Core.Models;

namespace TourHub.Tests.Controllers.Api
{
    [TestClass]
    public class TourControllerTests
    {
        private TourController _controller;
        private Mock<ITourRepository> _mockRepository;
        private string _userId;

        public TourControllerTests()
        {
            //MoQ  unit of work
            _mockRepository = new Mock<ITourRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Tours).Returns(_mockRepository.Object);
            _controller = new TourController(mockUoW.Object);
            _userId = "1";
            _controller.MockCurrentUser(_userId, "user@domain.com");

        }
        [TestMethod]
        public void Cancel_NoTourWithGivenIdExists_ShouldReturnNotfound()
        {
            var result = _controller.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();

        }

        [TestMethod]
        public void Cancel_TourIsCancelled_ShouldReturnNotFound()
        {
            var tour = new Tour();
            tour.cancel();
            _mockRepository.Setup(r => r.GetTourWithAttendees(1)).Returns(tour);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_UserCancelAnotherUserTour_ShouldReturnUnauthorized()
        {
            var tour = new Tour{TravellerID = _userId + "-"};
            _mockRepository.Setup(r => r.GetTourWithAttendees(1)).Returns(tour);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<UnauthorizedResult>();
        }

        [TestMethod]
        public void Cancel_ValidRequest_ShouldReturnOK()
        {
            var tour = new Tour { TravellerID = _userId};
            _mockRepository.Setup(r => r.GetTourWithAttendees(1)).Returns(tour);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<OkResult>();
        }
    }
}
