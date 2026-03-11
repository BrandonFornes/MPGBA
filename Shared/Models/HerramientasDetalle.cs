using System;
using System.Collections.Generic;

namespace AdminHerramientas.Shared.Models;

public partial class HerramientasDetalle
{
    public int Id { get; set; }

    public int? FkIdHerramienta { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCompra { get; set; }

    public bool? Disponible { get; set; }

    public bool? Activo { get; set; }

    public string? Estado { get; set; }

    public string? Etiqueta { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public virtual Herramienta? FkIdHerramientaNavigation { get; set; }
}
