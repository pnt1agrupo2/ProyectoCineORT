﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORTCine.Models
{
    public class Cliente :  IdentityUser<Guid>
    {
        
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Display(Name = "Nombre")]
        public String nombre { get; set; }
        [Display(Name = "Apellido")]
        public String apellido { get; set; }

        public virtual ICollection<Entrada> BoletosComprados { get; set; }
    }
}
