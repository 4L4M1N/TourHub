using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Core;
using TourHub.Core.Models;
using TourHub.Core.Repositories;
using TourHub.Persistence.Repositories;

namespace TourHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ITourRepository Tours { get; private set; }
        public IAttendenceRepository Attendences { get; private set; }
        public IFollowingRepository Followings { get; private set; }
        public IGenreRepository Genres { get; set; }
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