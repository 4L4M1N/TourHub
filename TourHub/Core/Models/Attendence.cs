using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourHub.Core.Models
{
    public class Attendence
    {
        public Tour Tour { get; set; }
        public ApplicationUser Attendee { get; set; }
        public int TourId { get; set; }
        public string AttendeeId { get; set; }
    }
}