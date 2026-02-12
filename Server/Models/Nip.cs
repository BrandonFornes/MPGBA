using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Nip
{
    public int NipId { get; set; }

    public string NipFkCodigoOperario { get; set; } = null!;

    public string NipNip { get; set; } = null!;

    public virtual Operario NipFkCodigoOperarioNavigation { get; set; } = null!;
}
