using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Concesionario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int FkIdEmpresa { get; set; }

    public string Localidad { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int UsuarioModifico { get; set; }

    public virtual Empresa FkIdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<HistorialMantenimiento> HistorialMantenimientos { get; } = new List<HistorialMantenimiento>();
}
