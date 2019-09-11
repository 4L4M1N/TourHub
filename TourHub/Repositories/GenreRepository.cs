using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.Repositories
{
    public class GenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Genre> GetGenre()
        {
            return _context.Genres.ToList();
        }
    }
}