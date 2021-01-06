using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Application.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentFilterController : ControllerBase
    {
        private IAppointmentFilterService _appointmentFilterService;

        public AppointmentFilterController(IAppointmentFilterService appointmentFilterService)
        {
            _appointmentFilterService = appointmentFilterService;
        }

        [HttpPost]
        public IActionResult GetAppointmentsByFilterCriteria(AppointmentFilterDTO appointmentFilterDTO)
        {
            if (appointmentFilterDTO.AppointmentFilterCriteria == AppointmentFilterCriteria.ByTimeIntervalPriority)
            {
                return Ok(_appointmentFilterService.GetAvailableByPriorityTimeInterval(new PriorityParameters { ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }));
            }
            else if (appointmentFilterDTO.AppointmentFilterCriteria == AppointmentFilterCriteria.BySpecialistNoPriority && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }, appointmentFilterDTO.HospitalEquipmentId, "nopriority"));
            }
            else if (appointmentFilterDTO.AppointmentFilterCriteria == AppointmentFilterCriteria.BySpecialistDoctorPriority && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }, appointmentFilterDTO.HospitalEquipmentId, "doctor"));
            }
            else if (appointmentFilterDTO.AppointmentFilterCriteria == AppointmentFilterCriteria.BySpecialistTimePriority && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }, appointmentFilterDTO.HospitalEquipmentId, "timeinterval"));
            }
            else if (appointmentFilterDTO.AppointmentFilterCriteria == AppointmentFilterCriteria.AddRoomToAppointment)
            {
                return Ok(_appointmentFilterService.AddRoomToAppointment(appointmentFilterDTO.Appointments));
            }
            else return Ok();
        }
    }
}
