using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Users;
using Repository;
using Repository.GeneralRepository;
using WebApplication.DTO;
using WebApplicationService.GeneralService;
using WebApplication.Adapters;

namespace WebApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
       

        public FeedbackController()
        {
            
        }

        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {

            FeedbackService feedbackService = new FeedbackService();


            List<Feedback> approvedFeedback = feedbackService.GetAllApprovedFeedback().ToList();
            List<ApprovedFeedbackDTO> approvedFeedbackDTOs = FeedbackAdapter.ListApprovedFeedbackToListApprovedFeedbackDTO(approvedFeedback);

            
            return Ok(approvedFeedbackDTOs);
        }
    }


}
