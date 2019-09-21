using System;
using System.ComponentModel.DataAnnotations;

namespace TourHub.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OrginalDateTime { get; private set; }
        public string OrginalPlace { get; private set; }

        [Required]
        public Tour Tour { get; private set; }
        protected Notification()
        {
        }
        private Notification(NotificationType type, Tour tour)
        {
            if (tour == null)
                throw new ArgumentNullException("Tour is null");
            Type = type;
            Tour = tour;
            DateTime = DateTime.Now;
        }

        public static Notification TourCreated(Tour tour)
        {
            return new Notification(NotificationType.TourCreated, tour);
        }

        public static Notification TourUpdated(Tour newTour, DateTime orginalDateTime, string orginalPlace)
        {
            var notification = new Notification(NotificationType.TourUpdated, newTour);
            notification.OrginalDateTime = orginalDateTime;
            notification.OrginalPlace = orginalPlace;

            return notification;
        }

        public static Notification TourCanceled(Tour tour)
        {
            return new Notification(NotificationType.TourCanceled, tour);
        }

    }
}