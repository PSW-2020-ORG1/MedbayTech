using Backend.General.Model;
using Model.Users;
using Repository;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.FileRepository
{
    public class SurveyQuestionRepository : ISurveyQuestionRepository
    {
        public Stream<SurveyQuestion> stream;
        private const string NOT_FOUND = "Survey with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Survey with ID number {0} already exists!";

        public SurveyQuestionRepository(Stream<SurveyQuestion> stream)
        {    
            this.stream = stream;
        }

        public SurveyQuestion GetObject(int id)
        {
            if (ExistsInSystem(id))
            {
                var surveyQuestion = stream.GetAll().SingleOrDefault(entity => entity.Id.CompareTo(id) == 0);           
                return surveyQuestion;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, id));
            }
        }

        public IEnumerable<SurveyQuestion> GetAll()
        {
            var allQuestions = stream.GetAll().ToList();
            return allQuestions;
        }
        private bool ExistsInSystem(int id)
        {
            var allAddresses = stream.GetAll().ToList();
            return allAddresses.Any(item => item.Id == id);
        }

        public IEnumerable<SurveyQuestion> GetAllActiveQuestions()
        {
            return null;
        }

        public bool UpdateSurveyQuestion(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}