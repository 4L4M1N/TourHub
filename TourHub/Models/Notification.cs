using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourHub.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OrginalDateTime { get; set; }
        public string OrginalPlace { get; set; }

        [Required]
        public Tour Tour { get; set; }

    }
}