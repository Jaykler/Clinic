

namespace Clinic.WebApp.Models;

public partial class MStatus
{
    public int Idstatus { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
