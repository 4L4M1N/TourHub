using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TourHub.Core.Models;

namespace TourHub.Persistence.Entity_Configurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(u => new {u.UserId, u.NotificationId});
            HasRequired(u =>u.User)
                .WithMany(un => un.UserNotifications)
                .WillCascadeOnDelete(false);
        }
    }
}