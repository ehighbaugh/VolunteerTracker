using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VolunteerTracker.Models;

namespace VolunteerTracker.Data
{
    public class VolunteerTrackerInitializer : DropCreateDatabaseIfModelChanges<VolunteerTrackerContext>
    {
        protected override void Seed(VolunteerTrackerContext context)
        {
            var events = new List<Event>
            {
                new Event
                {
                    Address = "x", Contact = "e", Email = "w", Id = 1, Location = "ky", Phone = "5", Title = "new", VolunteersNeeded = 5
                }
            };

            var organizations = new List<Organization>
            {
                new Organization
                {
                    Address = "x",
                    Email = "w",
                    Id = 1,
                    Phone = "5", Cause = "d", ContactPerson = "l", Name = "e", Website = "df"
                }
            };

            var volunteers = new List<Volunteer>
            {
                new Volunteer
                {
                    Address = "x", CellPhone = "e", Email = "w", Id = 1, HomePhone = "ky", Name = "5"
                }
            };
        }
    }
}