using OrganicosEmCasa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OrganicosEmCasaTestes.DbSet
{
    public class TesteOrganicosEmCasaDBContext : IOrganicosEmCasaDBContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoVenda> ProdutoVendas { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        public TesteOrganicosEmCasaDBContext()
        {
            this.Clientes = new TesteClienteDbSet();
        }

        public TesteOrganicosEmCasaDBContext(DbSet<Cliente> clientes, DbSet<Categoria> categorias, DbSet<Produto> produtos,
            DbSet<ProdutoVenda> produtoVendas, DbSet<Venda> vendas)
        {
            Clientes = clientes;
            Categorias = categorias;
            Produtos = produtos;
            ProdutoVendas = produtoVendas;
            Vendas = vendas;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            TesteOrganicosEmCasaDBContext context = obj as TesteOrganicosEmCasaDBContext;
            return context != null &&
                   EqualityComparer<DbSet<Cliente>>.Default.Equals(Clientes, context.Clientes) &&
                   EqualityComparer<DbSet<Categoria>>.Default.Equals(Categorias, context.Categorias) &&
                   EqualityComparer<DbSet<Produto>>.Default.Equals(Produtos, context.Produtos) &&
                   EqualityComparer<DbSet<ProdutoVenda>>.Default.Equals(ProdutoVendas, context.ProdutoVendas) &&
                   EqualityComparer<DbSet<Venda>>.Default.Equals(Vendas, context.Vendas);
        }

        public override int GetHashCode()
        {
            var hashCode = 979987893;
            hashCode = hashCode * -1521134295 + EqualityComparer<DbSet<Cliente>>.Default.GetHashCode(Clientes);
            hashCode = hashCode * -1521134295 + EqualityComparer<DbSet<Categoria>>.Default.GetHashCode(Categorias);
            hashCode = hashCode * -1521134295 + EqualityComparer<DbSet<Produto>>.Default.GetHashCode(Produtos);
            hashCode = hashCode * -1521134295 + EqualityComparer<DbSet<ProdutoVenda>>.Default.GetHashCode(ProdutoVendas);
            hashCode = hashCode * -1521134295 + EqualityComparer<DbSet<Venda>>.Default.GetHashCode(Vendas);
            return hashCode;
        }

        public int SaveChanges()
        {
            return 0;
        }

        public DbEntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
