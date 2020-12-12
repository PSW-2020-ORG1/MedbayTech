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
        public IActionResult Post(AppointmentFilterDTO appointmentFilterDTO)
        {
            if (appointmentFilterDTO.operation == 2)
            {
                return Ok(_appointmentFilterService.GetAvailableByPriorityTimeInterval(appointmentFilterDTO.StartInterval, appointmentFilterDTO.EndInterval));
            }
            else if (appointmentFilterDTO.operation == 3 && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(appointmentFilterDTO.DoctorId, appointmentFilterDTO.HospitalEquipmentId, appointmentFilterDTO.StartInterval, appointmentFilterDTO.EndInterval, "nopriority"));
            }
            else if (appointmentFilterDTO.operation == 4 && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(appointmentFilterDTO.DoctorId, appointmentFilterDTO.HospitalEquipmentId, appointmentFilterDTO.StartInterval, appointmentFilterDTO.EndInterval, "doctor"));
            }
            else if (appointmentFilterDTO.operation == 5 && appointmentFilterDTO.HospitalEquipmentId != -1)
            {
                return Ok(_appointmentFilterService.GetAvailableByDoctorTimeIntervalAndEquipment(appointmentFilterDTO.DoctorId, appointmentFilterDTO.HospitalEquipmentId, appointmentFilterDTO.StartInterval, appointmentFilterDTO.EndInterval, "timeinterval"));
            }
            else if (appointmentFilterDTO.operation == 6)
            {
                return Ok(_appointmentFilterService.AddRoomToAppointment(appointmentFilterDTO.appointments));
            }
            else return Ok();
        }
    }
}
