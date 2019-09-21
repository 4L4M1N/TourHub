using System.Collections.Generic;
using TourHub.Core.Models;

namespace TourHub.Core.Repositories
{
    public interface IAttendenceRepository
    {
        Attendence GetAttendence(int tourId, string userId);
        IEnumerable<Attendence> GetFutureAttendences(string userId);
        int GetTotal(int id);
    }
}