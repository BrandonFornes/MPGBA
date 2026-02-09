using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Prestamo
{
    public int IdPrestamos { get; set; }

    public string FkCodigoOperario { get; set; } = null!;

    public int FkIdHerramienta { get; set; }

    public string FkCodigoEncargado { get; set; } = null!;

    public string Motivo { get; set; } = null!;

    public string CodigoServicio { get; set; } = null!;

    public DateTime? FechaSolicitud { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? Comentario { get; set; }

    public virtual Operario FkCodigoEncargadoNavigation { get; set; } = null!;

    public virtual Operario FkCodigoOperarioNavigation { get; set; } = null!;

    public virtual Herramienta FkIdHerramientaNavigation { get; set; } = null!;
}
