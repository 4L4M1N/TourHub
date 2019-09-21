using System;

namespace TourHub.Core.DTOs
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