using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Rooms.Service;
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

        private IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet("searchDoctor")]
        public IActionResult GetAll()
        {
            List<Doctor> doctors = _doctorService.GetAll().ToList();
            List<DoctorSearchDTO> doctorSearchList = DoctorAdapter.ListDoctorToListDoctorSearchDTO(doctors);
            return Ok(doctorSearchList);

        }

        [HttpGet("specialization/{specializationId}")]
        public IActionResult GetDoctorsBySpecialization(int specializationId)
        {
            List<Doctor> doctors = _doctorService.GetDoctorsBy(specializationId).ToList();
            List<DoctorSearchDTO> doctorSearchList = DoctorAdapter.ListDoctorToListDoctorSearchDTO(doctors);
            return Ok(doctorSearchList);

        }
    }
}
