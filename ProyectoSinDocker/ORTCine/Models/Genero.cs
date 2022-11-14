using System.ComponentModel.DataAnnotations;

namespace ORTCine.Models
{
    public enum Genero
    {
        [Display(Name = "Terror")]
        Terror,
        [Display(Name = "Suspenso")]
        Suspenso,
        [Display(Name = "Comedia")]
        Comedia,
        [Display(Name = "Thriller")]
        Thriller
    }
}