using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrganicosEmCasa.Models
{
    public class ProdutoVenda
    {
        public int ID { get; set; }
        public int IDVenda { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

    }
}