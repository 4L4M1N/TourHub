using System;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TourHub.Controllers.Api;
using TourHub.Core;

namespace TourHub.Tests.Controllers.Api
{
    [TestClass]
    public class TourControllerTests
    {
        private TourController _controller;

        public TourControllerTests()
        {
            var identity = new GenericIdentity("user@domain.com");
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "user@domain.com"));
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));

            var principal = new GenericPrincipal(identity, null);

            //MoQ  unit of work
            var mockUoW = new Mock<IUnitOfWork>(); 

            _controller = new TourController(mockUoW.Object);
            _controller.User = principal;

        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
