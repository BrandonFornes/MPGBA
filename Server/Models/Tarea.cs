using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Tarea
{
    public int TrsId { get; set; }

    public string TrsNombreTarea { get; set; } = null!;

    public decimal TrsComisionTarea { get; set; }

    public virtual ICollection<RegistrosLavado> RegistrosLavados { get; } = new List<RegistrosLavado>();
}
