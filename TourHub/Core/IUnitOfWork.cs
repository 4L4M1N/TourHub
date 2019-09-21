using TourHub.Core.Repositories;

namespace TourHub.Core
{
    public interface IUnitOfWork
    {
        IAttendenceRepository Attendences { get; }
        IFollowingRepository Followings { get; }
        IGenreRepository Genres { get; set; }
        ITourRepository Tours { get; }

        void Complete();
    }
}