using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class RegistrosLavado
{
    public int Id { get; set; }

    public string FkCodigoOperario { get; set; } = null!;

    public int FkIdTarea { get; set; }

    public DateTime Fecha { get; set; }

    public decimal ComisionRegistro { get; set; }

    public virtual Operario FkCodigoOperarioNavigation { get; set; } = null!;

    public virtual Tarea FkIdTareaNavigation { get; set; } = null!;
}
