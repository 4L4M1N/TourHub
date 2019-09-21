using System.Collections.Generic;
using System.Linq;
using TourHub.Core.Models;

namespace TourHub.Core.ViewModels
{
    public class FeedViewModel
    {
        public IEnumerable<Tour> UpcommingTours { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendence>Attendences { get; set; }
    }
}