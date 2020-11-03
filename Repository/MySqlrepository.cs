using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Users;
using SimsProjekat.Repository;

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
        public T Create(T entity)
        {
            if (!ExistsInSystem(entity.GetId()))
            {
                dbSet.Add(entity);
                return entity;
            }
           
            return null;
            
        }

        public bool Delete(T entity)
        {
            if (ExistsInSystem(entity.GetId()))
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                return true;
            }

            return false;

        }

       

        public bool ExistsInSystem(ID id)
        {
            if (dbSet.Find(id) == null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public T GetObject(ID id)
        {
            return dbSet.Find(id);
        }

        public T Update(T entity)
        {
            if (ExistsInSystem(entity.GetId()))
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                return entity;
            }

            return null;
        }
        
        
    }
}
