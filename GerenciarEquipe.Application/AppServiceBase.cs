﻿using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GerenciarEquipe.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> serviceBase;
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            this.serviceBase = serviceBase;
        }

        public TEntity GetById(long? id)
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

        public void AddIfNotExists(TEntity obj, Expression<Func<TEntity, bool>> predicate)
        {
            serviceBase.AddIfNotExists(obj,predicate);
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
            serviceBase.Dispose();
        }
    }
}
