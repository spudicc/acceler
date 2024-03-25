using System.ComponentModel.DataAnnotations;

namespace Acceler.Models
{
    public class LoginDTO
    {
        [Display(Name = "Korisničko ime")]
        [Required(ErrorMessage = "Korisničko ime ne može biti prazno.")]
        public string Username { get; set; }

        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka ne može biti prazna.")]
        public string Password { get; set; }
    }
}
