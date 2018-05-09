using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GerenciarEquipe.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> serviceBase;
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            this.serviceBase = serviceBase;
        }

        public TEntity GetById(int id)
        {
            return serviceBase.GetById(id);
        }

        public ICollection<TEntity> Getall()
        {
            return serviceBase.Getall();
        }

        public void Add(TEntity obj)
        {
            serviceBase.Add(obj);
        }

        public void Update(TEntity obj)
        {
            serviceBase.Update(obj);
        }

        public void AddOrUpdate(TEntity obj)
        {
            serviceBase.AddOrUpdate(obj);
        }

        public void Remove(TEntity obj)
        {
            serviceBase.Remove(obj);
        }

        public void Disdisable(TEntity obj)
        {
            serviceBase.Disdisable(obj);
        }

        public void Dispose()
        {

        }
    }
}
