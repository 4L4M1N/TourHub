using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Heading = "Create a Tour Event",
                Genres = _dbContext.Genres.ToList()
            };

            return View("TourForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var tour = _dbContext.Tours.Single(t => t.Id == id && t.TravellerID == userId);
            var viewModel = new TourFormViewModel
            {
                Genres = _dbContext.Genres.ToList(),
                Id = id,
                Date = tour.DateTime.ToString("d MMM yyyy"),
                Time = tour.DateTime.ToString("HH:mm"),
                Genre = tour.GenreID,
                Place = tour.Place,
                Cost = tour.Cost,
                TotalSeat = tour.TotalSeat,
                Heading = "Edit your Tour Event"
            };
            return View("TourForm", viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] //CSRF attack
        public ActionResult Create(TourFormViewModel tourFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                tourFormViewModel.Genres = _dbContext.Genres.ToList();
                return View("TourForm", tourFormViewModel);
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
            return RedirectToAction("Mine", "Tour");
        }
        //Update 
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] //CSRF attack
        public ActionResult Update(TourFormViewModel tourFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                tourFormViewModel.Genres = _dbContext.Genres.ToList();
                return View("TourForm", tourFormViewModel);
            }
            var userId = User.Identity.GetUserId();
            var tour = _dbContext.Tours
                .Include(a =>a.Attendences.Select(s =>s.Attendee))
                .Single(t => t.Id == tourFormViewModel.Id && t.TravellerID == userId);

            tour.Modify(tourFormViewModel.GetDateTime(), tourFormViewModel.Place,
                tourFormViewModel.TotalSeat, tourFormViewModel.Cost,
                tourFormViewModel.Genre);

            //tour.Place = tourFormViewModel.Place;
            //tour.TotalSeat = tourFormViewModel.TotalSeat;
            //tour.DateTime = tourFormViewModel.GetDateTime();
            //tour.Cost = tourFormViewModel.Cost;
            //tour.GenreID = tourFormViewModel.Genre;

            //update data
            _dbContext.SaveChanges();
            return RedirectToAction("Mine", "Tour");
        }

        [Authorize]
        public ActionResult Feed()
        {

            var feed = _dbContext.Tours
                .Include(t => t.Traveller)
                .Include(t => t.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);
            var viewmodel = new FeedViewModel
            {
                UpcommingTours = feed,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcomming Tours"
            };
            return View("Feed", viewmodel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var tourOfMine = _dbContext.Tours
                .Where(t => t.TravellerID == userId && t.DateTime > DateTime.Now && !t.IsCanceled)
                .Include(t =>t.Genre)
                .ToList();
            return View(tourOfMine);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var tourToAttend = _dbContext.Attendences
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Tour)
                .Include(t => t.Traveller)
                .Include(g => g.Genre)
                .ToList();
            var attend = new FeedViewModel
            {
                UpcommingTours = tourToAttend,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Tour I am going"
            };
            return View("Feed", attend);
        }
        public ActionResult Details(int id)
        {
            var tour = _dbContext.Tours
                .Include(t => t.Traveller)
                .Include(t => t.Genre)
                .SingleOrDefault(t => t.Id == id);
            if (tour == null)
                return HttpNotFound();
            var viewModel = new TourDetailsViewModel
            {
                Tour = tour,
                Going = _dbContext.Attendences.Where(t => t.TourId == id).Count()
            };
            if(User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                viewModel.IsAttending = _dbContext.Attendences
                    .Any(t => t.TourId == tour.Id && t.AttendeeId == userId);
                viewModel.IsFollowing = _dbContext.Followings
                    .Any(f => f.FolloweeId == tour.TravellerID && f.FollowerId == userId);

            }
            return View("Details", viewModel);
        }

    }
}