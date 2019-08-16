using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourHub.Models;
using TourHub.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace TourHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        public HomeController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult Feed()
        {

            var feed = _applicationDbContext.Tours
                .Include(t => t.Traveller)
                .Include(t=> t.Genre)
                .Where(g => g.DateTime > DateTime.Now);
            var viewmodel = new FeedViewModel
            {
                UpcommingTours = feed,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcomming Tours"
            };
            return View("Feed",viewmodel);
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var tourToAttend = _applicationDbContext.Attendences
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Tour)
                .Include(t => t.Traveller)
                .Include(g =>g.Genre)
                .ToList();
            var attend = new FeedViewModel
            {
                UpcommingTours = tourToAttend,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Tour I am going"
            };
            return View("Feed",attend);
        }
    }
}