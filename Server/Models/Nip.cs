using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Nip
{
    public int Id { get; set; }

    public string FkCodigoOperario { get; set; } = null!;

    public string Nip1 { get; set; } = null!;

    public virtual Operario FkCodigoOperarioNavigation { get; set; } = null!;
}
