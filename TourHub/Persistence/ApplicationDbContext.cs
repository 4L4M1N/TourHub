using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TourHub.Core.Models;

namespace TourHub.Persistence
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Tour> Tours { get; set; }
            public DbSet<Genre> Genres { get; set; }
           

        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public ApplicationDbContext()
                : base("TourTour", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendence>()
                .HasRequired(a => a.Tour)
                .WithMany(t => t.Attendences)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(f => f.Followers)
                .WithRequired(f => f.Followee) //Foreign key..Followers must have a Followee
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(f => f.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserNotification>()
                .HasRequired(f => f.User)
                .WithMany(n => n.UserNotifications)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }
    }
 
}