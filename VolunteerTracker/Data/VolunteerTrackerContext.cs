using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VolunteerTracker.Models;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VolunteerTracker.Data
{
    public class VolunteerTrackerContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        //public VolunteerTrackerContext() : base("VolunteerTrackerContext")
        //{
        //}
    }
}