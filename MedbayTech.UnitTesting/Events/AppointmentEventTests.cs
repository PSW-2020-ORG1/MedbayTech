using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Domain.Events;
using MedbayTech.Appointment.Infrastructure.Services.EventService;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MedbayTech.UnitTesting.Events
{
    public class AppointmentEventTests
    {
        [Fact]
        public void Get_average_scheduling_time()
        {
            AppointmentEventService service = new AppointmentEventService(CreateAppointmentEventStubRepository());
            double average = service.GetAverageSchedulingTime();
            average.ShouldBe(15);
        }

        [Fact]
        public void Get_average_number_of_steps_for_successful_appointment()
        {
            AppointmentEventService service = new AppointmentEventService(CreateAppointmentEventStubRepository());
            double average = service.GetAverageNumberOfStepsForSuccessful();
            average.ShouldBe(5);
        }

        [Fact]
        public void Get_average_time_from_start_to_specialization()
        {
            AppointmentEventService service = new AppointmentEventService(CreateAppointmentFromStartToSpecializationEventStubRepository());
            double average = service.GetAverageTimeFromStartedToSelectSpecialization();
            average.ShouldBe(2);
        }

        [Fact]
        public void Get_average_time_from_specialization_to_doctor()
        {
            AppointmentEventService service = new AppointmentEventService(CreateAppointmentFromSpecializationToDoctorEventStubRepository());
            double average = service.GetAverageTimeFromSelectSpecializationToSelectDoctor();
            average.ShouldBe(1);
        }

        [Fact]
        public void Get_average_time_from_doctor_to_appointment()
        {
            AppointmentEventService service = new AppointmentEventService(CreateAppointmentFromDoctorToAppointmentEventStubRepository());
            double average = service.GetAverageTimeFromDoctorToSelectAppointment();
            average.ShouldBe(4);
        }





        public static IAppointmentEventRepository CreateAppointmentEventStubRepository()
        {
            var stubRepository = new Mock<IAppointmentEventRepository>();
            var appe = CreateAppointmentEvent();

            stubRepository.Setup(ae => ae.GetAll()).Returns(appe);
            stubRepository.Setup(ae => ae.GetAllBy(It.IsAny<AppointmentEventType>())).Returns((AppointmentEventType app) => appe.FindAll(entity => entity.Type == AppointmentEventType.Created));
            stubRepository.Setup(ae => ae.GetBy(It.IsAny<AppointmentEventType>(), It.IsAny<string>())).Returns((AppointmentEventType app, string ei) => appe.FirstOrDefault(entity => entity.Type == AppointmentEventType.Started && entity.EventIdentificator.Equals("ab")));
            stubRepository.Setup(ae => ae.GetAllStepsBy(It.IsAny<string>())).Returns(5);

            return stubRepository.Object;
        }

        public static IAppointmentEventRepository CreateAppointmentFromStartToSpecializationEventStubRepository()
        {
            var stubRepository = new Mock<IAppointmentEventRepository>();
            var appe = CreateAppointmentEvent();

            stubRepository.Setup(ae => ae.GetAll()).Returns(appe);
            
            stubRepository.Setup(ae => ae.GetAllBy(It.IsAny<AppointmentEventType>())).Returns((AppointmentEventType app) => appe.FindAll(entity => entity.Type == AppointmentEventType.FromStartedToSelectSpecialization));
            stubRepository.Setup(ae => ae.GetBy(It.IsAny<AppointmentEventType>(), It.IsAny<string>())).Returns((AppointmentEventType app, string ei) => appe.FirstOrDefault(entity => entity.Type == AppointmentEventType.Started && entity.EventIdentificator.Equals("ab")));
            
            return stubRepository.Object;
        }

        public static IAppointmentEventRepository CreateAppointmentFromSpecializationToDoctorEventStubRepository()
        {
            var stubRepository = new Mock<IAppointmentEventRepository>();
            var appe = CreateAppointmentEvent();

            stubRepository.Setup(ae => ae.GetAll()).Returns(appe);
            
            stubRepository.Setup(ae => ae.GetAllBy(It.IsAny<AppointmentEventType>())).Returns((AppointmentEventType app) => appe.FindAll(entity => entity.Type == AppointmentEventType.FromSelectSpecializationToSelectDoctor));
            stubRepository.Setup(ae => ae.GetBy(It.IsAny<AppointmentEventType>(), It.IsAny<string>())).Returns((AppointmentEventType app, string ei) => appe.FirstOrDefault(entity => entity.Type == AppointmentEventType.FromStartedToSelectSpecialization && entity.EventIdentificator.Equals("ab")));
           

            return stubRepository.Object;
        }

        public static IAppointmentEventRepository CreateAppointmentFromDoctorToAppointmentEventStubRepository()
        {
            var stubRepository = new Mock<IAppointmentEventRepository>();
            var appe = CreateAppointmentEvent();

            stubRepository.Setup(ae => ae.GetAll()).Returns(appe);
            
            stubRepository.Setup(ae => ae.GetAllBy(It.IsAny<AppointmentEventType>())).Returns((AppointmentEventType app) => appe.FindAll(entity => entity.Type == AppointmentEventType.FromSelectDoctorToSelectAppointment));
            stubRepository.Setup(ae => ae.GetBy(It.IsAny<AppointmentEventType>(), It.IsAny<string>())).Returns((AppointmentEventType app, string ei) => appe.FirstOrDefault(entity => entity.Type == AppointmentEventType.FromSelectSpecializationToSelectDoctor && entity.EventIdentificator.Equals("ab")));

            return stubRepository.Object;
        }

        public static List<AppointmentEvent> CreateAppointmentEvent()
        {
            var ae = new AppointmentEvent
            {
                EventIdentificator = "ab",
                Id = 1,
                Timestamp = new DateTime(2021, 12, 4, 11, 25, 45),
                Type = AppointmentEventType.Created

            };

            var ae2 = new AppointmentEvent
            {
                EventIdentificator = "ab",
                Id = 1,
                Timestamp = new DateTime(2021, 12, 4, 11, 25, 30),
                Type = AppointmentEventType.Started
            };

            var ae3 = new AppointmentEvent
            {
                EventIdentificator = "ab",
                Id = 1,
                Timestamp = new DateTime(2021, 12, 4, 11, 25, 32),
                Type = AppointmentEventType.FromStartedToSelectSpecialization

            };

            var ae5 = new AppointmentEvent
            {
                EventIdentificator = "ab",
                Id = 1,
                Timestamp = new DateTime(2021, 12, 4, 11, 25, 33),
                Type = AppointmentEventType.FromSelectSpecializationToSelectDoctor

            };

            var ae6 = new AppointmentEvent
            {
                EventIdentificator = "ab",
                Id = 1,
                Timestamp = new DateTime(2021, 12, 4, 11, 25, 37),
                Type = AppointmentEventType.FromSelectDoctorToSelectAppointment
            };

            List<AppointmentEvent> list = new List<AppointmentEvent>();
            list.Add(ae);
            list.Add(ae2);
            list.Add(ae3);
            list.Add(ae5);
            list.Add(ae6);

            return list;
        }


    }
}
