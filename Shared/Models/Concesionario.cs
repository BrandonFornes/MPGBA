using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHerramientas.Shared.Models
{
    [Table("Concesionarios")]
    public class Concesionario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        
        [Column("fk_IdEmpresa")]
        public int FkIdEmpresa { get; set; }
        
        public string Localidad { get; set; } = null!;
        public bool Activo { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModifico { get; set; }

        [ForeignKey("FkIdEmpresa")]
        public virtual Empresa? Empresa { get; set; }
    }
}
