using System;
using System.Collections.Generic;
using AdminHerramientas.Server;
using Microsoft.EntityFrameworkCore;
using AdminHerramientas.Shared.Models;
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

    public virtual DbSet<HerramientasDetalle> HerramientasDetalles { get; set; }

    public virtual DbSet<HistorialMantenimiento> HistorialMantenimientos { get; set; }

    public virtual DbSet<Operario> Operarios { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<PrestamosDetalle> PrestamosDetalles { get; set; }

    public virtual DbSet<RegistrosLavado> RegistrosLavados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Intervalo> Intervalos { get; set; }

    public virtual DbSet<Nip> Nips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=localhost;Database=ALP;Trusted_Connection=True;TrustServerCertificate=True");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concesionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__concesio__3214EC07B3684BDA");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(155).IsUnicode(false);
            entity.Property(e => e.Localidad).HasMaxLength(55).IsUnicode(false);
            entity.Property(e => e.FkIdEmpresa).HasColumnName("fk_IdEmpresa");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Empresa)
                .WithMany(p => p.Concesionarios)
                .HasForeignKey(d => d.FkIdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Concesionarios_Empresas");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresas__3214EC07727B5B99");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RazonSocial).HasMaxLength(155).IsUnicode(false);
            entity.Property(e => e.RFC).HasMaxLength(13).IsUnicode(false).HasColumnName("RFC");
            entity.Property(e => e.fechaModificacion).HasColumnType("datetime").HasColumnName("fechaModificacion");
            entity.Property(e => e.usuarioModifico).HasColumnName("usuarioModifico");
        });

        modelBuilder.Entity<Herramienta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Herramie__3214EC0786FC08B3");

            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HerramientasDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Herrrami__3214EC07BA3C80B3");

            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Disponible).HasDefaultValueSql("((1))");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Etiqueta)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaCompra).HasColumnType("date");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FkIdHerramienta).HasColumnName("Fk_IdHerramienta");

            entity.HasOne(d => d.FkIdHerramientaNavigation).WithMany(p => p.HerramientasDetalles)
                .HasForeignKey(d => d.FkIdHerramienta)
                .HasConstraintName("FK_HerramientasDetalles_Herramientas");
        });

        modelBuilder.Entity<HistorialMantenimiento>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.fechaMantenimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FkBastidor).HasMaxLength(30).IsUnicode(false).HasColumnName("fk_bastidor");

            entity.HasOne(d => d.Concesionario)
                .WithMany()
                .HasForeignKey(d => d.IdConcesionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Concesionarios");

            entity.HasOne(d => d.Vehiculo)
                .WithMany() 
                .HasPrincipalKey(p => p.Bastidor) 
                .HasForeignKey(d => d.FkBastidor)
                .HasConstraintName("FK_Historial_Vehiculo_Bastidor");
        });

        modelBuilder.Entity<Nip>(entity =>
        {
            entity.ToTable("Nips");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Fk_codigoOperario)
                .HasColumnName("fk_codigoOperario")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            entity.Property(e => e.ValorNip)
                .HasColumnName("nip")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            entity.Property(e => e.FechaModificacion)
                .HasColumnName("FechaModificacion")
                .HasColumnType("datetime")
                .IsRequired();

            entity.Property(e => e.UsuarioModifico)
                .HasColumnName("UsuarioModifico")
                .IsRequired();

            entity.Property(e => e.Activo)
                .HasColumnName("Activo")
                .IsRequired();
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
            entity.HasKey(e => e.IdPrestamos).HasName("PK__Prestamo__C9249103DF55833E");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CodigoServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigoServicio");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaSolicitud)
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
                .HasConstraintName("FK_Prestamos_Operarios");
        });

        modelBuilder.Entity<PrestamosDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prestamo__3214EC07C59C3ECB");

            entity.ToTable("Prestamos_Detalle");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("activo");
            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("comentario");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("date")
                .HasColumnName("fechaEntrega");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FkIdHerramienta).HasColumnName("fk_IdHerramienta");
            entity.Property(e => e.FkIdPrestamo).HasColumnName("fk_IdPrestamo");

            entity.HasOne(d => d.FkIdPrestamoNavigation).WithMany(p => p.PrestamosDetalles)
                .HasForeignKey(d => d.FkIdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrestamosDetalle_Prestamos");
        });

        modelBuilder.Entity<RegistrosLavado>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Registros_lavados");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.FkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fk_codigoOperario");

            entity.Property(e => e.FkIdTarea).HasColumnName("fk_IdTarea");

            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");

            entity.Property(e => e.ComisionRegistro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("comisionRegistro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FechaModificacion");

            entity.Property(e => e.UsuarioModifico).HasColumnName("UsuarioModifico");

            entity.Property(e => e.Activo)
                .HasColumnName("Activo")
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.OperarioNavigation).WithMany(p => p.RegistrosLavados)
                .HasForeignKey(d => d.FkCodigoOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lavados_Operarios");

            entity.HasOne(d => d.TareaNavigation).WithMany(p => p.RegistrosLavados)
                .HasForeignKey(d => d.FkIdTarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lavados_Tareas");

            entity.Property(e => e.FkBastidor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fk_bastidor");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id); 

            entity.ToTable("Tareas");

            entity.Property(e => e.Id).HasColumnName("Id");
            
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreTarea"); 

            entity.Property(e => e.ComisionTarea)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("comisionTarea");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FechaModificacion");

            entity.Property(e => e.UsuarioModifico)
                .HasColumnName("UsuarioModifico");

            entity.Property(e => e.Activo)
                .HasColumnName("Activo")
                .HasDefaultValueSql("((1))");
        });


        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Idv).HasName("PK__Vehiculo__C4971C38CDABDCC6");

            entity.Property(e => e.Idv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDV");
            entity.Property(e => e.AnioVehi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ANIO_VEHI");
            entity.Property(e => e.Bastidor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("BASTIDOR");
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COLOR");
            entity.Property(e => e.DesColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_COLOR");
            entity.Property(e => e.DesFamilia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_FAMILIA");
            entity.Property(e => e.DesMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_MARCA");
            entity.Property(e => e.DesModelo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DES_MODELO");
            entity.Property(e => e.Familia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FAMILIA");
            entity.Property(e => e.Fechafin)
                .HasColumnType("date")
                .HasColumnName("FECHAFIN");
            entity.Property(e => e.Km)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("KM");
            entity.Property(e => e.Marca)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MARCA");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODELO");
        });

        modelBuilder.Entity<Intervalo>(entity =>
        {
            entity.HasKey(e => e.Id); 

            entity.ToTable("Intervalos"); 

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.marcavehiculo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("marcavehiculo");

            entity.Property(e => e.Intervalo_dias)
                .HasColumnName("intervalo_dias");

            entity.Property(e => e.Activo)
                .HasColumnName("activo")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.UsuarioModifico)
                .HasColumnName("usuario_modifico");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion")
                .HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
