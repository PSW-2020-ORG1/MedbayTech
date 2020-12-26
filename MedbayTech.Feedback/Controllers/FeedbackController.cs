using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Feedback.Application.DTO;
using MedbayTech.Feedback.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedbayTech.Feedback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
                return Ok(_feedbackService.GetAll());
        }

        [HttpPost("createFeedback")]
        public IActionResult Post(PostFeedbackDTO postFeedbackDTO)
        {
            if (postFeedbackDTO.AdditionalNotes.Length <= 0)
            {
                return BadRequest("Failed to post feedback");
            }

            Domain.Entities.Feedback feedbackSuccessfullyCreated = _feedbackService.CreateFeedback(postFeedbackDTO.UserId, postFeedbackDTO.AdditionalNotes, postFeedbackDTO.Anonymous, postFeedbackDTO.AllowedForPublishing);

            if (feedbackSuccessfullyCreated == null)
            {
                return BadRequest("Failed to post feedback");
            }
            return Ok("Feedback posted successfully");
        }
    }
}
