using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request
{
    public class NovoUsuarioRequest
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "O campo Email deve conter um endereço de email válido.")]
        public string Email { get; set; }
    }
}
