using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend.Users.Model
{
    public class SurveyAnswer
    {
        public int Id { get; protected set; }
        [ForeignKey("Survey")]
        public int SurveyId { get; protected set; }
        public virtual Survey Survey { get; set; }
        public Grade Grade { get; protected set; }
        public int SurveyQuestionId { get; protected set; }


        public SurveyAnswer() { }

        public SurveyAnswer(int id, Survey survey, Grade grade, int surveyQuestionId ) 
        {
            Id = id;
            Survey = survey;
            SurveyId = survey.Id;
            Grade = grade;
            SurveyQuestionId = surveyQuestionId;
        }
    }



    
}
