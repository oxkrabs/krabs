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
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity GetById<T>(T id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
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
