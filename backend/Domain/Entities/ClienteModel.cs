namespace Domain.Entities
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int Pedido { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        //Navigation
        //public int PedidoNavigation { get; set; }
    }
}
