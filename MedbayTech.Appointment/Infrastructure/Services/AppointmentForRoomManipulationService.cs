using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Services
{
    public class AppointmentForRoomManipulationService : IAppointmentForRoomManipulationService
    {
        IAppointmentForRoomManipulationRepository _appointmentForRoomManipulationRepository;

        public AppointmentForRoomManipulationService(IAppointmentForRoomManipulationRepository appointmentForRoomManipulationRepository)
        {
            _appointmentForRoomManipulationRepository = appointmentForRoomManipulationRepository;
        }

        public List<AppointmentForRoomManipulation> GetAllForRoom(int roomId)
        {
            return _appointmentForRoomManipulationRepository.GetAll().ToList().Where(a => a.RoomId == roomId && a.IsCanceled == false && a.Finished == false).ToList();
        }

        public AppointmentForRoomManipulation Update(AppointmentForRoomManipulation appointmentForRoomManipulation)
        {
            return _appointmentForRoomManipulationRepository.Update(appointmentForRoomManipulation);
        }
    }
}
