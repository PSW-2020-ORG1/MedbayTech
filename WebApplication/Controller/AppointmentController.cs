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
        public IActionResult Get()
        {
            List<Appointment> appointments = _appointmentService.GetAppointmentsByPatientId("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentAdapter.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [HttpGet("allSurveyableAppointments")] //GET api/Appointment
        public IActionResult GetSurveyableAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetSurveyableAppointments("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentAdapter.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [HttpGet("allOtherAppointments")] //GET api/Appointment
        public IActionResult GetAllOtherAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetAllOtherAppointments("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentAdapter.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [HttpGet("allCancelableAppointments")] //GET api/Appointment
        public IActionResult GetCancelableAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetCancelableAppointments("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentAdapter.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [HttpPost("cancelAppointment")]
        public IActionResult cancelAppointment(CancelAppointmentDTO cancelAppointmentDTO)
        {
            bool canceledAppointment = _appointmentService.UpdateCanceled(cancelAppointmentDTO.AppointmentId);
            return Ok(canceledAppointment);
        }
    }
}
