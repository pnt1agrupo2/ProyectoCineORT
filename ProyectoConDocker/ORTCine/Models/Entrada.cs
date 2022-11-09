using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORTCine.Models
{
    public class Entrada
    {
        public int entradaID { get; set; }
        [Display(Name = "Valor")]
        public double valor { get; set; }
        [Display(Name = "Número de butaca")]
        public int numeroButaca { get; set; }
        public int? SalaId { get; set; }
        [Display(Name = "Sala")]
        public virtual Sala sala { get; set; }
        public int? PeliculaId { get; set; }
        [Display(Name = "Pelicula")]
        public virtual Pelicula pelicula { get; set; }
        public int? ClienteId { get; set; }
        [Display(Name = "Cliente")]
        public virtual Cliente cliente { get; set; }
        
        //public int? BakeryId { get; set; }
        //public virtual Bakery Bakery { get; set; }


    }
}
