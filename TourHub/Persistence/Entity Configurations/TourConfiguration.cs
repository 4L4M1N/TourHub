using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace TourHub.Persistence.Entity_Configurations
{
    public class TourConfiguration : EntityTypeConfiguration<Tour>
    {

        public TourConfiguration()
        {
            Property(t => t.TravellerID)
                .IsRequired();

            Property(t => t.Place)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.GenreID)
                .IsRequired();

            Property(t => t.Cost)
                .IsRequired();

            Property(t => t.TotalSeat)
                .IsRequired();

            HasMany(a => a.Attendences)
                .WithRequired(t =>t.Tour)
                .WillCascadeOnDelete(false);
        }
    }
}