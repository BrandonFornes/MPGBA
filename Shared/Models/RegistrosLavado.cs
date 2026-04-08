using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHerramientas.Shared.Models;

[Table("Registros_lavados")] // Forzamos el nombre exacto de la tabla
public partial class RegistrosLavado
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    [Column("fk_codigoOperario")]
    public string FkCodigoOperario { get; set; } = null!;

    [Column("fk_IdTarea")]
    public int FkIdTarea { get; set; }

    public DateTime Fecha { get; set; }

    [Column("comisionRegistro")]
    public decimal ComisionRegistro { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public bool Activo { get; set; }

    [Column("fk_bastidor")]
    public string? FkBastidor { get; set; }

    // Propiedades de Navegación (Esto es lo que hace magia en EF)
    [ForeignKey("FkCodigoOperario")]
    public virtual Operario? OperarioNavigation { get; set; }

    [ForeignKey("FkIdTarea")]
    public virtual Tarea? TareaNavigation { get; set; }

    [ForeignKey("FkBastidor")]
    public virtual Vehiculo? VehiculoNavigation { get; set; }
}