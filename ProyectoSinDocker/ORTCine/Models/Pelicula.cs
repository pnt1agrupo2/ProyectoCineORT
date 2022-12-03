using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORTCine.Models
{
    public class Pelicula
    {
        public int peliculaID { get; set; }
               
        [Required (ErrorMessage = "Requiere un titulo")]
        [Display(Name = "Título")]
        public String nombre { get; set; }
        
        [Required(ErrorMessage = "Requiere un género")]
        [Display(Name = "Género")]
        public Genero genero { get; set; }

        [Display(Name = "Está subtitulada")]
        public Boolean estaDoblada { get; set; }
        
        [Display(Name = "Es apta para todo público")]
        public Boolean esAtp { get; set; }

        
        public int? salaId { get; set; }

        [Display(Name = "Numero de sala")]
        [Required(ErrorMessage = "Se requiere una sala")]
        public Sala sala { get; set; }
       



        public virtual ICollection<Entrada> BoletosVendidos { get; set; }
    }

    
}
