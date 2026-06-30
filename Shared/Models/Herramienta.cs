using System;
using System.Collections.Generic;

namespace AdminHerramientas.Shared.Models;

public partial class Herramienta
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<HerramientasDetalle> HerramientasDetalles { get; } = new List<HerramientasDetalle>();
}
