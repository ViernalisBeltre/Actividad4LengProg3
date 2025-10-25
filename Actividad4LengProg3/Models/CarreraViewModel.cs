using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class CarreraViewModel
    {
        [Required(ErrorMessage = "Digite el código de la carrera")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Seleccione la carrera")]
        [Display(Name = "Nombre de la Carrera")]
        public string NombreCarrera { get; set; }

        [Required(ErrorMessage = "Digite la cantidad de créditos")]
        [Display(Name = "Cantidad de Créditos")]
        public int CantidadCreditos { get; set; }

        [Required(ErrorMessage = "Digite la cantidad de materias")]
        [Display(Name = "Cantidad de Materias")]
        public int CantidadMaterias { get; set; }
    }
}
