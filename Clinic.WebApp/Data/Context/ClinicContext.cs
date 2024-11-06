using Clinic.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.WebApp.Data.Context;

public partial class ClinicContext : DbContext
{
    public ClinicContext(DbContextOptions<ClinicContext> options)
        : base(options)
    {
    }
    public virtual DbSet<ClinicaDiagnostico> ClinicaDiagnosticos { get; set; }

    public virtual DbSet<ClinicaDoctore> ClinicaDoctores { get; set; }

    public virtual DbSet<ClinicaEspecialidad> ClinicaEspecialidads { get; set; }

    public virtual DbSet<ClinicaHistorica> ClinicaHistoricas { get; set; }

    public virtual DbSet<LabColaborador> LabColaboradors { get; set; }

    public virtual DbSet<MStatus> MStatuses { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=HILDAS-LAPTOP;Database=Clinic; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClinicaDiagnostico>(entity =>
        {
            entity.HasKey(e => e.Iddiagnostico);

            entity.Property(e => e.Iddiagnostico).HasColumnName("IDdiagnostico");
            entity.Property(e => e.Diagnosticos).HasColumnType("text");
            entity.Property(e => e.ExamenLab).HasColumnType("text");
            entity.Property(e => e.FechaDiagnostico).HasColumnType("datetime");
            entity.Property(e => e.Iddoctor).HasColumnName("IDdoctor");
            entity.Property(e => e.Identificacion).HasMaxLength(20);
            entity.Property(e => e.IdhistoricaClinica).HasColumnName("IDHistoricaClinica");
            entity.Property(e => e.Observaciones).HasColumnType("text");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.ClinicaDiagnosticos)
                .HasForeignKey(d => d.Estado)
                .HasConstraintName("FK_ClinicaDiagnosticos_mStatus");
        });

        modelBuilder.Entity<ClinicaDoctore>(entity =>
        {
            entity.HasKey(e => e.Iddoctor);

            entity.Property(e => e.Iddoctor).HasColumnName("IDdoctor");
            entity.Property(e => e.Identificacion).HasMaxLength(20);
            entity.Property(e => e.Nombres).HasMaxLength(50);
        });

        modelBuilder.Entity<ClinicaEspecialidad>(entity =>
        {
            entity.HasKey(e => e.Idespecialidad);

            entity.ToTable("ClinicaEspecialidad");

            entity.Property(e => e.Idespecialidad)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDespecialidad");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdespecialidadNavigation).WithOne(p => p.ClinicaEspecialidad)
                .HasForeignKey<ClinicaEspecialidad>(d => d.Idespecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClinicaEspecialidad_ClinicaEspecialidad");
        });

        modelBuilder.Entity<ClinicaHistorica>(entity =>
        {
            entity.HasKey(e => e.IdhistoriaClinica);

            entity.ToTable("ClinicaHistorica");

            entity.Property(e => e.IdhistoriaClinica).HasColumnName("IDhistoriaClinica");
            entity.Property(e => e.FechaApertura).HasColumnType("datetime");
            entity.Property(e => e.Identificacion).HasMaxLength(20);
            entity.Property(e => e.Idpaciente).HasColumnName("IDpaciente");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.ClinicaHistoricas)
                .HasForeignKey(d => d.Estado)
                .HasConstraintName("FK_ClinicaHistorica_mStatus");
        });

        modelBuilder.Entity<LabColaborador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LabCOLAB__3214EC070A7F7736");

            entity.ToTable("LabCOLABORADOR");

            entity.Property(e => e.Colaborador)
                .HasMaxLength(15)
                .HasColumnName("COLABORADOR");
            entity.Property(e => e.Departamento)
                .HasMaxLength(4)
                .HasColumnName("DEPARTAMENTO");
            entity.Property(e => e.Estatus).HasColumnName("ESTATUS");
            entity.Property(e => e.NombreColaborador)
                .HasMaxLength(80)
                .HasColumnName("NOMBRECOLABORADOR");
            entity.Property(e => e.Registrado)
                .HasMaxLength(50)
                .HasColumnName("REGISTRADO");
        });

        modelBuilder.Entity<MStatus>(entity =>
        {
            entity.HasKey(e => e.Idstatus);

            entity.ToTable("mStatus");

            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("PACIENTES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellidomaterno)
                .HasMaxLength(50)
                .HasColumnName("APELLIDOMATERNO");
            entity.Property(e => e.Apellidopaterno)
                .HasMaxLength(50)
                .HasColumnName("APELLIDOPATERNO");
            entity.Property(e => e.Ars)
                .HasMaxLength(3)
                .HasColumnName("ARS");
            entity.Property(e => e.Clasifica)
                .HasMaxLength(11)
                .HasColumnName("CLASIFICA");
            entity.Property(e => e.Correo)
                .HasMaxLength(90)
                .HasColumnName("CORREO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Domicilio).HasColumnName("DOMICILIO");
            entity.Property(e => e.Dparte)
                .HasMaxLength(11)
                .HasColumnName("DPARTE");
            entity.Property(e => e.Edad)
                .HasMaxLength(3)
                .HasColumnName("EDAD");
            entity.Property(e => e.Estado)
                .HasMaxLength(25)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fechanacimiento)
                .HasMaxLength(10)
                .HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Idcuenta)
                .HasMaxLength(11)
                .HasColumnName("IDCUENTA");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(11)
                .HasColumnName("IDENTIFICACION");
            entity.Property(e => e.Lugar).HasColumnName("LUGAR");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(50)
                .HasColumnName("NACIONALIDAD");
            entity.Property(e => e.Nic)
                .HasMaxLength(30)
                .HasColumnName("NIC");
            entity.Property(e => e.Nivel)
                .HasMaxLength(50)
                .HasColumnName("NIVEL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(90)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Numsfs)
                .HasMaxLength(11)
                .HasColumnName("NUMSFS");
            entity.Property(e => e.Peso)
                .HasMaxLength(50)
                .HasColumnName("PESO");
            entity.Property(e => e.Posicion)
                .HasMaxLength(90)
                .HasColumnName("POSICION");
            entity.Property(e => e.Registrado)
                .HasMaxLength(50)
                .HasColumnName("REGISTRADO");
            entity.Property(e => e.Sexo)
                .HasMaxLength(20)
                .HasColumnName("SEXO");
            entity.Property(e => e.Siglas)
                .HasMaxLength(25)
                .HasColumnName("SIGLAS");
            entity.Property(e => e.Talla)
                .HasMaxLength(50)
                .HasColumnName("TALLA");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(11)
                .HasColumnName("TELEFONO1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(11)
                .HasColumnName("TELEFONO2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(150);

            entity.HasOne(d => d.IdEstatusNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERS_mStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
