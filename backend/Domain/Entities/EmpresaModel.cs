namespace Domain.Entities
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        public int Empresa { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public float Preco { get; set; }

        //Navigation
        //public int EmpresaNavigation { get; set; }
    }
}
