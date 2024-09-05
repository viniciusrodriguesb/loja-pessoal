using Application.Constantes.Enums;
using Domain.Entities;

namespace Application.DTO.LogDTO
{
    public class LogGrupoDTO
    {
        public TB006_GRUPO Grupo { get; set; }
        public TipoOperacao TpOperacao { get; set; }
    }
}
