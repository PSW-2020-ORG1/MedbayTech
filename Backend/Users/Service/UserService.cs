// File:    UserService.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 3:59:57 AM
// Purpose: Definition of Class UserService

using Model.Users;
using System;
using System.Collections.Generic;
using Repository.UserRepository;
using System.Text.RegularExpressions;
using Backend.Exceptions.Schedules;
using SimsProjekat.SIMS.Exceptions;
using System.Linq;
using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Model.Rooms;

namespace Service.UserService
{
   public class UserService
   {
        private const string USER_ALREADY_EXISTS = "User with identification number exists!";

        public UserService(IUserRepository userRepository, MedicalRecordService.MedicalRecordService medicalRecordService)
        {
            this.userRepository = userRepository;
            this.medicalRecordService = medicalRecordService;
        }

        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department) => userRepository.GetDoctorsFromDepartment(department);


        public RegisteredUser GetUser(string username) => userRepository.GetByUsername(username);

        public RegisteredUser RegisterUser(RegisteredUser user)
        {
            if (IsIdentificationNumberUnique(user))
            {
                if (user is Patient) 
                    medicalRecordService.CreateNewRecord(new MedicalRecord(BloodType.ANeg, (Patient)user, PatientCondition.Stable));
                return userRepository.Create(user);
            }
            throw new UserNotUnique(USER_ALREADY_EXISTS);
        }

        private bool IsIdentificationNumberUnique(RegisteredUser user)
        {
            var exists = userRepository.GetAll().SingleOrDefault(entity => entity.Id.Equals(user.Id));
            if (exists != null)
            {
                var userType = user.GetType();
                var existsType = exists.GetType();
                if (userType.IsAssignableFrom(existsType) || existsType.IsAssignableFrom(userType))
                {
                    return false;
                }
            }
            return true;
        }

        public RegisteredUser Login(string username, string password)
        {
            IEnumerable<RegisteredUser> registeredUser = userRepository.GetAll().Where(entity => entity.Username != null);
            if (!registeredUser.Any(entity => entity.Username.Equals(username)))
                throw new EntityNotFound();
            RegisteredUser user = registeredUser.SingleOrDefault(entity => entity.Username.Equals(username));
            CheckIfGuestAccount(user);
            if (user.Password.Equals(password))
            { 
                return userRepository.GetObject(username);
            }
            throw new InvalidPassword();
        }

        private void CheckIfGuestAccount(RegisteredUser user) 
        {
            if (user is Patient)
            {
                var patinet = (Patient)user;
                if (patinet.IsGuestAccount)
                    throw new NoRightPrivileges();
            }
        }

        public RegisteredUser UpdateUserProfile(RegisteredUser updatedUser) => userRepository.Update(updatedUser);
        public bool DeleteUser(RegisteredUser user)
        {
            if (userRepository.Delete(user))
            {
                if (user is Patient)
                {
                    var record = medicalRecordService.GetRecordBy((Patient)user);
                    medicalRecordService.DeleteRecord(record);
                    return true;
                }
                return true;
            }
            return false;
        }

        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization) => userRepository.GetAllDoctorsBySpecialization(specialization);
        public IEnumerable<Employee> GetAllEmployees() => userRepository.GetAllEmployees();
        public IEnumerable<Secretary> GetAllSecrateries() => userRepository.GetAllSecretaries();
        public IEnumerable<Patient> GetAllPatients() => userRepository.GetAllPatients();
        public IEnumerable<Doctor> GetAllDoctors() => userRepository.GetAllDoctors();
        public RegisteredUser GetDoctor(string id) => userRepository.GetObject(id);

        public bool IsGuestAccount(RegisteredUser user)
        {
            Patient patient = (Patient)userRepository.GetObject(user.Username);
            return patient.IsGuestAccount;
        }
      
        public IUserRepository userRepository;

        public MedicalRecordService.MedicalRecordService medicalRecordService;
   
   }
}