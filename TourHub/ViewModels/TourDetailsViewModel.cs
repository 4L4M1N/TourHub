using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.ViewModels
{
    public class TourDetailsViewModel
    {
        public Tour Tour { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
        public int Going { get; set; }
    }
}