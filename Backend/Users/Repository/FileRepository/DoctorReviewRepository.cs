// File:    DoctorReviewRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 4:15:45 AM
// Purpose: Definition of Class DoctorReviewRepository

using Model.Users;
using Repository.UserRepository;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public class DoctorReviewRepository : IDoctorReviewRepository, ObjectComplete<DoctorReview>
    {
        public IUserRepository userRepository;
        public Stream<DoctorReview> stream;
        private const string NOT_FOUND = "DoctorReview with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "DoctorReview with ID number {0} already exists!";

        public DoctorReviewRepository(IUserRepository userRepository, Stream<DoctorReview> stream)
        {
            this.userRepository = userRepository;
            this.stream = stream;
        }

        public DoctorReview Create(DoctorReview entity)
        {
            if (!ExistsInSystem(entity.Id))
            {
                if (!AlredyExistByUser(entity))
                {
                    var allDoctorReviews = stream.GetAll().ToList();
                    entity.Id = GetNextID();
                    SetMissingValues(entity);
                    allDoctorReviews.Add(entity);
                    stream.SaveAll(allDoctorReviews);
                    return entity;
                }
                else
                    return null;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Id));
            }
        }
        private bool ExistsInSystem(int id)
        {
            var allDoctorReviews = stream.GetAll().ToList();
            return allDoctorReviews.Any(item => item.Id == id);
        }
        private bool AlredyExistByUser(DoctorReview doctorReview) {
            var allDoctorReviews = stream.GetAll().ToList();
            foreach (DoctorReview d in allDoctorReviews) {
                if (d.Patient.Username.Equals(doctorReview.Patient.Username) && d.Doctor.Username.Equals(doctorReview.Doctor.Username))
                    return true;
            }
            return false;
        }
        public IEnumerable<DoctorReview> GetAll()
        {
            var allReviews = stream.GetAll();
            foreach (DoctorReview doctorReview in allReviews)
            {
                CompleteObject(doctorReview);
            }
            return allReviews;
        }
        public DoctorReview GetObject(int id)
        {
            if (ExistsInSystem(id))
            {
                var review = stream.GetAll().SingleOrDefault(entity => entity.Id.CompareTo(id) == 0);
                CompleteObject(review);
                return review;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, id));
            }
        }
        public IEnumerable<DoctorReview> GetReviewsForDoctor(Doctor doctor) => GetAll().ToList().Where(entity => entity.Doctor.Username.Equals(doctor.Username));
        
        private int GetNextID() => stream.GetAll().ToList().Count + 1;
        public void SetMissingValues(DoctorReview entity)
        {
            entity.Doctor = new Doctor();
            entity.Patient = new Patient();
        }

        public void CompleteObject(DoctorReview entity)
        {
            entity.Doctor = (Doctor) userRepository.GetObject(entity.Doctor.Username);
            entity.Patient = (Patient)userRepository.GetObject(entity.Patient.Username);
        }
    }
}