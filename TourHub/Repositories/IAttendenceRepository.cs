using System.Collections.Generic;
using TourHub.Models;

namespace TourHub.Repositories
{
    public interface IAttendenceRepository
    {
        Attendence GetAttendence(int tourId, string userId);
        IEnumerable<Attendence> GetFutureAttendences(string userId);
        int GetTotal(int id);
    }
}