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

    public virtual DbSet<Herramienta> Herramienta { get; set; }

    public virtual DbSet<HistorialMantenimiento> HistorialMantenimientos { get; set; }

    public virtual DbSet<Nip> Nips { get; set; }

    public virtual DbSet<Operario> Operarios { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<PrestamosDetalle> PrestamosDetalles { get; set; }

    public virtual DbSet<RegistrosLavado> RegistrosLavados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BRANDON\\SQLEXPRESS; Database=ALP; Trusted_Connection=True; TrustServerCertificate=True ");

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
            entity.HasKey(e => e.HrmId).HasName("PK__Herramie__0D9CCBC7E59670BD");

            entity.Property(e => e.HrmId).HasColumnName("hrm_Id");
            entity.Property(e => e.HrmDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hrm_descripcion");
            entity.Property(e => e.HrmDisponible)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("hrm_disponible");
            entity.Property(e => e.HrmEstado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("hrm_estado");
            entity.Property(e => e.HrmEtiqueta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hrm_etiqueta");
            entity.Property(e => e.HrmFechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("hrm_fechaCompra");
            entity.Property(e => e.HrmFechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("hrm_FechaModificacion");
            entity.Property(e => e.HrmMarcaHerramienta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hrm_marcaHerramienta");
            entity.Property(e => e.HrmNombreHerramienta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hrm_nombreHerramienta");
            entity.Property(e => e.HrmUsuarioModifico).HasColumnName("hrm_UsuarioModifico");
        });

        modelBuilder.Entity<HistorialMantenimiento>(entity =>
        {
            entity.HasKey(e => e.HmnId).HasName("PK__historia__B215155C556324F4");

            entity.ToTable("historial_mantenimientos");

            entity.Property(e => e.HmnId).HasColumnName("hmn_Id");
            entity.Property(e => e.HmnFechaMantenimiento)
                .HasColumnType("datetime")
                .HasColumnName("hmn_fechaMantenimiento");
            entity.Property(e => e.HmnFechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("hmn_FechaModificacion");
            entity.Property(e => e.HmnFkIdConcesionario).HasColumnName("hmn_fk_IdConcesionario");
            entity.Property(e => e.HmnFkIdVehiculo).HasColumnName("hmn_fk_IdVehiculo");
            entity.Property(e => e.HmnUsuarioModifico).HasColumnName("hmn_UsuarioModifico");

            entity.HasOne(d => d.HmnFkIdConcesionarioNavigation).WithMany(p => p.HistorialMantenimientos)
                .HasForeignKey(d => d.HmnFkIdConcesionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Concesionarios");
        });

        modelBuilder.Entity<Nip>(entity =>
        {
            entity.HasKey(e => e.NipId).HasName("PK__Nips__2CD53B6476A2AA77");

            entity.Property(e => e.NipId).HasColumnName("nip_Id");
            entity.Property(e => e.NipFechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("nip_FechaModificacion");
            entity.Property(e => e.NipFkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nip_fk_codigoOperario");
            entity.Property(e => e.NipNip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nip_nip");
            entity.Property(e => e.NipUsuarioModifico).HasColumnName("nip_UsuarioModifico");

            entity.HasOne(d => d.NipFkCodigoOperarioNavigation).WithMany(p => p.Nips)
                .HasForeignKey(d => d.NipFkCodigoOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nips_Operarios");
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
            entity.HasKey(e => e.PrsIdPrestamos).HasName("PK__Prestamo__76CEF6F8F0870508");

            entity.Property(e => e.PrsIdPrestamos).HasColumnName("prs_IdPrestamos");
            entity.Property(e => e.PrsCodigoServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prs_codigoServicio");
            entity.Property(e => e.PrsComentario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("prs_comentario");
            entity.Property(e => e.PrsFechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("prs_fechaEntrega");
            entity.Property(e => e.PrsFechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("prs_FechaModificacion");
            entity.Property(e => e.PrsFechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("prs_fechaSolicitud");
            entity.Property(e => e.PrsFkCodigoEncargado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("prs_fk_codigoEncargado");
            entity.Property(e => e.PrsFkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("prs_fk_codigoOperario");
            entity.Property(e => e.PrsFkIdHerramienta).HasColumnName("prs_fk_IdHerramienta");
            entity.Property(e => e.PrsMotivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("prs_motivo");
            entity.Property(e => e.PrsUsuarioModifico).HasColumnName("prs_UsuarioModifico");

            entity.HasOne(d => d.PrsFkCodigoEncargadoNavigation).WithMany(p => p.PrestamoPrsFkCodigoEncargadoNavigations)
                .HasForeignKey(d => d.PrsFkCodigoEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Encargado");

            entity.HasOne(d => d.PrsFkCodigoOperarioNavigation).WithMany(p => p.PrestamoPrsFkCodigoOperarioNavigations)
                .HasForeignKey(d => d.PrsFkCodigoOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Operario");

            entity.HasOne(d => d.PrsFkIdHerramientaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.PrsFkIdHerramienta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Herramienta");
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

            entity.HasOne(d => d.FkIdHerramientaNavigation).WithMany(p => p.PrestamosDetalles)
                .HasForeignKey(d => d.FkIdHerramienta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrestamosDetalle_Herramienta");

            entity.HasOne(d => d.FkIdPrestamoNavigation).WithMany(p => p.PrestamosDetalles)
                .HasForeignKey(d => d.FkIdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrestamosDetalle_Prestamos");
        });

        modelBuilder.Entity<RegistrosLavado>(entity =>
        {
            entity.HasKey(e => e.RlvId).HasName("PK__Registro__65C8A5E6F05731B1");

            entity.ToTable("Registros_lavados");

            entity.Property(e => e.RlvId).HasColumnName("rlv_Id");
            entity.Property(e => e.RlvComisionRegistro)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("rlv_comisionRegistro");
            entity.Property(e => e.RlvFecha)
                .HasColumnType("datetime")
                .HasColumnName("rlv_fecha");
            entity.Property(e => e.RlvFechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("rlv_FechaModificacion");
            entity.Property(e => e.RlvFkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rlv_fk_codigoOperario");
            entity.Property(e => e.RlvFkIdTarea).HasColumnName("rlv_fk_IdTarea");
            entity.Property(e => e.RlvUsuarioModifico).HasColumnName("rlv_UsuarioModifico");

            entity.HasOne(d => d.RlvFkCodigoOperarioNavigation).WithMany(p => p.RegistrosLavados)
                .HasForeignKey(d => d.RlvFkCodigoOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lavados_Operarios");

            entity.HasOne(d => d.RlvFkIdTareaNavigation).WithMany(p => p.RegistrosLavados)
                .HasForeignKey(d => d.RlvFkIdTarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lavados_Tareas");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TrsId).HasName("PK__Tareas__48C1EC9BDCFAC729");

            entity.Property(e => e.TrsId).HasColumnName("trs_Id");
            entity.Property(e => e.TrsComisionTarea)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("trs_comisionTarea");
            entity.Property(e => e.TrsFechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("trs_FechaModificacion");
            entity.Property(e => e.TrsNombreTarea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("trs_nombreTarea");
            entity.Property(e => e.TrsUsuarioModifico).HasColumnName("trs_UsuarioModifico");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
