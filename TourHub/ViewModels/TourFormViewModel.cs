using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.ViewModels
{
    public class TourFormViewModel
    {
        public string Place { get; set; }
        public decimal Cost { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}