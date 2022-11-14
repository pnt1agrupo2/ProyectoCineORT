using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORTCine.Models
{
    public class Cliente :  IdentityUser<Guid>
    {
        [Required(ErrorMessage = "Se requiere una edad")]
        [Display(Name = "Edad")]
        public int edad { get; set; }
        
        [Required(ErrorMessage = "Se requiere un nombre")]
        [Display(Name = "Nombre")]
        public String nombre { get; set; }
        
        [Required(ErrorMessage = "Se requiere un apellido")]
        [Display(Name = "Apellido")]
        public String apellido { get; set; }

        public virtual ICollection<Entrada> BoletosComprados { get; set; }
    }
}
