using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Infrastructure.Service.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mapper;
using System.Collections.Generic;
using System.Linq;
using MedbayTech.Users.Domain.Entites;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("getAllDoctors")]
        public IActionResult GetDoctors()
        {
            return Ok(_doctorService.GetAll());
        }

        [HttpGet("getByRoom/{id}")]
        public IActionResult GetBy(int id)
        {
            return Ok(_doctorService.GetDoctorByExaminationRoom(id));
        }

        [HttpGet("specialization/{id}")]
        public IActionResult GetBySpecialization(int id)
        {
            List<Doctor> doctors = _doctorService.GetDoctorBySpecialization(id).ToList();
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

        
        [HttpGet("searchDoctor")]
        public IActionResult GetAll()
        {
            List<Doctor> doctors = _doctorService.GetAll().ToList();
            List<DoctorSearchDTO> doctorSearchList = DoctorMapper.ListDoctorToListDoctorSearchDTO(doctors);
            return Ok(doctorSearchList);


        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(string id)
        {
            return Ok(_doctorService.GetDoctorBy(id));
        }

    }
}
