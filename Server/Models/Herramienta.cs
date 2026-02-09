using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Herramienta
{
    public int Id { get; set; }

    public string? Etiqueta { get; set; }

    public string NombreHerramienta { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Disponible { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
