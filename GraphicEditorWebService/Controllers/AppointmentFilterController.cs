using Backend.Schedules.Service.Interfaces;
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphicEditorWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentFilterController : Controller
    {
        private IAppointmentFilterService _appointmentFilterService;

        public AppointmentFilterController(IAppointmentFilterService appointmentFilterService)
        {
            _appointmentFilterService = appointmentFilterService;
        }

        [HttpPost]
        public IActionResult Post(SearchAppointmentsDTO searchAppointmentsDTO)
        {
            if (searchAppointmentsDTO.operation == 2)
            {
                return Ok(_appointmentFilterService.GetAvailableByPriorityTimeInterval(searchAppointmentsDTO.StartInterval,searchAppointmentsDTO.EndInterval));
            }
            else if (searchAppointmentsDTO.operation == 3 && searchAppointmentsDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.HospitalEquipmentId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval, "nopriority"));
            }
            else if (searchAppointmentsDTO.operation == 4 && searchAppointmentsDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.HospitalEquipmentId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval, "doctor"));
            }
            else if (searchAppointmentsDTO.operation == 5 && searchAppointmentsDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(searchAppointmentsDTO.DoctorId, searchAppointmentsDTO.HospitalEquipmentId, searchAppointmentsDTO.StartInterval, searchAppointmentsDTO.EndInterval, "timeinterval"));
            }
            else
            {
                return Ok();
            }
        }
    }
}
