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

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Nip> Nips { get; set; }

    public virtual DbSet<Operario> Operarios { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<RegistrosLavado> RegistrosLavados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<TiposHerramienta> TiposHerramientas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BRANDON\\SQLEXPRESS; Database=ALP; Trusted_Connection=True; TrustServerCertificate=True");

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
            entity.HasKey(e => e.HrmId).HasName("PK__Herramie__0D9CCBC7C6287BA4");

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
            entity.Property(e => e.HrmFkTipo).HasColumnName("hrm_fk_tipo");
            entity.Property(e => e.HrmMarcaHerramienta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hrm_marcaHerramienta");
            entity.Property(e => e.HrmNombreHerramienta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hrm_nombreHerramienta");

            entity.HasOne(d => d.HrmFkTipoNavigation).WithMany(p => p.Herramienta)
                .HasForeignKey(d => d.HrmFkTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Herramientas_Tipos");
        });

        modelBuilder.Entity<HistorialMantenimiento>(entity =>
        {
            entity.HasKey(e => e.HmnId).HasName("PK__historia__B215155C556324F4");

            entity.ToTable("historial_mantenimientos");

            entity.Property(e => e.HmnId).HasColumnName("hmn_Id");
            entity.Property(e => e.HmnFechaMantenimiento)
                .HasColumnType("datetime")
                .HasColumnName("hmn_fechaMantenimiento");
            entity.Property(e => e.HmnFkIdConcesionario).HasColumnName("hmn_fk_IdConcesionario");
            entity.Property(e => e.HmnFkIdVehiculo).HasColumnName("hmn_fk_IdVehiculo");

            entity.HasOne(d => d.HmnFkIdConcesionarioNavigation).WithMany(p => p.HistorialMantenimientos)
                .HasForeignKey(d => d.HmnFkIdConcesionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Concesionarios");

            entity.HasOne(d => d.HmnFkIdVehiculoNavigation).WithMany(p => p.HistorialMantenimientos)
                .HasForeignKey(d => d.HmnFkIdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Vehiculos");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MrcId).HasName("PK__Marcas__ECAB8D349FC16C5F");

            entity.Property(e => e.MrcId).HasColumnName("mrc_Id");
            entity.Property(e => e.MrcIntervalo).HasColumnName("mrc_intervalo");
            entity.Property(e => e.MrcNombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mrc_nombreMarca");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.MdlId).HasName("PK__Modelos__9B3C7947B077CA40");

            entity.Property(e => e.MdlId).HasColumnName("mdl_id");
            entity.Property(e => e.MdlFkIdMarca).HasColumnName("mdl_fk_IdMarca");
            entity.Property(e => e.MdlNombreModelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mdl_nombreModelo");

            entity.HasOne(d => d.MdlFkIdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.MdlFkIdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modelos_Marcas");
        });

        modelBuilder.Entity<Nip>(entity =>
        {
            entity.HasKey(e => e.NipId).HasName("PK__Nips__2CD53B6476A2AA77");

            entity.Property(e => e.NipId).HasColumnName("nip_Id");
            entity.Property(e => e.NipFkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nip_fk_codigoOperario");
            entity.Property(e => e.NipNip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nip_nip");

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
            entity.Property(e => e.RlvFkCodigoOperario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rlv_fk_codigoOperario");
            entity.Property(e => e.RlvFkIdTarea).HasColumnName("rlv_fk_IdTarea");

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
            entity.Property(e => e.TrsNombreTarea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("trs_nombreTarea");
        });

        modelBuilder.Entity<TiposHerramienta>(entity =>
        {
            entity.HasKey(e => e.ThrId).HasName("PK__Tipos_He__CFB3E579C300B450");

            entity.ToTable("Tipos_Herramientas");

            entity.Property(e => e.ThrId).HasColumnName("thr_Id");
            entity.Property(e => e.ThrAplicaGarantia).HasColumnName("thr_aplica_garantia");
            entity.Property(e => e.ThrFechaVencimientoGarantía)
                .HasColumnType("datetime")
                .HasColumnName("thr_fechaVencimientoGarantía");
            entity.Property(e => e.ThrTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("thr_tipo");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehId).HasName("PK__Vehiculo__9D12CF21B21892D5");

            entity.HasIndex(e => e.VehNoSerie, "UQ__Vehiculo__BADAA1109547DACF").IsUnique();

            entity.Property(e => e.VehId).HasColumnName("veh_Id");
            entity.Property(e => e.VehAnio).HasColumnName("veh_anio");
            entity.Property(e => e.VehFechaLlegada)
                .HasColumnType("date")
                .HasColumnName("veh_fechaLlegada");
            entity.Property(e => e.VehFkIdConcesionarioActual).HasColumnName("veh_fk_IdConcesionarioActual");
            entity.Property(e => e.VehFkIdModelo).HasColumnName("veh_fk_IdModelo");
            entity.Property(e => e.VehNoSerie)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("veh_noSerie");
            entity.Property(e => e.VehUltimoMantenimiento)
                .HasColumnType("date")
                .HasColumnName("veh_ultimoMantenimiento");

            entity.HasOne(d => d.VehFkIdConcesionarioActualNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.VehFkIdConcesionarioActual)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehiculos_Concesionarios");

            entity.HasOne(d => d.VehFkIdModeloNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.VehFkIdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vehiculos_modelos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
