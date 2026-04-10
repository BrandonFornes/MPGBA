namespace AdminHerramientas.Shared.Models
{
    public class Intervalo
    {
        public int Id { get; set; }
        public string marcavehiculo { get; set; } = null!;
        public int Intervalo_dias { get; set; }
        public bool Activo { get; set; } = true;
        public int? UsuarioModifico { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}