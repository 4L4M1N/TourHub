using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourHub.Models;
using TourHub.ViewModels;

namespace TourHub.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        private readonly ApplicationDbContext _dbContext;
        public TourController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new TourFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] //CSRF attack
        public ActionResult Create(TourFormViewModel tourFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                tourFormViewModel.Genres = _dbContext.Genres.ToList();
                return View("Create", tourFormViewModel);
            }
            var tour = new Tour
            {
                TravellerID = User.Identity.GetUserId(),
                DateTime = tourFormViewModel.GetDateTime(),
                GenreID = tourFormViewModel.Genre,
                Cost = tourFormViewModel.Cost,
                Place = tourFormViewModel.Place,
                TotalSeat = tourFormViewModel.TotalSeat
            };
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
    }
}