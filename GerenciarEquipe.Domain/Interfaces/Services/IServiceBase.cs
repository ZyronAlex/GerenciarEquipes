using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(long? id);
        ICollection<TEntity> Getall();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void AddOrUpdate(TEntity obj);
        void AddIfNotExists(TEntity obj, Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity obj);
        void Disdisable(TEntity obj);
        void Dispose();
    }
}
