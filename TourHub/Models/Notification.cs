using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OrginalDateTime { get; set; }
        public string OrginalPlace { get; set; }

        [Required]
        public Tour Tour { get; private set; }
        protected Notification()
        {
        }
        public Notification(NotificationType type, Tour tour)
        {
            if (tour == null)
                throw new ArgumentNullException("Tour is null");
            Type = type;
            Tour = tour;
            DateTime = DateTime.Now;
        }

    }
}