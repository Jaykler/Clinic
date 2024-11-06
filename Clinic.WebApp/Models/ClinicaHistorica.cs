
namespace Clinic.WebApp.Models;

public partial class ClinicaHistorica
{
    public int IdhistoriaClinica { get; set; }

    public int? Idpaciente { get; set; }

    public string? Identificacion { get; set; }

    public DateTime? FechaApertura { get; set; }

    public int? Estado { get; set; }

    public virtual MStatus? EstadoNavigation { get; set; }
}
