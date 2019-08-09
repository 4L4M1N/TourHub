using Microsoft.AspNet.Identity;
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
            var attendent = new Attendence
            {
                TourId = tourid,
                AttendeeId = User.Identity.GetUserId()
            };
            _context.Attendences.Add(attendent);
            _context.SaveChanges();
            return Ok();
        }

    }
}