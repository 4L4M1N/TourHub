using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourHub.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public ApplicationUser Traveller { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        public decimal Cost { get; set; }
        public Genre Genre { get; set; }
    }
}