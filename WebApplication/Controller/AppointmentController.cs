using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Records.Model;
using Backend.Records.Service.Interfaces;
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
        IAppointmentService _appointmentService;
        private IMedicalRecordService _mediaRecordService;
        public AppointmentController(IAppointmentService appointmentService, IMedicalRecordService mediaRecordService)
        {
            _appointmentService = appointmentService;
            _mediaRecordService = mediaRecordService;
        }
        public IActionResult Get()
        {
            List<Appointment> appointments = _appointmentService.InitializeAppointments("2406978890047", new DateTime(2020, 12, 5));
            List<AvailableAppointmentsDTO> dto = AppointmentAdapter.Transform(appointments);
            return Ok(dto);
        }

        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            List<Appointment> appointments = _appointmentService.GetByDoctorAndDate("2406978890047", new DateTime(2020, 12, 5)).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentAdapter.Transform(appointments);
            return Ok(dto);
        }

        [HttpGet("available2")]
        public IActionResult GetAvailable2()
        {
            List<Appointment> appointments = _appointmentService.GetAvailableByDoctorAndDateRange("2406978890047", new DateTime(2020, 12, 5), new DateTime(2020, 12, 9)).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentAdapter.Transform(appointments);
            return Ok(dto);
        }

        [HttpGet("schedule")]
        public IActionResult Schedule()
        {
            MedicalRecord medicalRecord = _mediaRecordService.GetMedicalRecordByPatientId("2406978890046");
            if (medicalRecord == null)
                return BadRequest();

            Appointment appointment = new Appointment
            {
                DoctorId = "2406978890047",
                Start =  new DateTime(2020, 12, 9, 18, 30, 0),
                End = new DateTime(2020, 12, 9, 19, 0, 0),
                MedicalRecordId =  medicalRecord.Id,
                RoomId = 1
            };
            Appointment ap = _appointmentService.ScheduleAppointment(appointment);
            if (ap == null)
            {
                return BadRequest("Can not schedule exam");
            }
            return Ok("Scheduled!");
        }
    }
}
