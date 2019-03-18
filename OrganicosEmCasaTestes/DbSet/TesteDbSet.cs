using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace OrganicosEmCasaTestes.DbSet
{
    public class TesteDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>
        where T : class
    {
        readonly ObservableCollection<T> dados;
        readonly IQueryable query;

        public TesteDbSet()
        {
            dados = new ObservableCollection<T>();
            query = dados.AsQueryable();
        }

        public override T Add(T entity)
        {
            dados.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            dados.Remove(entity);
            return entity;
        }

        public override T Attach(T entity)
        {
            return this.Add(entity);
        }

        public override T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(dados); }
        }

        Type IQueryable.ElementType
        {
            get { return query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return dados.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return dados.GetEnumerator();
        }
    }
}
