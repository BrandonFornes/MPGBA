using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class RegistrosLavado
{
    public int RlvId { get; set; }

    public string RlvFkCodigoOperario { get; set; } = null!;

    public int RlvFkIdTarea { get; set; }

    public DateTime RlvFecha { get; set; }

    public decimal RlvComisionRegistro { get; set; }

    public DateTime RlvFechaModificacion { get; set; }

    public int RlvUsuarioModifico { get; set; }

    public virtual Operario RlvFkCodigoOperarioNavigation { get; set; } = null!;

    public virtual Tarea RlvFkIdTareaNavigation { get; set; } = null!;
}
