using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using krabs.Domain.Interfaces;
using krabs.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace krabs.Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Db;

        public Repository(ApplicationDbContext context)
        {
            this.Db = context;
        }

        public virtual void Add(TEntity obj)
        {
            this.Db.Add<TEntity>(obj);
        }

        public virtual TEntity GetById<T>(T id)
        {
            return Db.Find<TEntity>(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this.Db.Set<TEntity>().AsNoTracking();
        }

        public virtual void Update(TEntity obj)
        {
            Db.Update<TEntity>(obj);
        }

        public virtual void Remove(Guid id)
        {
            Db.Remove<TEntity>(Db.Find<TEntity>(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
