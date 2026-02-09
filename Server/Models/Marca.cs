using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string NombreMarca { get; set; } = null!;

    public int? Intervalo { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
