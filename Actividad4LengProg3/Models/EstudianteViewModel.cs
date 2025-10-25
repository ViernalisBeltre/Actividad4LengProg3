using System.ComponentModel.DataAnnotations;
using System;

namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "Digite el nombre completo")]
        [StringLength(100)]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Digite la matrícula")]
        [StringLength(15, MinimumLength = 6)]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Seleccione la carrera")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "Seleccione el recinto")]
        public string Recinto { get; set; }

        [Required(ErrorMessage = "Digite el correo institucional")]
        [EmailAddress(ErrorMessage = "El formato de correo inválido")]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; }

        [Phone]
        [MinLength(10)]
        public string Celular { get; set; }

        [Phone]
        [MinLength(10)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Digite la dirección")]
        [StringLength(200)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Indique la fecha de nacimiento")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Digite el género")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Digite el turno")]
        public string Turno { get; set; }

        [Display(Name = "¿Está becado?")]
        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100")]
        [Display(Name = "Porcentaje de beca")]
        public int? PorcentajeBeca { get; set; }
    }
}
