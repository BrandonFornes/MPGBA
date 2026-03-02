using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Prestamo
{
    public int PrsIdPrestamos { get; set; }

    public string PrsFkCodigoOperario { get; set; } = null!;

    public int PrsFkIdHerramienta { get; set; }

    public string PrsFkCodigoEncargado { get; set; } = null!;

    public string PrsMotivo { get; set; } = null!;

    public string PrsCodigoServicio { get; set; } = null!;

    public DateTime PrsFechaSolicitud { get; set; }

    public DateTime? PrsFechaEntrega { get; set; }

    public string? PrsComentario { get; set; }

    public DateTime PrsFechaModificacion { get; set; }

    public int PrsUsuarioModifico { get; set; }

    public virtual ICollection<PrestamosDetalle> PrestamosDetalles { get; } = new List<PrestamosDetalle>();

    public virtual Operario PrsFkCodigoEncargadoNavigation { get; set; } = null!;

    public virtual Operario PrsFkCodigoOperarioNavigation { get; set; } = null!;

    public virtual Herramienta PrsFkIdHerramientaNavigation { get; set; } = null!;
}
