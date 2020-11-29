using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.Model;
using Backend.Users.WebApiController;
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
        private WebSurveyController surveyContoller;

        public SurveyController()
        {
            this.surveyContoller = new WebSurveyController();
        }   
        [HttpGet("allQuestions")]
        public IActionResult GetAllQuestions()
        {
            List<SurveyQuestion> allQuestions = surveyContoller.GetAllActiveQuestions().ToList();
            List<SurveyQuestionDTO> allQuestionsDTOs = SurveyAdapter.ListActiveQuestionsToListSurveyQuestionDTO(allQuestions);
            return Ok(allQuestionsDTOs);
        }

        [HttpPost("createSurvey")]
        public IActionResult Post(PostSurveyDTO postSurveyDTO)
        {

            SurveyService surveyService = new SurveyService();           
            Survey surveySuccessfullyCreated = surveyContoller.CreateSurvey(postSurveyDTO.surveyQuestions, postSurveyDTO.surveyAnswers, postSurveyDTO.appointmentId);

            if (surveySuccessfullyCreated == null)
            {
                return BadRequest("Failed to post survey");
            }
            return Ok("Survey posted successfully");
        }
    }
}
