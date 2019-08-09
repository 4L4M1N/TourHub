using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TourHub.Models
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Tour> Tours { get; set; }
            public DbSet<Genre> Genres { get; set; }
            public ApplicationDbContext()
                : base("TourTour", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
 
}