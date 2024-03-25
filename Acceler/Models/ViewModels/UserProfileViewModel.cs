using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acceler.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
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

        [Display(Name = "Vožnje kojima se korisnik pridružio")]
        public virtual ICollection<Ride> JoinedRides { get; set; }

        [Display(Name = "Vlasnik vožnji")]
        public virtual ICollection<Ride> CreatedRides { get; set; }

    }
}