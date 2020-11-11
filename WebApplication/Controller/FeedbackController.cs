using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Backend.Examinations.Model;
using Model.Users;
using Repository;
using Repository.GeneralRepository;
using WebApplication.DTO;
using WebApplicationService.GeneralService;
using WebApplication.Adapters;
using System.Security.Cryptography.Xml;

namespace WebApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private FeedbackService feedbackService;

        public FeedbackController()
        {
            feedbackService = new FeedbackService();
        }
        /// <summary>
        /// GET method for feedback that is approved by the system administrator
        /// </summary>
        /// <returns>list of approved feedback</returns>
        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {
            List<Feedback> approvedFeedback = feedbackService.GetAllApprovedFeedback().ToList();
            List<ApprovedFeedbackDTO> approvedFeedbackDTOs = FeedbackAdapter.ListApprovedFeedbackToListApprovedFeedbackDTO(approvedFeedback);
            return Ok(approvedFeedbackDTOs);
        }

        /// <summary>
        /// GET method for all feedback
        /// </summary>
        /// <returns>list of all feedback</returns>
        [HttpGet("allFeedback")]
        public IActionResult GetAllFeedback() 
        {
            List<Feedback> allFeedback = feedbackService.GetAll().ToList();
            List<AllFeedbackDTO> allFeedbackDTOs = FeedbackAdapter.ListAllFeedbackToListAllFeedbackDTO(allFeedback);
            return Ok(allFeedbackDTOs);
        }

        /// <summary>
        /// POST method for changing the status of a feedback, depending on what the system administrator approved or denied
        /// </summary>
        /// <param name="updateFeedbackStatusDTO"></param>
        /// <returns>boolean that shows that feedback status was changed</returns>
        [HttpPost("updateFeedbackStatus")]
        public IActionResult UpdateFeedbackStatus(UpdateFeedbackStatusDTO updateFeedbackStatusDTO)
        {
            bool updatedStatus = feedbackService.UpdateStatus(updateFeedbackStatusDTO.Id, updateFeedbackStatusDTO.Approved);
            return Ok(updatedStatus);
        }

        /// <summary>
        /// POST method for posting feedback
        /// </summary>
        /// <param name="postFeedbackDTO"></param>
        /// <returns>returns string message which tells whether posting feedback was successful or not</returns>
        [HttpPost("createFeedback")]
        public IActionResult Post(PostFeedbackDTO postFeedbackDTO)
        {
            if(postFeedbackDTO.AdditionalNotes.Length <= 0)
            {
                return BadRequest("Failed to post feedback");
            }

            FeedbackService feedbackService = new FeedbackService();
            bool feedbackSuccessfullyCreated = feedbackService.CreateFeedback(postFeedbackDTO.UserId, postFeedbackDTO.AdditionalNotes, postFeedbackDTO.Anonymous, postFeedbackDTO.AllowedForPublishing);

            if (!feedbackSuccessfullyCreated)
            {
                return BadRequest("Failed to post feedback");
            }
            return Ok("Feedback posted successfully");
        }
    }
}
