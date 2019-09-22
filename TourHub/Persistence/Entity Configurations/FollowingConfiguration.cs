using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TourHub.Core.Models;

namespace TourHub.Persistence.Entity_Configurations
{
    public class FollowingConfiguration : EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {
            HasKey(f => new {f.FollowerId, f.FolloweeId});
        }
    }
}