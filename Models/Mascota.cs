using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaPetCare.Models
{
    // añadir una validación personalizada
    // que la fecha de ingreso no sea futura.
    public class Mascota : IValidatableObject
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        [Display(Name = "Nombre de la Mascota")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una especie.")]
        [Display(Name = "Especie")]
        public string Especie { get; set; } // Perro, Gato, Ave, reptill,otro

        [StringLength(50, ErrorMessage = "La raza no debe exceder los 50 caracteres.")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(0, 25, ErrorMessage = "La edad debe estar entre 0 y 25 años.")]
        [Display(Name = "Edad (años)")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El nombre del dueño es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre del dueño debe tener al menos 3 caracteres.")]
        [Display(Name = "Nombre del Dueño")]
        public string NombreDueno { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Formato de teléfono inválido (ej. 809-555-1234).")]
        [Display(Name = "Teléfono del Dueño")]
        public string TelefonoDueno { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }


        // Validación personalizada para asegurar que la fecha de ingreso no sea futura
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaIngreso > DateTime.Today)
            {
                yield return new ValidationResult(
                    "La fecha de ingreso no puede ser futura.",
                    new[] { nameof(FechaIngreso) }
                );
            }
        }
    }
}