using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;
using WebApplication.DTO;
using WebApplicationService.GeneralService;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private SurveyService surveyService;

        public SurveyController()
        {
            surveyService = new SurveyService();
        }   
        [HttpGet("allQuestions")]
        public IActionResult GetAllQuestions()
        {
            List<SurveyQuestion> allQuestions = surveyService.GetAllActiveQuestions().ToList();
            List<SurveyQuestionDTO> allQuestionsDTOs = SurveyAdapter.ListActiveQuestionsToListSurveyQuestionDTO(allQuestions);
            return Ok(allQuestionsDTOs);
        }
    }
}
