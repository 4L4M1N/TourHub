using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TourHub.Core.DTOs;
using TourHub.Core.Models;
using TourHub.Persistence;

namespace TourHub.Controllers.Api
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
        public IHttpActionResult Attend(AttendenceDTO dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendences.
                Any(a => a.AttendeeId == userId && a.TourId == dto.TourId))
                return BadRequest("You have already registered");
            var attendent = new Attendence
            {
                TourId = dto.TourId,
                AttendeeId = userId
            };
            _context.Attendences.Add(attendent);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteAttendence(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendence = _context.Attendences
                .SingleOrDefault(a => a.AttendeeId == userId && a.TourId == id);
            if (attendence == null)
                return NotFound();
            _context.Attendences.Remove(attendence);
            _context.SaveChanges();
            return Ok(id);
        }
    }
}