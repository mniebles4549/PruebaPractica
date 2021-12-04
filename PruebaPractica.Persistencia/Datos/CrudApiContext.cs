using Microsoft.EntityFrameworkCore;
using PruebaPractica.Core;

#nullable disable

namespace PruebaPractica.Persistencia.Datos
{
    public partial class CrudApiContext : DbContext
    {
        public CrudApiContext()
        {
        }

        public CrudApiContext(DbContextOptions<CrudApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Estadocivil> Estadocivils { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("DOCUMENTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("EMPLEADO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHANACIMIENTO");

                entity.Property(e => e.Idestadocivil).HasColumnName("IDESTADOCIVIL");

                entity.Property(e => e.Idtipodocumento).HasColumnName("IDTIPODOCUMENTO");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.Valoraganar)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VALORAGANAR");

                entity.HasOne(d => d.IdestadocivilNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Idestadocivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADO_ESTADOCIVIL");

                entity.HasOne(d => d.IdtipodocumentoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Idtipodocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADO_DOCUMENTO");
            });

            modelBuilder.Entity<Estadocivil>(entity =>
            {
                entity.ToTable("ESTADOCIVIL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
