using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Application.Mappers;
using MedbayTech.Appointment.Domain.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IAppointmentEventService _appointmentEventService;

        public EventController(IAppointmentEventService appointmentEventService)
        {
            _appointmentEventService = appointmentEventService;
        }

        [HttpPost("save")]
        public IActionResult Create(AppointmnetEventDTO dto)
        {
            AppointmentEvent appointmentEvent = AppointmentEventMapper.AppointmnetEventToAppointmnentEventDTO(dto);
            return Ok(_appointmentEventService.CreateEvent(appointmentEvent));
        }

        [HttpGet("getCreatedCount")]
        public IActionResult GetCreatedCount()
        {
            return Ok(_appointmentEventService.GetCreatedAppointments());
        }

        [HttpGet("getAverageSchedulingTime")]
        public IActionResult GetAverageSchedulingTime()
        {
            return Ok(_appointmentEventService.GetAverageSchedulingTime());
        }

        [HttpGet("getAverageTimeFromStartedToSpecialization")]
        public IActionResult GetAverageTimeFromStartedToSpecialization()
        {
            return Ok(_appointmentEventService.GetAverageTimeFromStartedToSelectSpecialization());
        }

        [HttpGet("getAverageTimeFromSpecializationToDoctor")]
        public IActionResult GetAverageTimeFromSpecializationToDoctor()
        {
            return Ok(_appointmentEventService.GetAverageTimeFromSelectSpecializationToSelectDoctor());
        }

        [HttpGet("getAverageTimeFromDoctorToSelectAppointment")]
        public IActionResult GetAverageTimeFromDoctorToSelectAppointment()
        {
            return Ok(_appointmentEventService.GetAverageTimeFromDoctorToSelectAppointment());
        }

        [HttpGet("getCountOfBackStep")]
        public IActionResult GetCountOfBackStep()
        {
            return Ok(_appointmentEventService.GetCountOfBackStep());
        }

        [HttpGet("getCountOfQuit")]
        public IActionResult GetCountOfQuit()
        {
            return Ok(_appointmentEventService.GetCountOfQuit());
        }

        [HttpGet("getPercentSuccessfulAndQuit")]
        public IActionResult GetPercentSuccessfullAndQuit()
        {
            return Ok(_appointmentEventService.GetPercentSuccessfullAndQuit());
        }

        [HttpGet("getAverageNumberOfStepsForSuccessful")]
        public IActionResult GetAverageNumberOfStepsForSuccessful()
        {
            return Ok(_appointmentEventService.GetAverageNumberOfStepsForSuccessful());
        }
    }
}
