using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.DTO;
using WebApplication.Adapters;
using Backend.Users.WebApiController;
using Backend.Users.WebApiService;

namespace WebApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private WebFeedbackController feedbackController;
        public FeedbackController()
        {
            feedbackController = new WebFeedbackController();
        }
        /// <summary>
        /// GET method for feedback that is approved by the system administrator
        /// </summary>
        /// <returns>list of approved feedback</returns>
        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {
            List<Feedback> approvedFeedback = feedbackController.GetAllApprovedFeedback().ToList();
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
            /*List<Feedback> allFeedback = feedbackService.GetAll().ToList();
            List<AllFeedbackDTO> allFeedbackDTOs = FeedbackAdapter.ListAllFeedbackToListAllFeedbackDTO(allFeedback);*/
            List<Feedback> allFeedback = feedbackController.GetAll().ToList();
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
            //bool updatedStatus = feedbackService.UpdateStatus(updateFeedbackStatusDTO.Id, updateFeedbackStatusDTO.Approved);
            bool updatedStatus = feedbackController.UpdateStatus(updateFeedbackStatusDTO.Id, updateFeedbackStatusDTO.Approved);
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

           
            Feedback feedbackSuccessfullyCreated = feedbackController.CreateFeedback(postFeedbackDTO.UserId, postFeedbackDTO.AdditionalNotes, postFeedbackDTO.Anonymous, postFeedbackDTO.AllowedForPublishing);


            if (feedbackSuccessfullyCreated==null)
            {
                return BadRequest("Failed to post feedback");
            }
            return Ok("Feedback posted successfully");
        }
    }
}
