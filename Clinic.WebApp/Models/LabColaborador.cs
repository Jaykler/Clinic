using System.ComponentModel.DataAnnotations;

namespace Clinic.WebApp.Models
{
    public class LabColaborador
    {
        [Key]
        public int Id { get; set; }
        public string Colaborador { get; set; }
        public string? NombreColaborador { get; set; }
        public int Estatus { get; set; }
        public string? Departamento { get; set; }
        public int Definido { get; set; }
        public string? Registrado { get; set; }
    }
}
