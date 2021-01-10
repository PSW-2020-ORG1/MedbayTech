using Infrastructure.Database;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Enums;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Persistance
{
    public class SurveyQuestionRepository : SqlRepository<SurveyQuestion, int>, ISurveyQuestionRepository
    {
        public SurveyQuestionRepository(AppointmentDbContext context) : base(context) { }

        public List<SurveyQuestion> GetAllActiveQuestions()
        {
            return GetAll().Where(surveyQuestion => surveyQuestion.Status).ToList();
        }

        public bool UpdateSurveyQuestion(Survey survey)
        {
            bool r = false;
            foreach (int i in survey.SurveyQuestions)
            {
                SurveyQuestion question = GetBy(i);
                if (!ExistsBy(i))
                {
                    r = false;
                }
                else
                {
                    switch (survey.SurveyAnswers.ElementAt(i - 1))
                    {
                        case Grade.excellent:
                            question.Excellent++;
                            r = true;
                            break;
                        case Grade.veryGood:
                            question.VeryGood++;
                            r = true;
                            break;
                        case Grade.good:
                            question.Good++;
                            r = true;
                            break;
                        case Grade.poor:
                            question.Poor++;
                            r = true;
                            break;
                        case Grade.veryPoor:
                            question.VeryPoor++;
                            r = true;
                            break;
                        default:
                            r = false;
                            break;
                    }
                }
                question.CountAverageGrade();
                Update(question);
            }
            return r;
        }
    }
}
