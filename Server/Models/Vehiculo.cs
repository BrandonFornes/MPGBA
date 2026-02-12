using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Vehiculo
{
    public int VehId { get; set; }

    public string VehNoSerie { get; set; } = null!;

    public int VehFkIdModelo { get; set; }

    public int VehAnio { get; set; }

    public DateTime VehFechaLlegada { get; set; }

    public DateTime? VehUltimoMantenimiento { get; set; }

    public int VehFkIdConcesionarioActual { get; set; }

    public virtual ICollection<HistorialMantenimiento> HistorialMantenimientos { get; } = new List<HistorialMantenimiento>();

    public virtual Concesionario VehFkIdConcesionarioActualNavigation { get; set; } = null!;

    public virtual Modelo VehFkIdModeloNavigation { get; set; } = null!;
}
