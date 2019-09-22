using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourHub.Core.Models
{
    public class UserNotification
    {

        public string UserId { get; private set; }


        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; set; }
        protected UserNotification()
        {
        }
        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user is null");
            if (notification == null)
                throw new ArgumentNullException("notification is null");

            User = user;
            Notification = notification;
        }
        public void Read()
        {
            IsRead = true;
        }
    }
}