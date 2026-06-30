using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHerramientas.Shared.Models;

public partial class Tarea
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column("nombreTarea")] 
    public string NombreTarea { get; set; } = null!;

    [Column("comisionTarea")]
    public decimal ComisionTarea { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<RegistrosLavado> RegistrosLavados { get; set; } = new List<RegistrosLavado>();
}