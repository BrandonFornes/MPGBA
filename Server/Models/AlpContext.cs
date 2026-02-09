using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Models;

public partial class AlpContext : DbContext
{
    public AlpContext()
    {
    }

    public AlpContext(DbContextOptions<AlpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Concesionario> Concesionarios { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Herramienta> Herramientas { get; set; }

    public virtual DbSet<HistorialMantenimiento> HistorialMantenimientos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Nip> Nips { get; set; }

    public virtual DbSet<Operario> Operarios { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<RegistrosLavado> RegistrosLavados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=ALP;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concesionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__concesio__3214EC07B3684BDA");

            entity.ToTable("concesionarios");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FkIdEmpresa).HasColumnName("fk_IdEmpresa");
            entity.Property(e => e.Localidad)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(155)
                .IsUnicode(false);

            entity.HasOne(d => d.FkIdEmpresaNavigation).WithMany(p => p.Concesionarios)
                .HasForeignKey(d => d.FkIdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Concesionarios_Empresas");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresas__3214EC07727B5B99");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(155)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RFC");
            entity.Property(e => e.UsuarioModifico).HasColumnName("usuarioModifico");
        });

        modelBuilder.Entity<Herramienta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Herramie__3214EC07914FFC0B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponible)
                .HasDefaultValueSql("((1))")
                .HasColumnName("disponible");
            entity.Property(e => e.Etiqueta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("etiqueta");
            entity.Property(e => e.NombreHerramienta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreHerramienta");
        });

        modelBuilder.Entity<HistorialMantenimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__historia__3214EC076F1CDB3D");

            entity.ToTable("historial_mantenimientos");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaMantenimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaMantenimiento");
            entity.Property(e => e.FkIdConcesionario).HasColumnName("fk_IdConcesionario");
            entity.Property(e => e.FkIdVehiculo).HasColumnName("fk_IdVehiculo");

            entity.HasOne(d => d.FkIdConcesionarioNavigation).WithMany(p => p.HistorialMantenimientos)
                .HasForeignKey(d => d.FkIdConcesionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Concesionarios");

            entity.HasOne(d => d.FkIdVehiculoNavigation).WithMany(p => p.HistorialMantenimientos)
                .HasForeignKey(d => d.FkIdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Vehiculos");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Marcas__3214EC07C6608600");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Intervalo).HasColumnName("intervalo");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreMarca");
        });

        modelBuilder.Entity<Nip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nips__3214EC074217B4DF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fk_codigoOperario");
            entity.Property(e => e.Nip1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nip");

            entity.HasOne(d => d.FkCodigoOperarioNavigation).WithMany(p => p.Nips)
                .HasForeignKey(d => d.FkCodigoOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nips_Operarios");
        });

        modelBuilder.Entity<Operario>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Operario__06370DAD992741FD");

            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Seccion)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModifico).HasColumnName("usuarioModifico");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamos).HasName("PK__Prestamo__C9249103DB6618D2");

            entity.Property(e => e.IdPrestamos).ValueGeneratedNever();
            entity.Property(e => e.CodigoServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigoServicio");
            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("comentario");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("fechaEntrega");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaSolicitud");
            entity.Property(e => e.FkCodigoEncargado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fk_codigoEncargado");
            entity.Property(e => e.FkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fk_codigoOperario");
            entity.Property(e => e.FkIdHerramienta).HasColumnName("fk_IdHerramienta");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo");

            entity.HasOne(d => d.FkCodigoEncargadoNavigation).WithMany(p => p.PrestamoFkCodigoEncargadoNavigations)
                .HasForeignKey(d => d.FkCodigoEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Encargado");

            entity.HasOne(d => d.FkCodigoOperarioNavigation).WithMany(p => p.PrestamoFkCodigoOperarioNavigations)
                .HasForeignKey(d => d.FkCodigoOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Operario");

            entity.HasOne(d => d.FkIdHerramientaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.FkIdHerramienta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Herramienta");
        });

        modelBuilder.Entity<RegistrosLavado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3214EC078781557E");

            entity.ToTable("Registros_lavados");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ComisionRegistro)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("comisionRegistro");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fk_codigoOperario");
            entity.Property(e => e.FkIdTarea).HasColumnName("fk_IdTarea");

            entity.HasOne(d => d.FkCodigoOperarioNavigation).WithMany(p => p.RegistrosLavados)
                .HasForeignKey(d => d.FkCodigoOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lavados_Operarios");

            entity.HasOne(d => d.FkIdTareaNavigation).WithMany(p => p.RegistrosLavados)
                .HasForeignKey(d => d.FkIdTarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lavados_Tareas");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tareas__3214EC077CED1DEC");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ComisionTarea)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("comisionTarea");
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreTarea");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3214EC0797F269F6");

            entity.HasIndex(e => e.NoSerie, "UQ__Vehiculo__72CDE8D88D024D7D").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaLlegada)
                .HasColumnType("date")
                .HasColumnName("fechaLlegada");
            entity.Property(e => e.FkIdConcesionarioActual).HasColumnName("fk_IdConcesionarioActual");
            entity.Property(e => e.FkIdMarca).HasColumnName("fk_IdMarca");
            entity.Property(e => e.NoSerie)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("noSerie");
            entity.Property(e => e.UltimoMantenimiento)
                .HasColumnType("date")
                .HasColumnName("ultimoMantenimiento");

            entity.HasOne(d => d.FkIdConcesionarioActualNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.FkIdConcesionarioActual)
                .HasConstraintName("FK_Vehiculos_Concesionarios");

            entity.HasOne(d => d.FkIdMarcaNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.FkIdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehiculos_Marcas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
