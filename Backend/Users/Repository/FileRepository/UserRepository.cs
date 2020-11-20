/***********************************************************************
 * Module:  RegisteredUserRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.RegisteredUserRepository
 ***********************************************************************/

using Model.Users;
using Backend.Exceptions.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;
using Backend.Users.Repository.MySqlRepository;
using Model.Rooms;
using Repository.RoomRepository;
using Backend.General.Model;

namespace Repository.UserRepository
{
   public class UserRepository : JSONRepository<RegisteredUser, string>,
        IUserRepository, ObjectComplete<RegisteredUser>
   {

        public ICityRepository cityRepository;
        public IAddressRepository addressRepository;
        public IDepartmentRepository departmentRepository;
        public IRoomRepository roomRepository;
        private const string NOT_FOUND = "User with ID number {0} does not exist!";



        public UserRepository(Stream<RegisteredUser> stream, ICityRepository cityRepository, IAddressRepository addressRepository,
            IDepartmentRepository departmentRepository, IRoomRepository roomRepository) : base(stream, "User")
        {
            this.roomRepository = roomRepository;
            this.departmentRepository = departmentRepository;
            this.stream = stream;
            this.cityRepository = cityRepository;
            this.addressRepository = addressRepository;
        }

        public new RegisteredUser Create(RegisteredUser entity)
        {
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public void SetMissingValues(RegisteredUser entity)
        {
            if (entity.CurrResidence != null)
                entity.CurrResidence = new Address();
            if (entity.PlaceOfBirth != null)
                entity.PlaceOfBirth = new City();
            if (entity is Doctor)
                SetDoctorMissing(entity);
            if (entity is Patient)
                SetPatientMissing(entity);
        }

        private void SetPatientMissing(RegisteredUser entity)
        {
            var patient = (Patient)entity;
            if (patient.ChosenDoctor != null)
                patient.ChosenDoctor = new Doctor();
        }

        public void SetDoctorMissing(RegisteredUser entity)
        {
            Doctor doctor = (Doctor)entity;
            doctor.OperationRoom = doctor.OperationRoom == null ? null : new Room();
            doctor.ExaminationRoom = doctor.ExaminationRoom == null ? null : new Room();
            doctor.Department = doctor.Department == null ? null : new Department();
        }

        public new IEnumerable<RegisteredUser> GetAll()
        {
            var allUsers = base.GetAll().ToList();
            foreach (RegisteredUser user in allUsers)
            {
                CompleteObject(user);
            }
            return allUsers;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var allUsers = base.GetAll().ToList();
            List<Doctor> allDoctors = new List<Doctor>();
            foreach (RegisteredUser user in allUsers)
            {
                if (user is Doctor)
                {
                    CompleteObject(user);
                    allDoctors.Add((Doctor)user);
                }
            }
            return allDoctors;
        }

        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            var allDoctors = GetAllDoctors();
            List<Doctor> doctorsBySpecialization = new List<Doctor>();
            foreach (Doctor doctor in allDoctors)
            {
                foreach (Specialization specialty in doctor.Specializations)
                {
                    if (specialty.SpecializationName.Equals(specialization.SpecializationName))
                    {
                        doctorsBySpecialization.Add(doctor);
                    }
                }
            }
            return doctorsBySpecialization;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var allUsers = base.GetAll().ToList();
            List<Employee> allEmployees = new List<Employee>();
            foreach (RegisteredUser user in allUsers)
            {
                if ((user is Employee) || (user is Doctor) || (user is Secretary))
                {
                    CompleteObject(user);
                    allEmployees.Add((Employee) user);
                }
            }
            return allEmployees;
        }

        public IEnumerable<Secretary> GetAllSecretaries()
        {
            var allUsers = base.GetAll().ToList();
            List<Secretary> allSecretaries = new List<Secretary>();
            foreach (RegisteredUser user in allUsers)
            {
                if (user is Secretary)
                {
                    CompleteObject(user);
                    allSecretaries.Add((Secretary)user);
                }
            }
            return allSecretaries;
        }

        public RegisteredUser GetByUsername(string username)
        {
            if (ExistsInSystem(username))
            {
                var registeredUser = base.GetAll().Where(entity => entity.Username != null);
                var user = registeredUser.SingleOrDefault(entity => entity.Username.Equals(username));
                CompleteObject(user);
                return user;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, username));
            }
        }

        public new RegisteredUser GetObject(string id)
        {
            var user = base.GetObject(id);
            CompleteObject(user);
            return user;
        }

        public void CompleteObject(RegisteredUser user)
        {
            if (user.CurrResidence != null)
                user.CurrResidence = addressRepository.GetObject(user.CurrResidence.Id);
            if (user.PlaceOfBirth != null)
                user.PlaceOfBirth = cityRepository.GetObject(user.PlaceOfBirth.Id);

            if (user is Doctor)
                CompleteDoctorObject(user);
            if (user is Patient)
                CompletePatientObject(user);
        }

        private void CompletePatientObject(RegisteredUser user)
        {
            var patient = (Patient)user;
            if (patient.ChosenDoctor != null)
                patient.ChosenDoctor = (Doctor) GetObject(patient.ChosenDoctor.Username);
        }

        public void CompleteDoctorObject(RegisteredUser user)
        {
            Doctor doctor = (Doctor)user;
            doctor.ExaminationRoom = doctor.ExaminationRoom == null ? null : roomRepository.GetObject(doctor.ExaminationRoom.Id);
            doctor.OperationRoom = doctor.OperationRoom == null ? null : roomRepository.GetObject(doctor.OperationRoom.Id);
            doctor.Department = doctor.Department == null ? null : departmentRepository.GetObject(doctor.Department.Id);
        }

        public new RegisteredUser Update(RegisteredUser entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public IEnumerable<Manager> GetAllManagers()
        {

            var allUsers = base.GetAll().ToList();
            List<Manager> allPatients = new List<Manager>();
            foreach (RegisteredUser user in allUsers)
            {
                if (user is Manager)
                {
                    CompleteObject(user);
                    allPatients.Add((Manager)user);
                }
            }
            return allPatients;
        }
        public IEnumerable<Patient> GetAllPatients()
        {
            var allUsers = base.GetAll().ToList();
            List<Patient> allPatients = new List<Patient>();
            foreach (RegisteredUser user in allUsers)
            {
                if (user is Patient)
                {
                    CompleteObject(user);
                    allPatients.Add((Patient)user);
                }
            }
            return allPatients;
        }

        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department)
        {
            var doctors = GetAllDoctors().Where(entity => entity.Department != null);
            return doctors.Where(entity => entity.Department.Id == department.Id);
        }
    }
}