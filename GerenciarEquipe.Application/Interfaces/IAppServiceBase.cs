using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
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
