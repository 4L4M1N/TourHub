using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TourHub.Models;

namespace TourHub.Controllers
{

    [Authorize]
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendencesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody]int tourid)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendences.
                Any(a => a.AttendeeId == userId && a.TourId == tourid))
                return BadRequest("You have already registered");
            var attendent = new Attendence
            {
                TourId = tourid,
                AttendeeId = userId
            };
            _context.Attendences.Add(attendent);
            _context.SaveChanges();
            return Ok();
        }

    }
}