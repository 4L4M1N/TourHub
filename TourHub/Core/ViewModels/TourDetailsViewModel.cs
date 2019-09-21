using TourHub.Core.Models;

namespace TourHub.Core.ViewModels
{
    public class TourDetailsViewModel
    {
        public Tour Tour { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
        public int Going { get; set; }
    }
}