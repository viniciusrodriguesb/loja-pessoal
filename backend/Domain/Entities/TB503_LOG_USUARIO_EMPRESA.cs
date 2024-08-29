namespace Domain.Entities
{
    public class TB503_LOG_USUARIO_EMPRESA
    {
        public int NuLogUsuarioEmpresa { get; set; }
        public int IcOperacao { get; set; }
        public DateTime DhOperacao { get; set; }
        public int? NuEmpresa { get; set; }
        public int? NuUsuario { get; set; }
    }   
}
