using Backend.Rooms.Service;
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

        [HttpGet("{textBoxSearch?}/{operation}")]
        public IActionResult Get(string textBoxSearch, int operation)
        {
            if (operation == 0)
            {
                return Ok();
            }
            else
            {
                if (Int32.TryParse(textBoxSearch, out int id))
                {
                    return Ok(_doctorService.GetDoctorByRoomExaminationRoom(id));
                }
                else return Ok();
            }
        }

        [HttpPost]
        public IActionResult Post(Doctor doctor)
        {
            return Ok(_doctorService.UpdateDoctorDataBase(doctor));
        }
    }
}
