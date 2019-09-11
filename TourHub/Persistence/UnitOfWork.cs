using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;
using TourHub.Repositories;

namespace TourHub.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public TourRepository Tours { get; private set; }
        public AttendenceRepository Attendences { get; private set; }
        public FollowingRepository Followings { get; private set; }
        public GenreRepository Genres { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Tours = new TourRepository(context);
            Attendences = new AttendenceRepository(context);
            Followings = new FollowingRepository(context);
            Genres = new GenreRepository(context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}