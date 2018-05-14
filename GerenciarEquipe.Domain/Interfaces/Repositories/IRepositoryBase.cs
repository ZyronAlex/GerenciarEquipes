using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {       
        TEntity GetById(long? id);
        ICollection<TEntity> Getall();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void AddOrUpdate(TEntity obj);
        void Remove(TEntity obj);
        void Disdisable(TEntity obj);
        void Dispose();
    }
}
