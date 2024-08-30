using Application.Constantes.Enums;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.LogDTO
{
    public class LogUsuarioDTO
    {
        [Required]
        public TB001_USUARIO Usuario { get; set; }

        [Required]
        public TipoOperacao TpOperacao { get; set; }
    }
}
