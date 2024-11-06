
namespace Clinic.WebApp.Models;

public partial class ClinicaDiagnostico
{
    public int Iddiagnostico { get; set; }

    public int? IdhistoricaClinica { get; set; }

    public string? Identificacion { get; set; }

    public int? Iddoctor { get; set; }

    public DateTime? FechaDiagnostico { get; set; }

    public string? Diagnosticos { get; set; }

    public string? Observaciones { get; set; }

    public string? ExamenLab { get; set; }

    public int? Estado { get; set; }

    public virtual MStatus? EstadoNavigation { get; set; }
}
