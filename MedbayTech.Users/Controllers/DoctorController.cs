using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mapper;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("getByRoom/{id}")]
        public IActionResult GetBy(int id)
        {
            return Ok(_doctorService.GetDoctorByExaminationRoom(id));
        }

        [HttpGet("specialization/{name}")]
        public IActionResult GetBySpecialization(string name)
        {
            List<Doctor> doctors = _doctorService.GetDoctorsBy(name).ToList();
            List<DoctorSearchDTO> doctorSearchList = DoctorMapper.ListDoctorToListDoctorSearchDTO(doctors);
            return Ok(doctorSearchList);
        }



    }
}
