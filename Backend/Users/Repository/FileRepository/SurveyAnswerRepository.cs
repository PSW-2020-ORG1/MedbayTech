using Backend.Users.Model;
using Repository;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.FileRepository
{
    public class SurveyAnswerRepository : ISurveyAnswerRepository
    {
        public Stream<SurveyAnswer> stream;
        private const string NOT_FOUND = "SurveyAnswer with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "SurveyAnswer with ID number {0} already exists!";

        public SurveyAnswerRepository(Stream<SurveyAnswer> stream)
        {
            this.stream = stream;
        }

        public SurveyAnswer GetObject(int id)
        {
            if (ExistsInSystem(id))
            {
                var surveyAnswer = stream.GetAll().SingleOrDefault(entity => entity.Id.CompareTo(id) == 0);
                return surveyAnswer;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, id));
            }
        }

        public IEnumerable<SurveyAnswer> GetAll()
        {
            var allAnswers = stream.GetAll().ToList();
            return allAnswers;
        }
        private bool ExistsInSystem(int id)
        {
            var allAddresses = stream.GetAll().ToList();
            return allAddresses.Any(item => item.Id == id);
        }

        public SurveyAnswer Create(SurveyAnswer entity)
        {
            if (!ExistsInSystem(entity.Id))
            {
                var allAddresses = stream.GetAll().ToList();
                allAddresses.Add(entity);
                stream.SaveAll(allAddresses);
                return entity;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Id));
            }
        }
    }
}
