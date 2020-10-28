using System.ComponentModel.DataAnnotations;

namespace GameCom.Api.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        public string Alias { get; set; }

        public int Version { get; set; }
    }
}
