using Backend.Rooms.Service;
using Backend.Users.Service.Enum;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphicEditorWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoctorController : Controller
    {
        private IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{textBoxSearch?}/{doctorSearch?}")]
        public IActionResult Get(string textBoxSearch, DoctorSearch doctorSearch)
        {
            if (doctorSearch == DoctorSearch.All)
            {
                return Ok(_doctorService.GetAll());
            }
            else if(doctorSearch == DoctorSearch.ByExaminationRoom)
            {
                if (Int32.TryParse(textBoxSearch, out int id))
                {
                    return Ok(_doctorService.GetDoctorByRoomExaminationRoom(id));
                }
                else return Ok();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult Post(Doctor doctor)
        {
            return Ok(_doctorService.UpdateDoctorDataBase(doctor));
        }
    }
}
