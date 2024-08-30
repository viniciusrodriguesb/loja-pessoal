namespace Domain.Entities
{
    public class TB503_LOG_USUARIO_EMPRESA
    {
        public short IcOperacao { get; set; }

        public DateTime DhOperacao { get; set; }

        public long? NuEmpresa { get; set; }

        public long NuLogUsuarioEmpresa { get; set; }

        public long? NuUsuario { get; set; }
    }
}
