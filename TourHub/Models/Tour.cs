using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourHub.Models
{
    public class Tour
    {
      
        public int Id { get; set; }

        
        public ApplicationUser Traveller { get; set; }
        [Required]
        public string TravellerID { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Place { get; set; }

        [Required]
        public decimal Cost { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public byte GenreID { get; set; }

        [Required]
        public int TotalSeat { get; set; }
    }
}