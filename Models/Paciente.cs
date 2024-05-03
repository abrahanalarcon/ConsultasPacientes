using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsultasPacientes12.Models;

public partial class Paciente
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Apellido { get; set; } = null!;
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public DateTime FechaNacimiento { get; set; }
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(11, ErrorMessage = "La cédula debe tener exactamente 11 dígitos.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "La cédula solo puede contener números.")]
    public string Cedula { get; set; } = null!;
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(10, ErrorMessage = "El teléfono debe tener exactamente 10 dígitos.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "El teléfono solo puede contener números.")]
    public string Telefono { get; set; } = null!;

    public int? IdDoctor { get; set; }

    public virtual Doctor? IdDoctorNavigation { get; set; }
}
