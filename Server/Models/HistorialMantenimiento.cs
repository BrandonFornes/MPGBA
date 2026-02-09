using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class HistorialMantenimiento
{
    public int Id { get; set; }

    public int FkIdVehiculo { get; set; }

    public DateTime FechaMantenimiento { get; set; }

    public int FkIdConcesionario { get; set; }

    public virtual Concesionario FkIdConcesionarioNavigation { get; set; } = null!;

    public virtual Vehiculo FkIdVehiculoNavigation { get; set; } = null!;
}
