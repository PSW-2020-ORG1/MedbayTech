using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces.Service;
using Application.DTO;
using Application.Mappers;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Application.Validators;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Infrastructure.Services.AppointmentSearchOrSchedule;
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

        [HttpGet("cancelableAppointments/{userId}")]
        public IActionResult GetAppointmentsBy(string userId)
        {
            return Ok(_appointmentService.GetCancelableAppointments(userId));
        }

        [HttpGet("allAppointments")]
        public IActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }
        [HttpGet("allSurveyableAppointments")] 
        public IActionResult GetSurveyableAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetSurveyableAppointments("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentMapper.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [HttpGet("allOtherAppointments")] 
        public IActionResult GetAllOtherAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetAllOtherAppointments("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentMapper.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

        [HttpGet("allCancelableAppointments")] 
        public IActionResult GetCancelableAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetCancelableAppointments("2406978890046");
            List<GetAppointmentDTO> appointmentsDTO = AppointmentMapper.ListAppointmentToListGetAppointmentDTO(appointments);
            return Ok(appointmentsDTO);
        }

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

        [HttpPost("available")]
        public IActionResult GetAvailable(SearchAppointmentsStandardDTO appointmentsDTO)
        {
            List<Appointment> appointments = _appointmentService.GetAvailableBy(appointmentsDTO.DoctorId, appointmentsDTO.Date).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentMapper.AppointmentsToAvailableAppointmentsDTO(appointments);
            return Ok(dto);
        }

        [HttpPost("availableStrategy")]
        public IActionResult GetAvailable2(SearchAppointmentsDTO appoitmentsDTO)
        {
            PriorityParameters parameters =
                AppointmentMapper.SearchAppointmentsDTOToPriorityParameters(appoitmentsDTO);
            List<Appointment> appointments = _appointmentService.GetAvailableByStrategy(parameters).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentMapper.AppointmentsToAvailableAppointmentsDTOWithDoctor(appointments);
            return Ok(dto);
        }

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

            dto.PatientId = "2406978890046";

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
            else return Ok();
        }
    }
}
