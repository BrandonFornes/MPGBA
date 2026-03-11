using System;
using System.Collections.Generic;

namespace AdminHerramientas.Shared.Models;

public partial class HistorialMantenimiento
{
    public int HmnId { get; set; }

    public int HmnFkIdVehiculo { get; set; }

    public DateTime HmnFechaMantenimiento { get; set; }

    public int HmnFkIdConcesionario { get; set; }

    public DateTime HmnFechaModificacion { get; set; }

    public int HmnUsuarioModifico { get; set; }

    public virtual Concesionario HmnFkIdConcesionarioNavigation { get; set; } = null!;
}
