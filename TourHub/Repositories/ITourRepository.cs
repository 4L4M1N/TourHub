using System.Collections.Generic;
using System.Linq;
using TourHub.Models;

namespace TourHub.Repositories
{
    public interface ITourRepository
    {
        void Add(Tour tour);
        List<Tour> GetMineTour(string userId);
        Tour GetTourDetails(int id);
        Tour GetTour(int id);
        IQueryable<Tour> GetTourFeed();
        IEnumerable<Tour> GetTourUserAttending(string userId);
        Tour GetTourWithAttendees(int tourId);
    }
}