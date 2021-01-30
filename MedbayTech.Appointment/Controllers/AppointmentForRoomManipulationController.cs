using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Application.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentForRoomManipulationController : Controller
    {
        private IAppointmentForRoomManipulationService _appointmentForRoomManipulationService;

        public AppointmentForRoomManipulationController(IAppointmentForRoomManipulationService appointmentRenovationService)
        {
            _appointmentForRoomManipulationService = appointmentRenovationService;
        }

        [HttpGet("{roomId?}")]
        public IActionResult Get(string roomId)
        {
            return Ok(_appointmentForRoomManipulationService.GetAllForRoom(Int32.Parse(roomId)));
        }

        [HttpPost]
        public IActionResult Post(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.UpdateRealocation)
            {
                return Ok(_appointmentForRoomManipulationService.Update(appointmentRealocationDTO.appointmentForRoomManipulation));
            }
            else return Ok();
        }
    }
}
