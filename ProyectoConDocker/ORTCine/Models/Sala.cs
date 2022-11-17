using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORTCine.Models
{
    public class Sala
    {
        public int salaID { get; set; }
        
        [Display(Name = "Número de sala")]
        [Range(1, 8, ErrorMessage = "La sala debe estar entre 1 y 8")]
        public int numeroSala { get; set; }
        
        [Display(Name = "Capacidad máxima")]
        [Range(50, 75, ErrorMessage = "La capacidad debe estar entre 50 y 75")]
        public int capacidadMax { get; set; }


        //public virtual IEnumerable<int> Butacas { get; set; }
        public virtual ICollection<Entrada> BoletosVendidos { get; set; }
    }
}
