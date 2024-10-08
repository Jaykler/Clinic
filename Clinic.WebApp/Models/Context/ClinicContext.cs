
using Microsoft.EntityFrameworkCore;

namespace Clinic.WebApp.Models.Context;

public partial class ClinicContext : DbContext
{
    public ClinicContext(DbContextOptions<ClinicContext> options)
        : base(options)
    {
    }
    public virtual DbSet<LabColaborador> LabCOLABORADOR {  get; set; }
    public virtual DbSet<MStatus> MStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=HILDAS-LAPTOP;Database=Clinic; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MStatus>(entity =>
        {
            entity.HasKey(e => e.Idstatus);

            entity.ToTable("mStatus");

            entity.Property(e => e.Status).HasMaxLength(50);
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
        modelBuilder.Entity<LabColaborador>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("LabCOLABORADOR");


        });

    }

   
}
