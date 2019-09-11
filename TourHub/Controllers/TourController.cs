using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourHub.Models;
using TourHub.Persistence;
using TourHub.Repositories;
using TourHub.ViewModels;

namespace TourHub.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        private readonly ApplicationDbContext _dbContext;
        private readonly UnitOfWork _unitOfWork;
        public TourController()
        {
            _dbContext = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_dbContext);
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
            _unitOfWork.Tours.Add(tour);
            _unitOfWork.Complete();
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
                tourFormViewModel.Genres = _unitOfWork.Genres.GetGenre();
                return View("TourForm", tourFormViewModel);
            }

            var tour = _unitOfWork.Tours.GetTourWithAttendees(tourFormViewModel.Id);

            if (tour == null)
                return HttpNotFound();

            if (tour.TravellerID != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            tour.Modify(tourFormViewModel.GetDateTime(), tourFormViewModel.Place,
                tourFormViewModel.TotalSeat, tourFormViewModel.Cost,
                tourFormViewModel.Genre);

            //tour.Place = tourFormViewModel.Place;
            //tour.TotalSeat = tourFormViewModel.TotalSeat;
            //tour.DateTime = tourFormViewModel.GetDateTime();
            //tour.Cost = tourFormViewModel.Cost;
            //tour.GenreID = tourFormViewModel.Genre;

            //update data
            _unitOfWork.Complete();
            return RedirectToAction("Mine", "Tour");
        }

       

        [Authorize]
        public ActionResult Feed(string query = null)
        {
            IQueryable<Tour> feed = _unitOfWork.Tours.GetTourFeed();
            if (!String.IsNullOrWhiteSpace(query))
            {
                feed = feed
                    .Where(g =>
                    g.Traveller.Name.Contains(query) ||
                    g.Genre.Name.Contains(query) ||
                    g.Place.Contains(query));
            }
            var userId = User.Identity.GetUserId();
            var attendences = _unitOfWork.Attendences.GetFutureAttendences(userId)
                .ToLookup(a => a.TourId);
            var viewmodel = new FeedViewModel
            {
                UpcommingTours = feed,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcomming Tours",
                SearchTerm = query,
                Attendences = attendences
            };
            return View("Feed", viewmodel);
        }


        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            List<Tour> tourOfMine = _unitOfWork.Tours.GetMineTour(userId);
            return View(tourOfMine);
        }


        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            //List<Tour> tourToAttend = GetTourUserAttending(userId);


            var attend = new FeedViewModel
            {
                UpcommingTours = _unitOfWork.Tours.GetTourUserAttending(userId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Tour I am going",
                Attendences = _unitOfWork.Attendences.GetFutureAttendences(userId)
                .ToLookup(a => a.TourId)
            };
            return View("Feed", attend);
        }

        public ActionResult Details(int id)
        {
            Tour tour = _unitOfWork.Tours.GetTourDetails(id);
            if (tour == null)
                return HttpNotFound();
            var viewModel = new TourDetailsViewModel
            {
                Tour = tour,
                Going = _dbContext.Attendences.Where(t => t.TourId == id).Count()
            };
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                viewModel.IsAttending = _unitOfWork.Attendences.GetAttendence(tour.Id, userId) != null;
                viewModel.IsFollowing = _unitOfWork.Followings.GetFollowing(userId, tour.TravellerID) != null;

            }
            return View("Details", viewModel);
        }

        

        [HttpPost]
        public ActionResult Search(FeedViewModel viewModel)
        {
            return RedirectToAction("Feed", "Tour", new { query = viewModel.SearchTerm });
        }

    }
}