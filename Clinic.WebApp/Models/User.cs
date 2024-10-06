using System;
using System.Collections.Generic;

namespace Clinic.WebApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Edad { get; set; }

    public int IdEstatus { get; set; }

    public virtual MStatus IdEstatusNavigation { get; set; } = null!;
}
