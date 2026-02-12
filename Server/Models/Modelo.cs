using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Modelo
{
    public int MdlId { get; set; }

    public int MdlFkIdMarca { get; set; }

    public string MdlNombreModelo { get; set; } = null!;

    public virtual Marca MdlFkIdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
