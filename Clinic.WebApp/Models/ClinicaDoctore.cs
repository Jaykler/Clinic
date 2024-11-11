
namespace Clinic.WebApp.Models;

public partial class ClinicaDoctore
{
    public int Iddoctor { get; set; }

    public string? Identificacion { get; set; }

    public string? Nombres { get; set; }

    public int? Idespecialidad { get; set; }

    public int? Estado { get; set; } = 1;
}
