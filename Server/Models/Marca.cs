using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Marca
{
    public int MrcId { get; set; }

    public string MrcNombreMarca { get; set; } = null!;

    public int? MrcIntervalo { get; set; }

    public virtual ICollection<Modelo> Modelos { get; } = new List<Modelo>();
}
