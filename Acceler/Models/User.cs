using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acceler.Models
{
    public class User
    {
        public string Id { get; set; }

        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        public string LastName { get; set; }
        public string Email { get; set; }

        [Display(Name = "Broj mobitela")]
        public string Phone { get; set; }
        public virtual IEnumerable<Ride> Rides { get; set; }
    }
}