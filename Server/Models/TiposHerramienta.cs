using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class TiposHerramienta
{
    public int ThrId { get; set; }

    public string ThrTipo { get; set; } = null!;

    public bool ThrAplicaGarantia { get; set; }

    public DateTime? ThrFechaVencimientoGarantía { get; set; }

    public virtual ICollection<Herramienta> Herramienta { get; } = new List<Herramienta>();
}
