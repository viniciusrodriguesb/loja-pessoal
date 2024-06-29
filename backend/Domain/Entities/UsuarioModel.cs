using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; } 
        public string Senha { get; set; } 
        public string Email { get; set; }
        //public string Role { get; set; }
    }
}
