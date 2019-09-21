using System.Linq;
using TourHub.Core.Models;
using TourHub.Core.Repositories;

namespace TourHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Following GetFollowing(string followerId, string followeeId)
        {
            return _context.Followings                .SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
        }

    }
}