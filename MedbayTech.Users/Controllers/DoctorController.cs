using MedbayTech.Users.Application.Common.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_doctorService.GetDoctorsBy(name));
        }



    }
}
