﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORTCine.Models
{
    public class Entrada
    {
        public int entradaID { get; set; }

        [Required(ErrorMessage = "Requiere un numero de butaca")]
        [Range(1, 50, ErrorMessage = "La butaca debe estar entre la 1 y la 50")]
        [Display(Name = "Número de butaca")]
        public int numeroButaca { get; set; }
        
        public int? PeliculaId { get; set; }

        [Required(ErrorMessage = "Requiere una pelicula")]
        [Display(Name = "Pelicula")]
        public virtual Pelicula pelicula { get; set; }
        public Guid? ClienteId { get; set; }
        
        [Display(Name = "Cliente")]
        public virtual Cliente cliente { get; set; }
        


    }
}
