using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Acceler.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual ICollection<Ride> JoinedRides { get; set; }
    }
}