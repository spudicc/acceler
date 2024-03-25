using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acceler.Models.DTO
{
    public class RideDTO
    {
        [Display(Name = "Naziv rute")]
        public string Name { get; set; }

        [Display(Name = "Vrijeme polaska")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string StartingPointLatitude { get; set; }   // S-J
        public string StartingPointLongitude { get; set; }  // I-Z
        public string EndingPointLatitude { get; set; }
        public string EndingPointLongitude { get; set; }

        [Display(Name = "Izbjegni autocestu")]
        public bool AvoidHighways { get; set; }
        public virtual ICollection<Waypoint> Waypoints { get; set; }
    }
}