using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Feedback.Infrastructure.Gateways;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedbayTech.Feedback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {

        private readonly UserGateway _restClient;

        public Users()
        {
            _restClient = new UserGateway();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_restClient.GetUsers());
        }

    }
}
