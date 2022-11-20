using System;
using System.ComponentModel.DataAnnotations;

namespace ORTCine.ViewModel
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Se requiere un nombre")]
        [Display(Name = "Nombre")]
        public String nombre { get; set; }

        [Required(ErrorMessage = "Se requiere un apellido")]
        [Display(Name = "Apellido")]
        public String apellido { get; set; }
        
        [Required(ErrorMessage = "Se requiere una edad")]
        [Display(Name = "Edad")]
        public int edad { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
