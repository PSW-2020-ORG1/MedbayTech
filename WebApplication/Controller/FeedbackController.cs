using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.ExaminationSurgery;
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

        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {

            


            List<Feedback> approvedFeedback = feedbackService.GetAllApprovedFeedback().ToList();
            List<ApprovedFeedbackDTO> approvedFeedbackDTOs = FeedbackAdapter.ListApprovedFeedbackToListApprovedFeedbackDTO(approvedFeedback);

            
            return Ok(approvedFeedbackDTOs);
        }

        [HttpGet("allFeedback")]
        public IActionResult GetAllFeedback() {

            List<Feedback> allFeedback = feedbackService.GetAll().ToList();
            List<AllFeedbackDTO> allFeedbackDTOs = FeedbackAdapter.ListAllFeedbackToListAllFeedbackDTO(allFeedback);

            return Ok(allFeedbackDTOs);


        }

        [HttpPost("updateFeedbackStatus")]
        public IActionResult UpdateFeedbackStatus(UpdateFeedbackStatusDTO updateFeedbackStatusDTO)
        {
            bool updatedStatus = feedbackService.UpdateStatus(updateFeedbackStatusDTO.Id, updateFeedbackStatusDTO.Approved);
            return Ok(updatedStatus);
        }
    }


}
