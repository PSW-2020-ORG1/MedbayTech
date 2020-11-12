/***********************************************************************
 * Module:  WorkDayRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.WorkDayRepository
 ***********************************************************************/

using Model.Users;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.UserRepository
{
   public class WorkDayRepository : JSONRepository<WorkDay, int>,
        IWorkDayRepository, ObjectComplete<WorkDay>
   {
        public IUserRepository employeeRepository;

        private const string NOT_FOUND = "Work day with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Work day with ID number {0} already exists!";

        public WorkDayRepository(IUserRepository userRepository, Stream<WorkDay> stream) : base(stream, "Work day")
        {
            this.employeeRepository = userRepository;
        }
        public new WorkDay Create(WorkDay entity)
        {
            entity.Id = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public int GetNextID() => base.GetAll().ToList().Count + 1;
     
        public new IEnumerable<WorkDay> GetAll()
        {
            var allWorkDays = base.GetAll();
            foreach (WorkDay workDay in allWorkDays)
            {
                CompleteObject(workDay);
            }
            return allWorkDays;
        }

        public new WorkDay GetObject(int id)
        {
            var workDay = base.GetObject(id);
            CompleteObject(workDay);
            return workDay;
        }

        public IEnumerable<WorkDay> GetWorkTimeForEmployee(Employee employee)
        {
            var allWorkDays = base.GetAll().ToList().Where(day => day.Employee.Id.Equals(employee.Id));
            List<WorkDay> WorkTimeForEmployee = new List<WorkDay>();
            foreach(WorkDay workDay in allWorkDays)
            {
                CompleteObject(workDay);
            }
            return WorkTimeForEmployee;
        }

        public new WorkDay Update(WorkDay entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public void SetMissingValues(WorkDay entity)
        {
            entity.Employee = new Employee();
        }

        public void CompleteObject(WorkDay entity)
        {
            entity.Employee = (Employee)employeeRepository.GetObject(entity.Employee.Username);
        }
    }
}