using ORTCine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoCine
{
    public class Entrada
    {
        public int entradaID { get; set; }
        public double valor { get; set; }
        public int numeroButaca { get; set; }
        public Sala sala { get; set; }
        public Pelicula pelicula { get; set; }


    }
}
