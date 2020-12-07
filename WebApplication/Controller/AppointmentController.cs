using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Schedules.Service.Interfaces;
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Schedule;
using WebApplication.Adapters;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet] //GET api/Appointment
        public IActionResult GetSurveyableAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetSurveyableAppointments("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentAdapter.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);

        }
    }
}
