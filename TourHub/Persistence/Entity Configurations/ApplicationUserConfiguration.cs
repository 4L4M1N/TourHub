using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TourHub.Core.Models;

namespace TourHub.Persistence.Entity_Configurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

         
            HasMany(f => f.Followers)
            .WithRequired(f => f.Followee) //Foreign key..Followers must have a Followee
            .WillCascadeOnDelete(false);

       
            HasMany(f => f.Followees)
            .WithRequired(f => f.Follower)
            .WillCascadeOnDelete(false);

        }
    }
}