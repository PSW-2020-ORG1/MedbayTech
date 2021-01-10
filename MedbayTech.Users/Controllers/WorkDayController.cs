using MedbayTech.Common.Application.DTO;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDayController : ControllerBase
    {
        private readonly IWorkDayService _workDayService;

        public WorkDayController(IWorkDayService workDayService)
        {
            _workDayService = workDayService;
        }

        [HttpPost]
        public IActionResult GetByDoctorsIdAndDate(WorkDayDTO dto)
        {
            return Ok(_workDayService.GetByDoctorIdAndDate(dto.DoctorId, dto.Date));
        }
    }
}
