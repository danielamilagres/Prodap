using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganicosEmCasa.Models
{
    public class Carrinho
    {
        public List<ItemCarrinho> ListaDeItens { get; set; }
        public decimal ValorTotal
        {
            get
            {
                decimal totalizador = 0;
                if(ListaDeItens != null)
                { 
                    foreach (var item in ListaDeItens)
                    {
                        totalizador += item.ValorTotal;
                    }
                }
                return totalizador;
            }
        }
    }
}