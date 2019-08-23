using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourHub.Models;

namespace TourHub.Controllers.Api
{
    [Authorize]
    public class TourController : ApiController
    {
        private ApplicationDbContext _context;
        public TourController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var tour = _context.Tours.Single(t => t.Id == id && t.TravellerID == userId);
            if (tour.IsCanceled)
                return NotFound();
            tour.IsCanceled = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
