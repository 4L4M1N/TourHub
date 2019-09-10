using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.Repositories
{
    public class TourRepository
    {
        private readonly ApplicationDbContext _context;
        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Tour GetTourWithAttendees(int tourId)
        {
            return _context.Tours
                .Include(a => a.Attendences.Select(s => s.Attendee))
                .SingleOrDefault(t => t.Id == tourId);
        }
        public IEnumerable<Tour> GetTourUserAttending(string userId)
        {
            return _context.Attendences
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Tour)
                .Include(t => t.Traveller)
                .Include(g => g.Genre)
                .ToList();
        }
    }
}