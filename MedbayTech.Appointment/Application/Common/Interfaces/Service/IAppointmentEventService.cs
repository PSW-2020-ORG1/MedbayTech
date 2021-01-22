using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Appointment.Domain.Events;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Service
{
    public interface IAppointmentEventService
    {
        AppointmentEvent CreateEvent(AppointmentEvent appointmentEvent);
        int GetCreatedAppointments();
        double GetAverageSchedulingTime();
        int GetCountOfBackStep();
        int GetCountOfQuit();
        List<double> GetPercentSuccessfullAndQuit();
    }
}
