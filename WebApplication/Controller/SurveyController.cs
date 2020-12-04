using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.Model;
using Backend.Users.Service.Interfaces;
using Backend.Users.WebApiService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using Service.GeneralService;
using WebApplication.Adapters;
using WebApplication.DTO;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }   
        [HttpGet("allQuestions")]
        public IActionResult GetAllQuestions()
        {
            List<SurveyQuestion> allQuestions = _surveyService.GetAllActiveQuestions().ToList();
            List<SurveyQuestionDTO> allQuestionsDTOs = SurveyAdapter.ListActiveQuestionsToListSurveyQuestionDTO(allQuestions);
            return Ok(allQuestionsDTOs);
        }

        [HttpPost("createSurvey")]
        public IActionResult Post(PostSurveyDTO postSurveyDTO)
        {
         
            Survey surveySuccessfullyCreated = _surveyService.CreateSurvey(postSurveyDTO.surveyQuestions, postSurveyDTO.surveyAnswers, postSurveyDTO.appointmentId);

            if (surveySuccessfullyCreated == null)
            {
                return BadRequest("Failed to post survey");
            }
            return Ok("Survey posted successfully");
        }
    }
}
