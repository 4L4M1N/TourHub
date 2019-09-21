using System.Collections.Generic;
using System.Linq;
using TourHub.Core.Models;
using TourHub.Core.Repositories;

namespace TourHub.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
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