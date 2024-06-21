namespace Domain.Entities
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public int Empresa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco {  get; set; }

        //Navigation
        //public int EmpresaNavigation { get; set; }
    }
}
