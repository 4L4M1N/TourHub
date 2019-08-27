using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.DTOs
{
    public class TourDTO
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }
        public UserDTO Traveller { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        public decimal Cost { get; set; }
        public GenreDTO Genre { get; set; }
        public int TotalSeat { get; set; }
    }
}