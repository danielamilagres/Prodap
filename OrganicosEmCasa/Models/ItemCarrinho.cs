using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganicosEmCasa.Models
{
    public class ItemCarrinho
    {
        public ItemCarrinho(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal
        {
            get
            {
                return Produto.Preco * Quantidade;
            }
        }
    }
}