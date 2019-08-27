using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Models;

namespace TourHub.DTOs
{
    public class NotificationDTO
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OrginalDateTime { get; set; }
        public string OrginalPlace { get; set; }
        public TourDTO Tour { get; set; }
    }
}