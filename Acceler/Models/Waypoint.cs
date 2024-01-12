using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acceler.Models
{
    public class Waypoint
    {
        public int Id { get; set; }
        public string Latitude { get; set; } 
        public string Longitude { get; set; } 
        public bool IsStopover { get; set; }
    }
}