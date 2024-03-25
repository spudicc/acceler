using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acceler.Models
{
    public class Waypoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Latitude { get; set; } 
        public double Longitude { get; set; } 
        public bool IsStopover { get; set; }
        public string RideId { get; set; }
        public virtual Ride Ride { get; set; }
    }
}