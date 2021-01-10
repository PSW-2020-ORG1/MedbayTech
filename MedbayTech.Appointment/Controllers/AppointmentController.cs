using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces.Service;
using Application.DTO;
using Application.Mappers;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Application.Enums;
using MedbayTech.Appointment.Application.Validators;
using MedbayTech.Appointment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IAppointmentService _appointmentService;
     
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("cancelableAppointments/{userId}")]
        public IActionResult GetAppointmentsBy(string userId)
        {
            userId = User.Identity.Name;
            return Ok(_appointmentService.GetCancelableAppointments(userId));
        }

        
        [HttpGet("allAppointments")]
        public IActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("allSurveyableAppointments")] 
        public IActionResult GetSurveyableAppointments()
        {
            string id = User.Identity.Name;
            List<Appointment> appointments = _appointmentService.GetSurveyableAppointments(id);
            List<GetAppointmentDTO> appointmentsDTO = AppointmentMapper.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("allOtherAppointments")] 
        public IActionResult GetAllOtherAppointments()
        {
            string id = User.Identity.Name;
            List<Appointment> appointments = _appointmentService.GetAllOtherAppointments(id);
            List<GetAppointmentDTO> appointmentsDTO = AppointmentMapper.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("allCancelableAppointments")] 
        public IActionResult GetCancelableAppointments()
        {
            string id = User.Identity.Name;
            List<Appointment> appointments = _appointmentService.GetCancelableAppointments(id);
            List<GetAppointmentDTO> appointmentsDTO = AppointmentMapper.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("cancelAppointment")]
        public IActionResult CancelAppointment(CancelAppointmentDTO cancelAppointmentDTO)
        {
            bool canceledAppointment = _appointmentService.UpdateCanceled(cancelAppointmentDTO.AppointmentId);
            return Ok(canceledAppointment);
        }
   
        public IActionResult Get()
        {
            List<Appointment> appointments = _appointmentService.InitializeAppointments("2406978890047", new DateTime(2020, 12, 5));
            List<AvailableAppointmentsDTO> dto = AppointmentMapper.AppointmentsToAvailableAppointmentsDTO(appointments);
            return Ok(dto);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("available")]
        public IActionResult GetAvailable(SearchAppointmentsStandardDTO appointmentsDTO)
        {
            List<Appointment> appointments = _appointmentService.GetAvailableBy(appointmentsDTO.DoctorId, appointmentsDTO.Date).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentMapper.AppointmentsToAvailableAppointmentsDTO(appointments);
            return Ok(dto);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("availableStrategy")]
        public IActionResult GetAvailable2(SearchAppointmentsDTO appoitmentsDTO)
        {
            PriorityParameters parameters =
                AppointmentMapper.SearchAppointmentsDTOToPriorityParameters(appoitmentsDTO);
            List<Appointment> appointments = _appointmentService.GetAvailableByStrategy(parameters).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentMapper.AppointmentsToAvailableAppointmentsDTOWithDoctor(appointments);
            return Ok(dto);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("schedule")]
        public IActionResult Schedule(ScheduleAppointmentDTO dto)
        {
            try
            {
                ValidateScheduleAppointment.Validate(dto);
            } catch(Exception)
            {
                return BadRequest("Can not schedule appointmnet in the past");
            }

            dto.PatientId = User.Identity.Name;

            Appointment appointment = AppointmentMapper.ScheduleAppointmentDTOToAppointment(dto);
            appointment.PatientId = dto.PatientId;
            Appointment scheduledAppointment = _appointmentService.ScheduleAppointment(appointment);
            
            if (scheduledAppointment == null)
                return BadRequest("Can not schedule appointment");
            
            return Ok("Scheduled!");
        }

        [HttpGet("{roomId?}/{appointmentSearchOrSchedule?}")]
        public IActionResult GetByRoom(string roomId, AppointmentSearchOrSchedule appointmentSearchOrSchedule)
        {
            if (appointmentSearchOrSchedule == AppointmentSearchOrSchedule.ByRoom)
            {
                return Ok(_appointmentService.GetApppointmentsScheduledForSpecificRoom(Int32.Parse(roomId)));
            }
            else return Ok();
        }

        [HttpPost("apointmentsBySearchOrSchedule")]
        public IActionResult GetBySearchOrSchedule(AppointmentFilterDTO appointmentFilterDTO)
        {
            if (appointmentFilterDTO.AppointmentSearchOrSchedule == AppointmentSearchOrSchedule.ByDoctorAndTimeInterval)
            {
                return Ok(_appointmentService.GetAvailableByDoctorAndTimeInterval(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }));
            }
            else if (appointmentFilterDTO.AppointmentSearchOrSchedule == AppointmentSearchOrSchedule.ByDoctorPriority)
            {
                return Ok(_appointmentService.GetAvailableByPriorityDoctor(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }));
            }
            else if (appointmentFilterDTO.AppointmentSearchOrSchedule == AppointmentSearchOrSchedule.ScheduleAppointment)
            {
                return Ok(_appointmentService.ScheduleAppointment(appointmentFilterDTO.Appointment));
            }
            else if (appointmentFilterDTO.AppointmentSearchOrSchedule == AppointmentSearchOrSchedule.UpdateAppointment)
            {
                return Ok(_appointmentService.UpdateSuggestedAppointment(appointmentFilterDTO.Appointment));
            }
            else return Ok();
        }
    }
}
