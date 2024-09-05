using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request
{
    public class LoginRequest
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}
