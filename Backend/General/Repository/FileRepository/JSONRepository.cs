using Repository;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.General.Model
{
    public class JSONRepository<T, ID> : IRepository<T, ID>
        where T : IIdentifiable<ID>
        where ID : IComparable
    { 
        public Stream<T> stream;
        private string entityName;


        private const string NOT_FOUND = "{0} does not exist!";
        private const string ALREADY_EXISTS = "{0} already exists!";


        public JSONRepository(Stream<T> stream, string entityName)
        {
            this.entityName = entityName;
            this.stream = stream;
        }

        public T Create(T entity)
        {
            if (!ExistsInSystem(entity.GetId()))
            {
                var allEntities = stream.GetAll().ToList();
                allEntities.Add(entity);
                stream.SaveAll(allEntities);
                return entity;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entityName));
            };
        }

        public bool Delete(T entity)
        {
            if (ExistsInSystem(entity.GetId()))
            {
                var allEnties = stream.GetAll().ToList();
                var entityToRemove = allEnties.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
                allEnties.Remove(entityToRemove);
                stream.SaveAll(allEnties);
                return true;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, entityName));
            }

        }

        public bool ExistsInSystem(ID id)
        {
            var allEntities = stream.GetAll().ToList();
            return allEntities.Any(item => item.GetId().CompareTo(id) == 0);
        }

        public IEnumerable<T> GetAll() => stream.GetAll().ToList();

        public T GetObject(ID id)
        { 
            if (ExistsInSystem(id))
                return stream.GetAll().SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
            else
                throw new EntityNotFound(string.Format(NOT_FOUND, id));
        }

        public T Update(T entity)
        {
            if (ExistsInSystem(entity.GetId()))
            {
                var allEntities = stream.GetAll().ToList();
                allEntities[allEntities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
                stream.SaveAll(allEntities);
                return entity;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, entity.GetId()));
            }

        }
    }
}
