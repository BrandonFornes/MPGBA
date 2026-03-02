using System;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Models;

public partial class Herramienta
{
    public int HrmId { get; set; }

    public string? HrmEtiqueta { get; set; }

    public string HrmNombreHerramienta { get; set; } = null!;

    public string? HrmDescripcion { get; set; }

    public bool? HrmDisponible { get; set; }

    public string? HrmEstado { get; set; }

    public DateTime? HrmFechaCompra { get; set; }

    public string? HrmMarcaHerramienta { get; set; }

    public DateTime HrmFechaModificacion { get; set; }

    public int HrmUsuarioModifico { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();

    public virtual ICollection<PrestamosDetalle> PrestamosDetalles { get; } = new List<PrestamosDetalle>();
}
