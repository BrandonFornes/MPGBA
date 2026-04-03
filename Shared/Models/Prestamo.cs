using System;
using System.Collections.Generic;

namespace AdminHerramientas.Shared.Models;

public partial class Prestamo
{
    public int IdPrestamos { get; set; }

    public string FkCodigoOperario { get; set; } = null!;

    public string FkCodigoEncargado { get; set; } = null!;

    public string Motivo { get; set; } = null!;

    public string CodigoServicio { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public bool? Activo { get; set; }

    public virtual Operario? FkCodigoEncargadoNavigation { get; set; } = null!;

    public virtual Operario? FkCodigoOperarioNavigation { get; set; } = null!;

    public virtual ICollection<PrestamosDetalle> PrestamosDetalles { get; set; } = new List<PrestamosDetalle>();
}
