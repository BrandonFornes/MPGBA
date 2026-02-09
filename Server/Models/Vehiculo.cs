using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string NoSerie { get; set; } = null!;

    public int FkIdMarca { get; set; }

    public DateTime? FechaLlegada { get; set; }

    public DateTime? UltimoMantenimiento { get; set; }

    public int? FkIdConcesionarioActual { get; set; }

    public virtual Concesionario? FkIdConcesionarioActualNavigation { get; set; }

    public virtual Marca FkIdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<HistorialMantenimiento> HistorialMantenimientos { get; } = new List<HistorialMantenimiento>();
}
