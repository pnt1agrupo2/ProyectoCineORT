using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ORTCine.Models
{
    public class Cine
    {
       
        public int CineID { get; set; }
        
        [Display(Name = "Nombre")]
        public String nombre { get; set; }


        public virtual ICollection<Pelicula> Funciones { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}

