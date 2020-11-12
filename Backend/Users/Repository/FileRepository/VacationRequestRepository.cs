// File:    VacationRequestRepository.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 3:17:04 AM
// Purpose: Definition of Class VacationRequestRepository

using Model.Users;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.UserRepository
{
   public class VacationRequestRepository : JSONRepository<VacationRequest, int>,
        IVacationRequestRepository, ObjectComplete<VacationRequest>
    {
        public IUserRepository employeeRepository;

        private const string NOT_FOUND = "Vacation request with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Vacation request with ID number {0} already exists!";

        public VacationRequestRepository(IUserRepository userRepository, Stream<VacationRequest> stream) : base(stream, "Vacation request")
        {
            this.employeeRepository = userRepository;
        }

        public new VacationRequest Create(VacationRequest entity)
        {
            SetMissingValues(entity);
            entity.Id = GetNextID();
            return base.Create(entity);
        }
        public  new IEnumerable<VacationRequest> GetAll()
        {
            var allRequests = base.GetAll();
            foreach (VacationRequest vacationRequest in allRequests)
            {
                CompleteObject(vacationRequest);
            }
            return allRequests;
        }
        public IEnumerable<VacationRequest> GetAllUnapproved() => GetAll().Where(vacationRequest => vacationRequest.Approved == false).ToList();

        public new VacationRequest GetObject(int id)
        {
            var request = base.GetObject(id);
            CompleteObject(request);
            return request;
        }

        public new VacationRequest Update(VacationRequest entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public int GetNextID() => base.GetAll().ToList().Count + 1;
        
        
        public void SetMissingValues(VacationRequest vacationRequest)
        {
            vacationRequest.Employee = new Employee();
        }

        public void CompleteObject(VacationRequest vacationRequest)
        {
            vacationRequest.Employee = (Employee)employeeRepository.GetObject(vacationRequest.Employee.Username);
        }
    }
}