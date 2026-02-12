using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Herramienta
{
    public int HrmId { get; set; }

    public string? HrmEtiqueta { get; set; }

    public string HrmNombreHerramienta { get; set; } = null!;

    public string? HrmDescripcion { get; set; }

    public bool? HrmDisponible { get; set; }

    public string? HrmEstado { get; set; }

    public DateTime? HrmFechaCompra { get; set; }

    public string HrmMarcaHerramienta { get; set; } = null!;

    public int HrmFkTipo { get; set; }

    public virtual TiposHerramienta HrmFkTipoNavigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
