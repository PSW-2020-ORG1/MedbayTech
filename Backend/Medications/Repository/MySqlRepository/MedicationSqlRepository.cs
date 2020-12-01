using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;
using Model;
using Repository;

namespace Backend.Medications.Repository.MySqlRepository
{
    public class MedicationSqlRepository : IMedicationRepository
    {
        private MySqlContext _context;
        public MedicationSqlRepository(MySqlContext context)
        {
            _context = context;
        }

        public Medication Create(Medication entity)
        {
            if (ExistsInSystem(entity.Id))
            {
                return null;
            }
            _context.Medications.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(Medication entity)
        {
            _context.Medications.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(int id)
        {
            return GetObject(id) != null;
        }

        public IEnumerable<Medication> GetAll()
        {
            return _context.Medications.ToList();
        }

        public IEnumerable<Medication> GetAllApproved()
        {
            return _context.Medications.ToList();
        }

        public IEnumerable<Medication> GetAllOnValidation()
        {
            return _context.Medications.ToList();
        }

        public IEnumerable<Medication> GetAllRejected()
        {
            return _context.Medications.ToList();
        }

        public int GetNextID()
        {
            throw new NotImplementedException();
        }

        public Medication GetObject(int id)
        {
            return _context.Medications.ToList().Find(p => p.Id.Equals(id));
        }

        public Medication Update(Medication entity)
        {
            _context.Medications.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
