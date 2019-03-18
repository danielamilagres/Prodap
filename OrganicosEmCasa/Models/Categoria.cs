using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganicosEmCasa.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string URLImagem { get; set; }
        public string Descricao { get; set; }
    }
}