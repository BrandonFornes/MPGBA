using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHerramientas.Shared.Models
{
    [Table("historial_mantenimientos")]
    public class HistorialMantenimiento
    {
        [Key]
        public int Id { get; set; }
        
        [Column("fk_bastidor")]
        public string? FkBastidor { get; set; }
        public DateTime fechaMantenimiento { get; set; }
        public int IdConcesionario { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModifico { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("FkBastidor")]
        public virtual Vehiculo? Vehiculo { get; set; }

        [ForeignKey("IdConcesionario")]
        public virtual Concesionario? Concesionario { get; set; }
    }
}
