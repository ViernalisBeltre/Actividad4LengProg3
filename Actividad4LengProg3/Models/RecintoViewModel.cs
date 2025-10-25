using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class RecintoViewModel
    {
        [Required(ErrorMessage = "Digite el código del recinto")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Digite el nombre del recinto")]
        [StringLength(100)]
        [Display(Name = "Nombre del Recinto")]
        public string NombreRecinto { get; set; }

        [Required(ErrorMessage = "Digite la dirección del recinto")]
        [StringLength(100)]
        [Display(Name = "Dirección del Recinto")]
        public string DireccionRecinto { get; set; }
    }
}
