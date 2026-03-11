using System;
using System.Collections.Generic;

namespace AdminHerramientas.Shared.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Rfc { get; set; } = null!;

    public bool EsAgencia { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public virtual ICollection<Concesionario> Concesionarios { get; } = new List<Concesionario>();
}
