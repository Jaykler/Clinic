

namespace Clinic.WebApp.Models;

public partial class ClinicaEspecialidad
{
    public int Idespecialidad { get; set; }

    public string? Nombre { get; set; }

    public int? Estado { get; set; }

    public virtual MStatus IdespecialidadNavigation { get; set; } = null!;
}
