using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.Repositories
{
    public class AttendenceRepository : IAttendenceRepository
    {

        private readonly ApplicationDbContext _context;
        public AttendenceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendence> GetFutureAttendences(string userId)
        {
            return _context.Attendences
                            .Where(a => a.AttendeeId == userId && a.Tour.DateTime > DateTime.Now)
                            .ToList();
        }
        public Attendence GetAttendence(int tourId, string userId)
        {
            return _context.Attendences
                .SingleOrDefault(a => a.TourId == tourId && a.AttendeeId == userId);
        }
        public int GetTotal(int id)
        {
            return _context.Attendences.Where(g => g.TourId == id).Count();
        }
    }
}