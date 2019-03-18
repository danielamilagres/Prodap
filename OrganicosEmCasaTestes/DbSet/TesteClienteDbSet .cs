using OrganicosEmCasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicosEmCasaTestes.DbSet
{
    class TesteClienteDbSet : TesteDbSet<Cliente>
    {
        public override Cliente Find(params object[] keyValues)
        {
            return this.SingleOrDefault(cliente => cliente.ID == (int)keyValues.Single());
        }
    }
}
