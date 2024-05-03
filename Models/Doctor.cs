using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsultasPacientes12.Models;

public partial class Doctor
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Apellido { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
