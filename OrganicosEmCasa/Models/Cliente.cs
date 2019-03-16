using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrganicosEmCasa.Utils;

namespace OrganicosEmCasa.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public Estados UF { get; set; }
        public string CEP { get; set; }

        public string Telefone { get; set; }
    }
}