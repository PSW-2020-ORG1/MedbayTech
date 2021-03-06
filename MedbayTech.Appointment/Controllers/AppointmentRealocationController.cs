﻿using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Application.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedbayTech.Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentRealocationController : Controller
    {
        private IAppointmentRealocationService _appointmentRealocationService;

        public AppointmentRealocationController(IAppointmentRealocationService appointmentRealocationService)
        {
            _appointmentRealocationService = appointmentRealocationService;
        }

        [HttpGet("{roomId?}")]
        public IActionResult Get(string roomId)
        {
            return Ok(_appointmentRealocationService.GetAppointmentRealocationsByRoomId(Int32.Parse(roomId)));
        }

        [HttpPost]
        public IActionResult Post(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.ByRoomAndDateTime)
            {
                return Ok(_appointmentRealocationService.GetAllAvailableAppointmentByRoomAndDateTime(appointmentRealocationDTO.RoomId, appointmentRealocationDTO.StartInterval, appointmentRealocationDTO.EndInterval));
            }
            else if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.CheckIsRoomAvailable)
            {
                return Ok(_appointmentRealocationService.CheckIsRoomAvailableInSelectedTime(appointmentRealocationDTO.RoomId, appointmentRealocationDTO.StartInterval));
            }
            else if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation)
            {
                return Ok(_appointmentRealocationService.ScheduleAppointmentRealocation(appointmentRealocationDTO.appointmentRealocation));
            }
            else if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.AlternativeAppointments)
            {
                return Ok(_appointmentRealocationService.GetAlternativeAvailableAppointments(appointmentRealocationDTO.FromRoomId, appointmentRealocationDTO.ToRoomId, appointmentRealocationDTO.StartInterval, appointmentRealocationDTO.HospitalEquipmentId));
            }
            else if(appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.UpdateRealocation)
            {
                return Ok(_appointmentRealocationService.UpdateAppointement(appointmentRealocationDTO.appointmentRealocation));
            }
            else return Ok();
        }
    }
}
