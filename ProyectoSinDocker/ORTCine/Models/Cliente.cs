using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoCine
{
    class Cliente
    {
        public int edad { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }

        public virtual ICollection<Entrada> boletosComprados { get; set; }
    }
}
