using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public int Produto { get; set; }
        public string TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }

        //Navigation
        //public int ProdutoNavigation { get; set; }
    }
}
