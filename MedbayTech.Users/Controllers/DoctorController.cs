using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_doctorService.GetAll());
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetBy(string id)
        {
            return Ok(_doctorService.GetDoctorBy(id));
        }

        [HttpGet("getByRoom/{id}")]
        public IActionResult GetBy(int roomId)
        {
            return Ok(_doctorService.GetDoctorByExaminationRoom(roomId));
        }



    }
}
