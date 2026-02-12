using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Operario
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Seccion { get; set; }

    public int IdTaller { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public virtual ICollection<Nip> Nips { get; } = new List<Nip>();

    public virtual ICollection<Prestamo> PrestamoPrsFkCodigoEncargadoNavigations { get; } = new List<Prestamo>();

    public virtual ICollection<Prestamo> PrestamoPrsFkCodigoOperarioNavigations { get; } = new List<Prestamo>();

    public virtual ICollection<RegistrosLavado> RegistrosLavados { get; } = new List<RegistrosLavado>();
}
