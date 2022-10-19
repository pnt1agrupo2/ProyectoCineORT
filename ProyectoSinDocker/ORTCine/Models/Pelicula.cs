using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoCine
{
    class Pelicula
    {
        public int peliculaID { get; set; }
        public int entradaDisponibles { get; set; }
        public String nombre { get; set; }
        public String genero { get; set; }
        public Boolean estaDoblada { get; set; }
        public Boolean esAtp { get; set; }
    }
}
