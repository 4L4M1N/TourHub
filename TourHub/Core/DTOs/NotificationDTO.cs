using System;
using TourHub.Core.Models;

namespace TourHub.Core.DTOs
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