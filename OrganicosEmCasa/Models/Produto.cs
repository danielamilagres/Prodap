using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrganicosEmCasa.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string URLImagem { get; set; }
        public decimal Preco { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}