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

    }
}