using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Users;
using Backend.General.Model;

namespace Repository
{
    public class MySqlrepository<T, ID> : IRepository<T, ID>
        where T : class, IIdentifiable<ID>
        where ID : IComparable
    {

        protected MySqlContext context;

        internal DbSet<T> dbSet;
        
        public  MySqlrepository() {}

        public MySqlrepository(MySqlContext mySqlContext)
        {
            this.context = mySqlContext;
            this.dbSet = context.Set<T>();
        }

        /// <summary>
        /// Create <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>T entity or null</returns>
        public T Create(T entity)
        {
            if (!ExistsInSystem(entity.GetId()))
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
            if (ExistsInSystem(entity.GetId()))
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
        public bool ExistsInSystem(ID id)
        {
            if (dbSet.Find(id) == null)
                return false;

            return true;
        }

        /// <summary>
        /// Return all elements from database
        /// </summary>
        /// <returns>IEnumerable <typeparamref name="T"/></returns>
        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        /// <summary>
        /// Return object from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns><typeparamref name="T"/> or null</returns>
        public T GetObject(ID id)
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
            if (ExistsInSystem(entity.GetId()))
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
