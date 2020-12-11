﻿using System;
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
using WebApplication.Validators;

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

        /*
        [HttpGet] //GET api/Appointment
        public IActionResult Get()
        {
            List<Appointment> appointments = _appointmentService.GetAppointmentsByPatientId("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentAdapter.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }*/

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
   
        public IActionResult Get()
        {
            List<Appointment> appointments = _appointmentService.InitializeAppointments("2406978890047", new DateTime(2020, 12, 5));
            List<AvailableAppointmentsDTO> dto = AppointmentAdapter.Transform(appointments);
            return Ok(dto);
        }

        [HttpPost("available")]
        public IActionResult GetAvailable(SearchAppointmentsStandardDTO appointmentsDTO)
        {
            List<Appointment> appointments = _appointmentService.GetAvailableBy(appointmentsDTO.DoctorId, appointmentsDTO.Date).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentAdapter.Transform(appointments);
            return Ok(dto);
        }

        [HttpPost("availableStrategy")]
        public IActionResult GetAvailable2(SearchAppointmentsDTO appoitmentsDTO)
        {
            List<Appointment> appointments = _appointmentService.GetAvailableByDoctorAndDateRange(appoitmentsDTO.DoctorId, appoitmentsDTO.StartInterval, appoitmentsDTO.EndInterval).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentAdapter.Transform(appointments);
            return Ok(dto);
        }

        [HttpPost("schedule")]
        public IActionResult Schedule(ScheduleAppointmentDTO dto)
        {

            try
            {
                ValidateScheduleAppointment.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            dto.PatientId =  "2406978890046";

            MedicalRecord medicalRecord = _mediaRecordService.GetMedicalRecordByPatientId(dto.PatientId);
            
            if (medicalRecord == null)
                return BadRequest("Can not schedule appointment");

            Appointment appointment = AppointmentAdapter.ScheduleAppointmentDTOToAppointment(dto);
            appointment.MedicalRecordId = medicalRecord.Id;
            Appointment scheduledAppointment = _appointmentService.ScheduleAppointment(appointment);
            
            if (scheduledAppointment == null)
                return BadRequest("Can not schedule appointment");
            
            return Ok("Scheduled!");
        }
    }
}
