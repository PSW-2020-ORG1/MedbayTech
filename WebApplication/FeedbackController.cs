using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
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
            List<Feedback> result = new List<Feedback>();
            mySqlContext.Feedbacks.ToList().ForEach(feedback  => result.Add(feedback));
            return Ok(result);
        }
    }


}
