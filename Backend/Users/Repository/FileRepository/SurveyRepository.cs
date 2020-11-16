// File:    SurveyRepository.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 3:04:42 AM
// Purpose: Definition of Class SurveyRepository

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
   public class SurveyRepository : ISurveyRepository, ObjectComplete<Survey>
    {
        public IUserRepository userRepository;
        public Stream<Survey> stream;

        private const string ALREADY_EXISTS = "Survey with ID number {0} already exists!";

        public SurveyRepository(IUserRepository userRepository, Stream<Survey> stream)
        {
            this.stream = stream;
            this.userRepository = userRepository;
        }
        public Survey Create(Survey entity)
        {
            if (!ExistsInSystem(entity.Id))
            {
                var allSurveys = stream.GetAll().ToList();
                entity.Id = GetNextID();
                SetMissingValues(entity);
                allSurveys.Add(entity);
                stream.SaveAll(allSurveys);
                return entity;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Id));
            }
        }

        public IEnumerable<Survey> GetAll()
        {
            var allSurveys = stream.GetAll().ToList();
            foreach(Survey survey in allSurveys)
            {
                CompleteObject(survey);
            }
            return allSurveys;
        }
        private int GetNextID() => stream.GetAll().ToList().Count + 1;
        private bool ExistsInSystem(int id)
        {
            var allSurveys = stream.GetAll().ToList();
            return allSurveys.Any(item => item.Id == id);
        }

        public void CompleteObject(Survey survey)
        {
            survey.Patient = (Patient)userRepository.GetObject(survey.Patient.Username);
        }
        public void SetMissingValues(Survey survey)
        {
            survey.Patient = new Patient();
        }
    }
}