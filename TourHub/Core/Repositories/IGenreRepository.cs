using System.Collections.Generic;
using TourHub.Core.Models;

namespace TourHub.Core.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetGenre();
    }
}