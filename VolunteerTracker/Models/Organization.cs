﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerTracker.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Cause { get; set; }

        public virtual IList<Event> Events { get; set; }
        public virtual IList<Volunteer> Volunteers { get; set; }
    }
}