using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.ViewModels
{
    public class TourFormViewModel
    {
        [Required]
        public string Place { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime() {

                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}