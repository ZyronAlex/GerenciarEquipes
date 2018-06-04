using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected GerenciarEquipeModelContext Db = new GerenciarEquipeModelContext();

        public TEntity GetById(long? id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public ICollection<TEntity> Getall()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void AddOrUpdate(TEntity obj)
        {
            Db.Set<TEntity>().AddOrUpdate(obj);
            Db.SaveChanges();
        }

        public void AddIfNotExists(TEntity obj, Expression<Func<TEntity, bool>> predicate = null)
        {
            var exists = predicate != null ? Db.Set<TEntity>().Any(predicate) : Db.Set<TEntity>().Any();
            if (exists)
                return;
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Disdisable(TEntity obj)
        {
            if (obj.GetType().GetProperty("ativo") != null)
            {
                obj.GetType().GetProperty("ativo").SetValue(obj, false);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}

