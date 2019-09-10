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
        public List<Tour> GetMineTour(string userId)
        {
            return _context.Tours
                .Where(t => t.TravellerID == userId && t.DateTime > DateTime.Now && !t.IsCanceled)
                .Include(t => t.Genre)
                .ToList();
        }
        public Tour GetTourDetails(int id)
        {
            return _context.Tours
                .Include(t => t.Traveller)
                .Include(t => t.Genre)
                .SingleOrDefault(t => t.Id == id);
        }

        public IQueryable<Tour> GetTourFeed()
        {
            return _context.Tours
                .Include(t => t.Traveller)
                .Include(t => t.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);
        }
        public void Add(Tour tour)
        {
            _context.Tours.Add(tour);
        }
    }
}