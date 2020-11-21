using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationService.GeneralService
{
    public class SurveyService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
    

        public IEnumerable<SurveyQuestion> GetAllQuestions()
        {
            return unitOfWork.SurveyQuestionRepository.GetAll();
        }

        public IEnumerable<SurveyQuestion> GetAllActiveQuestions()
        {
            return unitOfWork.SurveyQuestionRepository.GetAllActiveQuestions();
        }
    }
}
