using System.ComponentModel.DataAnnotations;

namespace GameCom.Api.DTOs
{
    public class ProductTypeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Initials { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
