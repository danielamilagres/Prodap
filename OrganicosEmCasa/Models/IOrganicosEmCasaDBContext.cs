using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OrganicosEmCasa.Models
{
    public interface IOrganicosEmCasaDBContext : IDisposable
    {
        DbSet<Categoria> Categorias { get; }
        DbSet<Cliente> Clientes { get; }
        DbSet<Produto> Produtos { get; }
        DbSet<ProdutoVenda> ProdutoVendas { get; }
        DbSet<Venda> Vendas { get; }

        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}