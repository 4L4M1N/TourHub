using TourHub.Repositories;

namespace TourHub.Persistence
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