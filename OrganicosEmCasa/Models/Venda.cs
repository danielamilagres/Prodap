using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganicosEmCasa.Models
{
    public class Venda
    {
        public int ID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ProdutoVenda> ListaProdutos { get; set; }
        public string IdSessao { get; set; }
    }
}