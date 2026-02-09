using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Tarea
{
    public int Id { get; set; }

    public string NombreTarea { get; set; } = null!;

    public decimal? ComisionTarea { get; set; }

    public virtual ICollection<RegistrosLavado> RegistrosLavados { get; } = new List<RegistrosLavado>();
}
