namespace Domain.Entities
{
    public class TB501_LOG_USUARIO
    {
        public short IcOperacao { get; set; }

        public short? IcUsuario { get; set; }

        public DateTime DhOperacao { get; set; }

        public long NuLogUsuario { get; set; }

        public long NuUsuario { get; set; }

        public string? CoSenha { get; set; }

        public string? NoEmail { get; set; }

        public string? NoUsuario { get; set; }
    }
}
