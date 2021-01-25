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
    public class AppointmentRenovationController : Controller
    {
        private IAppointmentRenovationService _appointmentRenovationService;

        public AppointmentRenovationController(IAppointmentRenovationService appointmentRenovationService)
        {
            _appointmentRenovationService = appointmentRenovationService;
        }

        [HttpGet("{roomId?}")]
        public IActionResult Get(string roomId)
        {
            return Ok(_appointmentRenovationService.GetAppointmentRenovationsByRoomId(Int32.Parse(roomId)));
        }

        [HttpPost]
        public IActionResult Post(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.ByRoomAndDateTime)
            {
                return Ok(_appointmentRenovationService.GetAllAvailableAppointmentByRoomAndDateTime(appointmentRealocationDTO.RoomId, appointmentRealocationDTO.StartInterval, appointmentRealocationDTO.EndInterval));
            }
            else if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation)
            {
                return Ok(_appointmentRenovationService.ScheduleAppointmentRenovation(appointmentRealocationDTO.appointmentRenovation));
            }
            else if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.UpdateRealocation)
            {
                return Ok(_appointmentRenovationService.UpdateAppointement(appointmentRealocationDTO.appointmentRenovation));
            }
            else if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.ByTwoRooms)
            {
                return Ok(_appointmentRenovationService.GetAvailableAppointmentRenovationsForTwoRoms(appointmentRealocationDTO.FromRoomId, appointmentRealocationDTO.ToRoomId, appointmentRealocationDTO.StartInterval, appointmentRealocationDTO.EndInterval));
            }
            else return Ok();
        }

    }
}
