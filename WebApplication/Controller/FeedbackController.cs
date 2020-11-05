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
using WebApplicationService.GeneralService;

namespace WebApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly MySqlContext mySqlContext;

        public FeedbackController()
        {
            
        }

        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {
           /* RegisteredUser registeredUser =
                mySqlContext.RegisteredUsers.FirstOrDefault(registeredUser =>
                    registeredUser.Id.Equals("2406978890045"));

            City city = registeredUser.CurrResidence.City;

            Feedback feedback = mySqlContext.Feedbacks.FirstOrDefault();*/

            
            UnitOfWork uo = new UnitOfWork();
            Feedback feedback = uo.FeedBackRepository.GetObject(1);
            /*uo.FeedBackRepository.UpdateStatus(1, true);
            uo.Save();*/

            
            /*uo.FeedBackRepository.UpdateStatus(1, false);
            Feedback feedback2 = uo.FeedBackRepository.GetObject(1);
            RegisteredUser registeredUser = feedback2.RegisteredUser;
            Feedback newFeedback = new Feedback { Id = 2, Approved = false, Date = new DateTime(), AdditionalNotes = "Web sajt je super!", RegisteredUserId = registeredUser.Id };

            uo.FeedBackRepository.Create(newFeedback);
            uo.Save();
            Feedback feedbackToUpdate = uo.FeedBackRepository.GetObject(2);
          
            feedbackToUpdate.AdditionalNotes = "Web sajt je super";

            Feedback feedbackToDelete = new Feedback { Id = 23};
            

            List<Feedback> feedbacks = uo.FeedBackRepository.GetAll().ToList();*/


            

            FeedbackService service = new FeedbackService();

            service.UpdateStatus(1, true);

            

            List<Feedback> approvedFeedbacks = service.GetAllApprovedFeedback().ToList();

            

            

            
            return Ok(approvedFeedbacks);
        }
    }


}
