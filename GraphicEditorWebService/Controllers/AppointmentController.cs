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

        [HttpGet("{doctorId?}/{operation?}")]
        public IActionResult Get(string doctorId, int operation)
        {
            if(operation == 0)
            {
                //return Ok(_appointmentService.GetAvailableByDoctorAndTimeInterval(doctorId, new DateTime(2020, 12, 9, 9, 30, 0), new DateTime(2020, 12, 9, 12, 30, 0)));
                //return Ok(_appointmentService.GetAvailableByPriorityDoctor(doctorId, new DateTime(2020, 12, 7, 9, 30, 0), new DateTime(2020, 12, 7, 12, 30, 0)));
                //return Ok(_appointmentService.GetAvailableByPriorityTimeInterval(new DateTime(2020, 12, 7, 9, 30, 0), new DateTime(2020, 12, 7, 12, 30, 0)));
                return Ok(_appointmentService.GetAvailableByDoctorTimeIntervalAndEquipment(doctorId,9, new DateTime(2020, 12, 7, 9, 30, 0), new DateTime(2020, 12, 7, 12, 30, 0),"doctor"));
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
