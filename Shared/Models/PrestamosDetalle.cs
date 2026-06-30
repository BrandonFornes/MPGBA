using System;
using System.Collections.Generic;

namespace AdminHerramientas.Shared.Models;

public partial class PrestamosDetalle
{
    public int Id { get; set; }

    public int FkIdPrestamo { get; set; }

    public int FkIdHerramienta { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? Comentario { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public virtual Prestamo? FkIdPrestamoNavigation { get; set; } = null!;
}
