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
        [Display(Name = "Entradas disponibles")]
        public int entradaDisponibles { get; set; }
        [Display(Name = "Título")]
        public String nombre { get; set; }
        [Display(Name = "Género")]
        public String genero { get; set; }
        [Display(Name = "Está subtitulada")]
        public Boolean estaDoblada { get; set; }
        [Display(Name = "Es apta para todo público")]
        public Boolean esAtp { get; set; }
        
        public virtual ICollection<Entrada> BoletosVendidos { get; set; }
    }
}
