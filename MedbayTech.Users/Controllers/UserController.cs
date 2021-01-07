
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MedbayTech.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService; 

        public UserController(IUserService userService, IPatientService patientService)
        {
            _userService = userService;
            _patientService = patientService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetBy(string id)
        {
            return Ok(_userService.GetBy(id));
        }

        [HttpGet("getAllPatients")]
        public IActionResult GetAllPatinets()
        {
            return Ok(_patientService.GetAll());
        }

    }
}
