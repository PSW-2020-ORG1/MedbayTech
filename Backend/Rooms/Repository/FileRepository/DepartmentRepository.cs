/***********************************************************************
 * Module:  DepartmentRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.DepartmentRepository
 ***********************************************************************/

using Model.Rooms;
using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.RoomRepository
{
   public class DepartmentRepository : JSONRepository<Department, int>,
        IDepartmentRepository, ObjectComplete<Department>
    {
        public IHospitalRepository hospitalRepository;

        private const string NOT_FOUND = "Department with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Department with ID number {0} already exists!";

        public DepartmentRepository(IHospitalRepository hospitalRepository, Stream<Department> stream) : base(stream, "Department")
        {
            this.hospitalRepository = hospitalRepository;
        }

        public new Department Create(Department entity)
        {
            entity.Id = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public int GetNextID() => base.GetAll().ToList().Count + 1;
       
        public new IEnumerable<Department> GetAll()
        {
            var allDepartments = base.GetAll().ToList();
            foreach (Department department in allDepartments)
            {
                CompleteObject(department);
            }

            return allDepartments;
        }
        public new Department GetObject(int id)
        {
            var department = base.GetObject(id);
            CompleteObject(department);
            return department;
        }

        public new Department Update(Department entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public void SetMissingValues(Department entity)
        {
            entity.Hospital = new Hospital();
        }

        public void CompleteObject(Department entity)
        {
            entity.Hospital = hospitalRepository.GetObject(entity.Hospital.Id);
        }

        public Department GetByName(string name) => GetAll().SingleOrDefault(entity => entity.Name.Equals(name));
    }
}