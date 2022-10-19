using ProyectoCine;

namespace ORTCine.Models
{
    public class Cine
    {
        public int CineID { get; set; }
        public String nombre { get; set; }


        public virtual ICollection<Pelicula> funciones { get; set; }
        public virtual ICollection<Cliente> clientes { get; set; }
    }
}
