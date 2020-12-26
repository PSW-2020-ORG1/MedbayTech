using MedbayTech.Repository.Domain.Entities;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Repository.Repository.SqlRepository
{
    public class SqlRepository<T, ID> : IRepository<T, ID>
        where T : class, IIdentifiable<ID>
        where ID : IComparable
    {

        protected MyDbContext<T, ID> context;

        internal DbSet<T> dbSet;

        public SqlRepository() { }

        public SqlRepository(MyDbContext<T, ID> context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        /// <summary>
        /// Create <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>T entity or null</returns>
        public T Create(T entity)
        {
            if (!ExistsBy(entity.GetId()))
            {
                dbSet.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return null;
        }

        /// <summary>
        /// Delete <typeparamref name="T"/> from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        public bool Delete(T entity)
        {
            if (ExistsBy(entity.GetId()))
            {
                if (context.Entry(entity).State == EntityState.Detached)
                    dbSet.Attach(entity);
                dbSet.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if entity exists in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>

        public bool ExistsBy(ID id)
        {
            if (dbSet.Find(id) == null)
                return false;

            return true;
        }

        /// <summary>
        /// Return all elements from database
        /// </summary>
        /// <returns>IEnumerable <typeparamref name="T"/></returns>
        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Return object from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns><typeparamref name="T"/> or null</returns>

        public T GetBy(ID id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Update existing object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><typeparamref name="T"/> or null</returns>
        public T Update(T entity)
        {
            if (ExistsBy(entity.GetId()))
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
            return null;
        }
    }
}
