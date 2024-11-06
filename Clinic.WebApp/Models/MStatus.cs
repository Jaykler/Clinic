

namespace Clinic.WebApp.Models;

public partial class MStatus
{
    public int Idstatus { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<ClinicaDiagnostico> ClinicaDiagnosticos { get; set; } = new List<ClinicaDiagnostico>();

    public virtual ClinicaEspecialidad? ClinicaEspecialidad { get; set; }

    public virtual ICollection<ClinicaHistorica> ClinicaHistoricas { get; set; } = new List<ClinicaHistorica>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
