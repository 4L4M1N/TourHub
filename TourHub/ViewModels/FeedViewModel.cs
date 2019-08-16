using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.ViewModels
{
    public class FeedViewModel
    {
        public IEnumerable<Tour> UpcommingTours { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}