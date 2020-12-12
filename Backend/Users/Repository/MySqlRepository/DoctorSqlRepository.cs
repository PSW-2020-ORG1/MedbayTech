using Model;
using Model.Rooms;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class DoctorSqlRepository : IDoctorRepository
    {

        private MySqlContext _context;

        public DoctorSqlRepository(MySqlContext context)
        {
            _context = context;
        }

        public Doctor Create(Doctor entity)
        {
            if (ExistsInSystem(entity.Id))
            {
                return null;
            }
            _context.Doctors.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(Doctor entity)
        {
            _context.Doctors.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(string id)
        {
            return GetObject(id) != null;
        }


        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();

        }
        
        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            return GetAll().ToList().Where(d => d.IsMySpecialization(specialization));
        }

        public Doctor GetByUsername(string username)
        {
            return GetAll().ToList().FirstOrDefault(d => d.Username.Equals(username));
        }

        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department)
        {
            return GetAll().ToList().Where(d => d.DepartmentId.Equals(department.Id));
        }

        public Doctor GetObject(string id)
        {
            return _context.Doctors.ToList().Find(p => p.Id.Equals(id));
        }

        public Doctor Update(Doctor entity)
        {
            _context.Doctors.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
