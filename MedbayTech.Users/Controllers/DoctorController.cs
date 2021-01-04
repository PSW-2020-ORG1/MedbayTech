using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Infrastructure.Service.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MedbayTech.Users.Domain.Entites;

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

        [HttpGet("{textBoxSearch?}/{doctorSearch?}")]
        public IActionResult Get(string textBoxSearch, DoctorSearch doctorSearch)
        {
            if (doctorSearch == DoctorSearch.All)
            {
                return Ok(_doctorService.GetAll());
            }
            else if (doctorSearch == DoctorSearch.ByExaminationRoom)
            {
                if (Int32.TryParse(textBoxSearch, out int id))
                {
                    return Ok(_doctorService.GetDoctorByExaminationRoom(id));
                }
                else return Ok();
            }
            else
            {
                return Ok();
            }
        }



    }
}
