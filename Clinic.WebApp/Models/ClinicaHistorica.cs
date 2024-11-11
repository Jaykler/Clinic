
namespace Clinic.WebApp.Models;

public partial class ClinicaHistorica
{
    public int IdhistoriaClinica { get; set; }

    public int? Idpaciente { get; set; }

    public string? Identificacion { get; set; }

    public DateTime? FechaApertura { get; set; } = DateTime.Now;

    public int? Estado { get; set; } = 1;

    public virtual MStatus? EstadoNavigation { get; set; }
}
