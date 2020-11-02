using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.ExaminationSurgery;
using Model.Users;

namespace WebApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly MySqlContext mySqlContext;

        public FeedbackController(MySqlContext context)
        {
            this.mySqlContext = context;
        }

        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {
            RegisteredUser registeredUser =
                mySqlContext.RegisteredUsers.FirstOrDefault(registeredUser =>
                    registeredUser.Id.Equals("2406978890045"));

            City city = registeredUser.CurrResidence.City;

            Feedback feedback = mySqlContext.Feedbacks.FirstOrDefault();
            LabTesting labTesting = mySqlContext.LabTestings.FirstOrDefault();

            return Ok(feedback);
        }
    }


}
