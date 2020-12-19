using Backend.Schedules.Service.Enum;
using Backend.Schedules.Service.Interfaces;
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using Service.ScheduleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphicEditorWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentController : Controller
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{roomId?}/{appointmentSearchOrSchedule?}")]
        public IActionResult Get(string roomId, AppointmentSearchOrSchedule appointmentSearchOrSchedule)
        {
            if (appointmentSearchOrSchedule == AppointmentSearchOrSchedule.ByRoom)
            {
                return Ok(_appointmentService.GetApppointmentsScheduledForSpecificRoom(Int32.Parse(roomId)));
            }
            else return Ok();
        }
        [HttpPost]
        public IActionResult Post(AppointmentFilterDTO appointmentFilterDTO)
        {
            if (appointmentFilterDTO.appointmentSearchOrSchedule == AppointmentSearchOrSchedule.ByDoctorAndTimeInterval)
            {
                return Ok(_appointmentService.GetAvailableByDoctorAndTimeInterval(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }));
            }
            else if (appointmentFilterDTO.appointmentSearchOrSchedule == AppointmentSearchOrSchedule.ByDoctorPriority)
            {
                return Ok(_appointmentService.GetAvailableByPriorityDoctor(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }));
            }
            else if (appointmentFilterDTO.appointmentSearchOrSchedule == AppointmentSearchOrSchedule.ScheduleAppointment)
            {
                return Ok(_appointmentService.ScheduleAppointment(appointmentFilterDTO.appointment));
            }
            else return Ok();
        }
    }
}
