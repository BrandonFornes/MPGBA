using System;

namespace AdminHerramientas.Shared.Models
{
    public class Nip
    {
        public int Id { get; set; }
        public string Fk_codigoOperario { get; set; } = null!;
        public string ValorNip { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModifico { get; set; }
        public bool Activo { get; set; }
    }
}

