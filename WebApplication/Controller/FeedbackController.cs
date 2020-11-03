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
            Feedback fb = uo.FeedBackRepository.GetObject(1);
            return Ok(fb);
        }
    }


}
