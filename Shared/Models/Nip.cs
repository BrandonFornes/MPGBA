using System;
using System.Collections.Generic;
namespace AdminHerramientas.Shared.Models;

public partial class Nip
{
    public int NipId { get; set; }

    public string NipFkCodigoOperario { get; set; } = null!;

    public string NipNip { get; set; } = null!;

    public DateTime NipFechaModificacion { get; set; }

    public int NipUsuarioModifico { get; set; }

    public virtual Operario NipFkCodigoOperarioNavigation { get; set; } = null!;
}
