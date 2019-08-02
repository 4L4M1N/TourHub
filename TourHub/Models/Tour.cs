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

        [Required]
        public ApplicationUser Traveller { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Place { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}