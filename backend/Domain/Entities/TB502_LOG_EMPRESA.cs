namespace Domain.Entities
{
    public class TB502_LOG_EMPRESA
    {
        public short IcOperacao { get; set; }

        public DateTime DhOperacao { get; set; }

        public long NuEmpresa { get; set; }

        public long NuLogEmpresa { get; set; }

        public string? CoCnpj { get; set; }

        public string? NoEmpresa { get; set; }
    }
}
