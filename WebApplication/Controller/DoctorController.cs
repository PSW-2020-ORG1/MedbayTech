using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.WebApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;
using WebApplication.DTO;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private WebDoctorController doctorController;
        public DoctorController()
        {
            this.doctorController = new WebDoctorController();
        }
        [HttpGet("searchDoctor")]
        public IActionResult GetAll()
        {
            List<Doctor> doctors = doctorController.GetAll().ToList();
            List<DoctorSearchDTO> doctorSearchList = DoctorAdapter.ListDoctorToListDoctorSearchDTO(doctors);
            return Ok(doctorSearchList);

        }
    }
}
