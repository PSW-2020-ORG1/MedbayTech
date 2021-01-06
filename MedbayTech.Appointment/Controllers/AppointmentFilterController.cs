using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Post(AppointmentFilterDTO appointmentFilterDTO)
        {
            if (appointmentFilterDTO.appointmentFilterCriteria == AppointmentFilterCriteria.ByTimeIntervalPriority)
            {
                return Ok(_appointmentFilterService.GetAvailableByPriorityTimeInterval(new PriorityParameters { ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }));
            }
            else if (appointmentFilterDTO.appointmentFilterCriteria == AppointmentFilterCriteria.BySpecialistNoPriority && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }, appointmentFilterDTO.HospitalEquipmentId, "nopriority"));
            }
            else if (appointmentFilterDTO.appointmentFilterCriteria == AppointmentFilterCriteria.BySpecialistDoctorPriority && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }, appointmentFilterDTO.HospitalEquipmentId, "doctor"));
            }
            else if (appointmentFilterDTO.appointmentFilterCriteria == AppointmentFilterCriteria.BySpecialistTimePriority && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = appointmentFilterDTO.DoctorId, ChosenStartDate = appointmentFilterDTO.StartInterval, ChosenEndDate = appointmentFilterDTO.EndInterval }, appointmentFilterDTO.HospitalEquipmentId, "timeinterval"));
            }
            else if (appointmentFilterDTO.appointmentFilterCriteria == AppointmentFilterCriteria.AddRoomToAppointment)
            {
                return Ok(_appointmentFilterService.AddRoomToAppointment(appointmentFilterDTO.appointments));
            }
            else return Ok();
        }
    }
}
