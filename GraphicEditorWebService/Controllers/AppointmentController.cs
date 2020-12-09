using Backend.Schedules.Service.Interfaces;
using Backend.Utils.DTO;
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

    public class AppointmentController : Controller
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{roomId?}/{operation?}")]
        public IActionResult Get(string roomId, int operation)
        {
            if (operation == 0)
            {
                return Ok(_appointmentService.GetApppointmentsScheduledForSpecificRoom(Int32.Parse(roomId)));
            }
            else
            {
                return Ok();
            }

        }
        [HttpPost]
        public IActionResult Post(SearchAppointmentsDTO searchAppointmentsDTO)
        {
            if(searchAppointmentsDTO.operation == 0)
            {
                return Ok(_appointmentService.GetAvailableByDoctorAndTimeInterval(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval));
            }
            else if(searchAppointmentsDTO.operation == 1)
            {
                return Ok(_appointmentService.GetAvailableByPriorityDoctor(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval));
            }
            else if(searchAppointmentsDTO.operation == 2)
            {
                return Ok(_appointmentService.GetAvailableByPriorityTimeInterval(searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval));
            }
            else if(searchAppointmentsDTO.operation == 3 && searchAppointmentsDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentService.GetAvailableByDoctorTimeIntervalAndEquipment(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.HospitalEquipmentId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval, "nopriority"));
            }
            else if (searchAppointmentsDTO.operation == 4 && searchAppointmentsDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentService.GetAvailableByDoctorTimeIntervalAndEquipment(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.HospitalEquipmentId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval, "doctor"));
            }
            else if(searchAppointmentsDTO.operation == 5 && searchAppointmentsDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentService.GetAvailableByDoctorTimeIntervalAndEquipment(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.HospitalEquipmentId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval, "timeinterval"));
            }
            else
            {
                return Ok(_appointmentService.ScheduleAppointment(searchAppointmentsDTO.appointment));
            }
        }
    }
}
