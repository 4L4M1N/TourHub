using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TourHub.Core.Models;

namespace TourHub.Persistence.Entity_Configurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(t => t.Tour); //For other entity of a table in a table
        }
    }
}