using System.Collections.Generic;
using TourHub.Models;

namespace TourHub.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetGenre();
    }
}