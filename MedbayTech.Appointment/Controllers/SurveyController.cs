using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Application.Mappers;
using MedbayTech.Appointment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("allQuestions")]
        public IActionResult GetAllQuestions()
        {
            List<SurveyQuestion> allQuestions = _surveyService.GetAllActiveQuestions().ToList();
            List<SurveyQuestionDTO> allQuestionsDTOs = SurveyMapper.ListActiveQuestionsToListSurveyQuestionDTO(allQuestions);
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
