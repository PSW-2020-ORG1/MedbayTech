using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.Model;
using Backend.Users.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorWorkDayController : ControllerBase
    {
        IDoctorWorkDayService _doctorWorkDayService;

        public DoctorWorkDayController(IDoctorWorkDayService doctorWorkDayService)
        {
            _doctorWorkDayService = doctorWorkDayService;
        }
       
        [HttpGet]
        public IActionResult GetAll()
        {
            List<DoctorWorkDay> doctorWorkDays = _doctorWorkDayService.GetAll().ToList();
            return Ok(doctorWorkDays.Count);

        }

    }
}
