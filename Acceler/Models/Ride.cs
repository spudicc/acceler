using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acceler.Models
{
    public class Ride
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Naziv rute")]
        public string Name { get; set; }

        [Display(Name = "Vrijeme polaska")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double StartingPointLatitude { get; set; }
        public double StartingPointLongitude { get; set; }
        public double EndingPointLatitude { get; set; }
        public double EndingPointLongitude { get; set; }

        [Display(Name = "Izbjegni autocestu")]
        public bool AvoidHighways { get; set; }
        public int? RideOwnerId { get; set; }
        public virtual RideOwner RideOwner { get; set; }
        public virtual ICollection<Waypoint> Waypoints { get; set; }
        public virtual ICollection<User> RideMembers { get; set; }
    }
}