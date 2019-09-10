using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.Repositories
{
    public class FollowingRepository
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