using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Backend.Schedules.Service;
using Backend.Users.Model;
using Backend.Users.Repository;
using Model.Schedule;
using Repository.ScheduleRepository;
using Shouldly;
using Castle.Core.Internal;
using Model.Users;
using Repository.RoomRepository;
using Model.Rooms;
using Backend.Schedules.Service.Interfaces;
using Service.ScheduleService;

namespace MedbayTechUnitTests
{
    public class AppointmentSearchTest
    {
        [Fact]
        public void GetAvailableAppointmentsForDoctorAndTimeFail()
        {
            var doctorWorkDayRepository = CreateStubRepositoryDoctorWork();
            var appointmentsRepository = CreateStubRepositoryAppointment();
            AppointmentService service = new AppointmentService(doctorWorkDayRepository,appointmentsRepository);
            String id = "2406978890047";
            DateTime start_date = new DateTime(1999, 12, 5, 8, 0, 0);
            DateTime end_date = new DateTime(1999, 12, 5, 8, 30, 0);
            var gotAppointment = service.GetAvailableByDoctorAndTimeInterval(new PriorityParameters {DoctorId = id, ChosenStartDate=start_date, ChosenEndDate = end_date  });

            gotAppointment.IsNullOrEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentsForDoctorAndTimeSuccess()
        {
            var doctorWorkDayRepository = CreateStubRepositoryDoctorWork();
            var appointmentsRepository = CreateStubRepositoryAppointment();
            AppointmentService service = new AppointmentService(doctorWorkDayRepository, appointmentsRepository);
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 8, 30, 0);
            var gotAppointment = service.GetAvailableByDoctorAndTimeInterval(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date });

            gotAppointment.ShouldNotBeEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityTimeIntervalFail()
        {
            AppointmentService appointmentsService = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            AppointmentFilterService service = new AppointmentFilterService(appointmentsService, CreateStubRepositoryDoctor(), CreateStupRepositoryEquipment());
            DateTime start_date = new DateTime(2022, 12, 5, 8, 0, 0);
            DateTime end_date = new DateTime(2022, 12, 5, 8, 30, 0);
            var gotAppointments = service.GetAvailableByPriorityTimeInterval(new PriorityParameters { ChosenStartDate = start_date, ChosenEndDate = end_date });

            gotAppointments.IsNullOrEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityTimeIntervalSuccess()
        {
            AppointmentService appointmentsService = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            AppointmentFilterService service = new AppointmentFilterService(appointmentsService, CreateStubRepositoryDoctor(), CreateStupRepositoryEquipment());
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 15, 0, 0);
            var gotAppointments = service.GetAvailableByPriorityTimeInterval(new PriorityParameters { ChosenStartDate = start_date, ChosenEndDate = end_date });

            gotAppointments.ShouldNotBeEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityDoctorFail()
        {
            AppointmentService service = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 3, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 5, 8, 30, 0);
            var gotAppointments = service.GetAvailableByPriorityDoctor(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date });
            gotAppointments.IsNullOrEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityDoctorSuccess()
        {
            AppointmentService service = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 15, 0, 0);
            var gotAppointments = service.GetAvailableByPriorityDoctor(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date });
            gotAppointments.ShouldNotBeEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityEquipmentSuccess()
        {   
            AppointmentService appService = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            AppointmentFilterService filterService = new AppointmentFilterService(appService, CreateStubRepositoryDoctor(), CreateStupRepositoryEquipment());
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 15, 0, 0);
            var gotAppointments = filterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date }, 9, "doctor");
            gotAppointments.ShouldNotBeEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityEquipmentFail()
        {
            AppointmentService appService = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            AppointmentFilterService filterService = new AppointmentFilterService(appService, CreateStubRepositoryDoctor(), CreateStupRepositoryEquipment());
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 10, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 10, 8, 30, 0);
            var gotAppointments = filterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date }, 1, "doctor");
            gotAppointments.IsNullOrEmpty();
        }

        public static IAppointmentRepository CreateStubRepositoryAppointment()
        {
            var stubRepository = new Mock <IAppointmentRepository>();
            var appointments = CreateLisfOfAppointments();
            var appointment = CreateAppointment();

            stubRepository.Setup(x => x.Create(It.IsAny<Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.Start.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }

        public static IDoctorWorkDayRepository CreateStubRepositoryDoctorWork()
        {
            var stubRepository = new Mock <IDoctorWorkDayRepository>();
            var doctorWorkDays = CreateListOfDoctorWorkDays(); 
            stubRepository.Setup(x => x.GetByDoctorIdAndDate(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    doctorWorkDays.Where(wd => wd.DoctorId.Equals(id) && wd.Date.CompareTo(date) == 0).FirstOrDefault());
            return stubRepository.Object;
        }


        public static IDoctorRepository CreateStubRepositoryDoctor()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            var doctorList = CreateListOfDoctor();
            stubRepository.Setup(m => m.GetAll()).Returns(doctorList);
            stubRepository.Setup(m => m.GetObject(It.IsAny<string>())).Returns((string id) => doctorList.Find(d => d.Id.Equals(id)));
            return stubRepository.Object;
        }


        public IHospitalEquipmentRepository CreateStupRepositoryEquipment()
        {
            var stubRepository = new Mock<IHospitalEquipmentRepository>();
            var equipment = GetListOfEquipment().ToList();
            stubRepository.Setup(m => m.GetAll()).Returns(equipment);
            return stubRepository.Object;
        }

        public static List<Doctor> CreateListOfDoctor()
        {
            List<Doctor> doctors = new List<Doctor>();
            Doctor doc1 = new Doctor
            {
                Id = "2406978890047",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "mika@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Milan",
                Surname = "Milanovic",
                Username = "mika",
                Password = "mika1978",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "doktor",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 1003,
                OperationRoomId = 1119,
                SpecializationId = 1
            };
            Doctor doc2 = new Doctor
            {
                Id = "2406978890048",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "zika@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Zivorad",
                Surname = "Zivoradovic",
                Username = "zika",
                Password = "zika1978",
                Phone = "065/123-4555",
                PlaceOfBirthId = 11000,
                Profession = "doktor",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 1003,
                OperationRoomId = 1119,
                SpecializationId = 1
            };
            doctors.Add(doc1);
            doctors.Add(doc2); 
            return doctors;
        }

        public static List<Appointment> CreateLisfOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0), 
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            Appointment app2 = new Appointment
            {
                Id = 6,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2021, 12, 5, 8, 0, 0),
                End = new DateTime(2021, 12, 5, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };

            appointments.Add(app1);
            appointments.Add(app2);
           
            return appointments;
        }
        public static List<DoctorWorkDay> CreateListOfDoctorWorkDays()
        {
            List<DoctorWorkDay> workAndDayList = new List<DoctorWorkDay>();
            DoctorWorkDay workDay1 = new DoctorWorkDay { Id = 2, Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay workDay2 = new DoctorWorkDay { Id = 3, Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay workDay3 = new DoctorWorkDay { Id = 4, Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay workDay4 = new DoctorWorkDay { Id = 5, Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            workAndDayList.Add(workDay1);
            workAndDayList.Add(workDay2);
            workAndDayList.Add(workDay3);
            workAndDayList.Add(workDay4);
            return workAndDayList;
        }
        public static DoctorWorkDay CreateWorkDay()
        {
            DoctorWorkDay doctorWorkDay = new DoctorWorkDay { Id = 2, Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            return doctorWorkDay;
        }
        public static Appointment CreateAppointment()
        {
            Appointment app = new Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            return app;
        }

        private static IEnumerable<HospitalEquipment> GetListOfEquipment()
        {
            var h1 = new HospitalEquipment { Id = 1, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 1003, EquipmentTypeId = 9 };
            var h2 = new HospitalEquipment { Id = 2, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 1003, EquipmentTypeId = 10 };
            var h3 = new HospitalEquipment { Id = 3, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 1003, EquipmentTypeId = 17 };
            var h4 = new HospitalEquipment { Id = 4, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1003, EquipmentTypeId = 18 };
            var h5 = new HospitalEquipment { Id = 5, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1003, EquipmentTypeId = 19 };
            var h6 = new HospitalEquipment { Id = 6, QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 1003, EquipmentTypeId = 22 };
            var hospitalEquipment = new List<HospitalEquipment>();
            hospitalEquipment.Add(h1);
            hospitalEquipment.Add(h2);
            hospitalEquipment.Add(h3);
            hospitalEquipment.Add(h4);
            hospitalEquipment.Add(h5);
            hospitalEquipment.Add(h6);
            return hospitalEquipment;
        }
    }
}
