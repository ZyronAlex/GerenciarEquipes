using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public TEntity GetById(long? id)
        {
            return repository.GetById(id);
        }

        public ICollection<TEntity> Getall()
        {
            return repository.Getall();
        }
       
        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public void AddOrUpdate(TEntity obj)
        {
            repository.AddOrUpdate(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public void Disdisable(TEntity obj)
        {
            repository.Disdisable(obj);
        }

        public void Dispose()
        {

        }        
    }
}

