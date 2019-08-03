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
        public ActionResult Create()
        {
            var viewModel = new TourFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}