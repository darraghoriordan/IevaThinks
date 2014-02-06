using IsmsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsmsWebApplication.DataContext
{
    public class IsmDataContext : DbContext
    {
        public IsmDataContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Ism> Isms { get; set; }
        public DbSet<IsmConfiguration> IsmConfigurations { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}