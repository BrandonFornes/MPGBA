using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHerramientas.Shared.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string RFC { get; set; } = null!;
        public bool EsAgencia { get; set; }
        public bool Activo { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int usuarioModifico { get; set; }
        
        // Relación: Una empresa tiene muchos concesionarios
        public virtual ICollection<Concesionario> Concesionarios { get; set; } = new List<Concesionario>();
    }
}