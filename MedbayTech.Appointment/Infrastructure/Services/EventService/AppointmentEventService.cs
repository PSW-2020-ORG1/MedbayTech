using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Domain.Events;
using MedbayTech.Appointment.Infrastructure.Persistance;

namespace MedbayTech.Appointment.Infrastructure.Services.EventService
{
    public class AppointmentEventService : IAppointmentEventService
    {
        private readonly IAppointmentEventRepository _appointmentEventRepository;

        public AppointmentEventService(IAppointmentEventRepository appointmentEventRepository)
        {
            _appointmentEventRepository = appointmentEventRepository;
        }
        public AppointmentEvent CreateEvent(AppointmentEvent appointmentEvent)
        {
            return _appointmentEventRepository.Create(appointmentEvent);
        }

        public int GetCreatedAppointments()
        {
            return _appointmentEventRepository.GetAllBy(AppointmentEventType.Created).Count();
        }

        public double GetAverageSchedulingTime()
        {
            List<AppointmentEvent> createdAppointments = _appointmentEventRepository.GetAllBy(AppointmentEventType.Created);

            double sum = 0;
            foreach (AppointmentEvent createdAppointmenttIt in createdAppointments)
            {
                AppointmentEvent startedAppointmentEvent =
                    _appointmentEventRepository.GetBy(AppointmentEventType.Started,
                        createdAppointmenttIt.EventIdentificator);

                sum += (createdAppointmenttIt.Timestamp - startedAppointmentEvent.Timestamp).TotalSeconds;
            }

            if (createdAppointments.Count != 0)
                return sum / createdAppointments.Count;

            return 0;
        }

        public double GetAverageTimeFromStartedToSelectSpecialization()
        {
            List<AppointmentEvent> createdAppointments = _appointmentEventRepository.GetAllBy(AppointmentEventType.FromStartedToSelectSpecialization);

            double sum = 0;
            foreach (AppointmentEvent createdAppointmenttIt in createdAppointments)
            {
                AppointmentEvent startedAppointmentEvent =
                    _appointmentEventRepository.GetBy(AppointmentEventType.Started,
                        createdAppointmenttIt.EventIdentificator);

                sum += (createdAppointmenttIt.Timestamp - startedAppointmentEvent.Timestamp).TotalSeconds;
            }

            if (createdAppointments.Count != 0)
                return sum / createdAppointments.Count;

            return 0;
        }

        public double GetAverageTimeFromSelectSpecializationToSelectDoctor()
        {
            List<AppointmentEvent> createdAppointments = _appointmentEventRepository.GetAllBy(AppointmentEventType.FromSelectSpecializationToSelectDoctor);

            double sum = 0;
            foreach (AppointmentEvent createdAppointmenttIt in createdAppointments)
            {
                AppointmentEvent startedAppointmentEvent =
                    _appointmentEventRepository.GetBy(AppointmentEventType.FromStartedToSelectSpecialization,
                        createdAppointmenttIt.EventIdentificator);

                sum += (createdAppointmenttIt.Timestamp - startedAppointmentEvent.Timestamp).TotalSeconds;
            }

            if (createdAppointments.Count != 0)
                return sum / createdAppointments.Count;

            return 0;
        }

        public double GetAverageTimeFromDoctorToSelectAppointment()
        {
            List<AppointmentEvent> createdAppointments = _appointmentEventRepository.GetAllBy(AppointmentEventType.FromSelectDoctorToSelectAppointment);

            double sum = 0;
            foreach (AppointmentEvent createdAppointmenttIt in createdAppointments)
            {
                AppointmentEvent startedAppointmentEvent =
                    _appointmentEventRepository.GetBy(AppointmentEventType.FromSelectSpecializationToSelectDoctor,
                        createdAppointmenttIt.EventIdentificator);

                sum += (createdAppointmenttIt.Timestamp - startedAppointmentEvent.Timestamp).TotalSeconds;
            }

            if (createdAppointments.Count != 0)
                return sum / createdAppointments.Count;

            return 0;
        }

        public List<double> GetPercentSuccessfullAndQuit()
        {
            List<AppointmentEvent> allSuccessfull = _appointmentEventRepository.GetAllBy(AppointmentEventType.Created);
            List<AppointmentEvent> allQuit = _appointmentEventRepository.GetAllBy(AppointmentEventType.Quit);

            int allAppointments = allSuccessfull.Count + allQuit.Count;

            List<double> result = new List<double>();

            double successfullPercent = (double)allSuccessfull.Count / (double)allAppointments * 100;
            double quitPercent = (double)allQuit.Count / (double)allAppointments * 100;

            result.Add(successfullPercent);
            result.Add(quitPercent);

            return result;
        }

        public double GetAverageNumberOfStepsForSuccessful()
        {
            List<AppointmentEvent> createdAppointments = _appointmentEventRepository.GetAllBy(AppointmentEventType.Created);
            int steps = 0;
            int numberOfAppointments = createdAppointments.Count();

            foreach (AppointmentEvent createdAppointmentIt in createdAppointments)
            {
                steps += _appointmentEventRepository.GetAllStepsBy(createdAppointmentIt.EventIdentificator);
            }

            if (numberOfAppointments != 0)
                return steps / numberOfAppointments;

            return 0;

        }

        public int GetCountOfBackStep()
        {
            return _appointmentEventRepository.GetCountOfBackStep();
        }

        public int GetCountOfQuit()
        {
            return _appointmentEventRepository.GetAll().Count(ae => ae.Type == AppointmentEventType.Quit);
        }

    }
}
