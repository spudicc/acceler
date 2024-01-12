using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acceler.Models
{
    public class Ride
    {
        public string Id { get; set; }

        [Display(Name = "Naziv rute")]
        public string Name { get; set; }

        [Display(Name = "Vrijeme polaska")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double StartingPointLatitude { get; set; }   // S-J
        public double StartingPointLongitude { get; set; }  // I-Z
        public double EndingPointLatitude { get; set; }
        public double EndingPointLongitude { get; set; }

        [Display(Name = "Izbjegni autocestu")]
        public bool AvoidHighways { get; set; }
        public List<Waypoint> Waypoints { get; set; }
        public User Owner { get; set; }
        public ICollection<User> Members { get; set; }
    }
}