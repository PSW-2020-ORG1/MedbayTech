using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Rooms.Service;
using Backend.Schedules.Service;
using Backend.Users.Model;
using Backend.Users.Repository;
using Model.Schedule;
using Repository.ScheduleRepository;
using Service.ScheduleService;
using Xunit;
using Shouldly;
using Backend.Records.Model;

namespace UnitTests.Schedules
{
    public class AppointmentTests
    {

        [Fact]
        public void Recommend_by_date_priority_success()
        {
            var doctorWorkDyRepository = CreateDoctorWorkDayStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();
            var doctorService = CreateDoctorService();
            var priorityParameters = CreatePriorityParametersForDatePrioritySuccess();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDyRepository, appointmentRepository, doctorService);

            List<Appointment> recommendedAppointments = appointmentService.GetAvailableByStrategy(priorityParameters);

            recommendedAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Recommend_by_date_priority_fail()
        {
            var doctorWorkDyRepository = CreateDoctorWorkDayStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();
            var doctorService = CreateDoctorService();
            var priorityParameters = CreatePriorityParametersForDatePriorityFail();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDyRepository, appointmentRepository, doctorService);

            List<Appointment> recommendedAppointments = appointmentService.GetAvailableByStrategy(priorityParameters);

            recommendedAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Recommend_by_doctor_priority_success()
        {
            var doctorWorkDayRepository = CreateDoctorWorkDayStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();
            var doctorService = CreateDoctorService();
            var priorityParameters = CreatePriorityParametersForDoctorPrioritySuccess();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDayRepository, appointmentRepository, doctorService);

            List<Appointment> recommendedAppointments = appointmentService.GetAvailableByStrategy(priorityParameters);

            recommendedAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Recommend_by_doctor_priority_fail()
        {
            var doctorWorkDayRepository = CreateDoctorWorkDayStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();
            var doctorService = CreateDoctorService();
            var priorityParameters = CreatePriorityParametersForDoctorPriorityFail();

            AppointmentService appointmentService = new AppointmentService(doctorWorkDayRepository, appointmentRepository, doctorService);

            List<Appointment> recommendedAppointments = appointmentService.GetAvailableByStrategy(priorityParameters);

            recommendedAppointments.ShouldBeEmpty();
        }
        [Fact]
        public void Get_available()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null);

            var workDay = appointmentService.GetAvailableBy("2407978890045", new DateTime(2020, 12, 20));
            workDay.Count.ShouldBe(14);
        }


        [Fact]
        public void Schedule_appointment_success()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            var appointment = CreateAppointmentSuccess();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null);

            var createdAppointment = appointmentService.ScheduleAppointment(appointment);
            createdAppointment.ShouldNotBe(null);

        }

        [Fact]
        public void Schedule_appointment_fail()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            var appointment = CreateAppointmentFail();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null);

            var createdAppointment = appointmentService.ScheduleAppointment(appointment);

            createdAppointment.ShouldBe(null);

        }
        [Fact]
        public void Find_patients_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetAppointmentsByPatientId("2505998800045");
            appointments.Count.ShouldBe(6);
        }

        [Fact]
        public void Doesnt_find_patinents_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetAppointmentsByPatientId("2541998800045");
            appointments.Count.ShouldBe(0);
        }

        [Fact]
        public void Find_surveyable_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetSurveyableAppointments("2505998800045");
            appointments.Count.ShouldBe(2);
        }

        [Fact]
        public void Doesnt_find_surveyable_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetSurveyableAppointments("2541998800045");
            appointments.Count.ShouldBe(0);
        }

        [Fact]
        public void Find_all_other_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetAllOtherAppointments("2505998800045");
            appointments.Count.ShouldBe(3);

        }

        [Fact]
        public void Doesnt_find_all_other_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetAllOtherAppointments("2541998800045");
            appointments.Count.ShouldBe(0);

        }

        [Fact]
        public void Find_cancelable_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetCancelableAppointments("2505998800045");
            appointments.Count.ShouldBe(1);

        }

        [Fact]
        public void Doesnt_find_cancelable_Appointments()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            List<Appointment> appointments = service.GetCancelableAppointments("2541998800045");
            appointments.Count.ShouldBe(0);

        }

        [Fact]
        public void Cancel_appointment()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var surveyStubRepository = CreateSurveyStubRepository();
            AppointmentService service = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository, null, surveyStubRepository);
            bool b = service.UpdateCanceled(6);
            b.ShouldBeTrue();

        }

        public static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();
            var appointment = CreateAppointmentSuccess();
            var appointmentCancel = CreateAppointment();
            stubRepository.Setup(x => x.Create(It.IsAny<Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.Start.Date.CompareTo(date.Date) == 0).ToList());

            stubRepository.Setup(x => x.GetAppointmentsByPatientId(It.IsAny<string>())).Returns(
                (string id) =>
                appointments.Where(a => a.MedicalRecord.PatientId.Equals(id)).ToList());

            stubRepository.Setup(x => x.GetObject(It.IsAny<int>())).Returns(
                (int id) =>
                appointments.Where(a => a.Id == id).FirstOrDefault());

            stubRepository.Setup(x => x.Update(appointmentCancel)).Returns(appointmentCancel);

            return stubRepository.Object;
        }

        public IDoctorService CreateDoctorService()
        {
            var doctorStubRepository = CreateDoctorStubRepository();

            DoctorService doctorService = new DoctorService(doctorStubRepository);

            return doctorService;
        }
        public static IDoctorWorkDayRepository CreateDoctorWorkDayStubRepository()
        {
            var stubRepository = new Mock<IDoctorWorkDayRepository>();
            var workDays = CreateDoctorWorkDays();
            stubRepository.Setup(x => x.GetByDoctorIdAndDate(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    workDays.FirstOrDefault(wd => wd.DoctorId.Equals(id) && wd.Date.CompareTo(date) == 0));
            return stubRepository.Object;
        }

        public static IDoctorRepository CreateDoctorStubRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            var doctors = CreateDoctors();

            stubRepository.Setup(x => x.GetAll()).Returns(doctors);

            return stubRepository.Object;
        }

        private static ISurveyRepository CreateSurveyStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var surveys = CreateSurveys();
            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            return stubRepository.Object;
        }
        public static List<Survey> CreateSurveys()
        {
            List<Survey> surveys = new List<Survey>();
            Survey s1 = new Survey
            {
                AppointmentId = 1,
            };

            Survey s2 = new Survey
            {
                AppointmentId = 2,
            };

            surveys.Add(s1);
            surveys.Add(s2);

            return surveys;
        }

        public static Appointment CreateAppointmentFail()
        {
            return new Appointment
            {
                Id = 9,
                DoctorId = "2406978890047",
                Start = new DateTime(2020, 12, 10, 8, 0, 0, 0),
                End = new DateTime(2020, 12, 9, 8, 30, 0),
                MedicalRecordId = 1,
                RoomId = 1
            };
        }
        public static Appointment CreateAppointmentSuccess()
        {
            return new Appointment
            {
                Id = 8,
                DoctorId = "2406978890047",
                Start = new DateTime(2020, 12, 5, 14, 30, 0),
                End = new DateTime(2020, 12, 5, 15, 0, 0),
                MedicalRecordId = 1,
                RoomId = 1
            };
        }
        public static Appointment CreateAppointment()
        {
            return new Appointment
            {
                Id = 8,
                DoctorId = "2406978890047",
                Start = new DateTime(2020, 12, 5, 14, 30, 0),
                End = new DateTime(2020, 12, 5, 15, 0, 0),
                MedicalRecordId = 1,
                CanceledByPatient = true,
                MedicalRecord = CreateMedicalRecord(),
                RoomId = 1
            };
        }
        public static MedicalRecord CreateMedicalRecord()
        {
            return new MedicalRecord
            {
                Id = 1,
                PatientId = "2505998800045"
            };
        }

        public static List<Doctor> CreateDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            Doctor doctor1 = new Doctor
            {
                Id = "2407978890045",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "ivan@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy2",
                Name = "Ivan",
                Surname = "Ivanovic",
                Username = "ivan",
                Password = "ivan123",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "doctor",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 1,
                OperationRoomId = 2,
                SpecializationId = 1
            };

            Doctor doctor2 = new Doctor
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
                Profession = "vodoinstalater",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 1,
                OperationRoomId = 2,
                SpecializationId = 1

            };
            doctors.Add(doctor2);
            doctors.Add(doctor1);

            return doctors;
        }

        public PriorityParameters CreatePriorityParametersForDatePriorityFail()
        {
            return new PriorityParameters
            {
                DoctorId = "2406978890047",
                ChosenStartDate = new DateTime(2021, 1, 1),
                ChosenEndDate = new DateTime(2021, 1, 5),
                SpecializationId = 1,
                Priority = PriorityType.date
            };
        }

        public PriorityParameters CreatePriorityParametersForDoctorPrioritySuccess()
        {
            return new PriorityParameters
            {
                DoctorId = "2406978890047",
                ChosenStartDate = new DateTime(2020, 12, 10),
                ChosenEndDate = new DateTime(2020, 12, 16),
                SpecializationId = 1,
                Priority = PriorityType.doctor
            };

        }

        public PriorityParameters CreatePriorityParametersForDoctorPriorityFail()
        {
            return new PriorityParameters
            {
                DoctorId = "2406978890047",
                ChosenStartDate = new DateTime(2021, 12, 10),
                ChosenEndDate = new DateTime(2021, 12, 16),
                SpecializationId = 1,
                Priority = PriorityType.doctor
            };

        }
        public PriorityParameters CreatePriorityParametersForDatePrioritySuccess()
        {
            return new PriorityParameters
            {
                DoctorId = "2406978890047",
                ChosenStartDate = new DateTime(2020, 12, 20),
                ChosenEndDate = new DateTime(2020, 12, 24),
                SpecializationId = 1,
                Priority = PriorityType.date
            };
        }
        public static List<DoctorWorkDay> CreateDoctorWorkDays()
        {
            List<DoctorWorkDay> doctorWorkDays = new List<DoctorWorkDay>();

            DoctorWorkDay dw1 = new DoctorWorkDay
            { Id = 1, Date = new DateTime(2020, 12, 5), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay dw2 = new DoctorWorkDay
            { Id = 2, Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay dw3 = new DoctorWorkDay
            { Id = 3, Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay dw4 = new DoctorWorkDay
            { Id = 4, Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay dw5 = new DoctorWorkDay
            { Id = 5, Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };

            DoctorWorkDay dw6 = new DoctorWorkDay
            { Id = 5, Date = new DateTime(2020, 12, 20), StartTime = 8, EndTime = 15, DoctorId = "2407978890045" };

            doctorWorkDays.Add(dw6);
            doctorWorkDays.Add(dw1);
            doctorWorkDays.Add(dw2);
            doctorWorkDays.Add(dw3);
            doctorWorkDays.Add(dw4);
            doctorWorkDays.Add(dw5);



            return doctorWorkDays;
        }
        public static List<Appointment> CreateListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            Appointment ap1 = new Appointment
            {
                Id = 1,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                MedicalRecord = CreateMedicalRecord(),
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };

            Appointment ap2 = new Appointment
            {
                Id = 2,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                MedicalRecord = CreateMedicalRecord(),
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };

            Appointment ap3 = new Appointment
            {
                Id = 3,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                MedicalRecord = CreateMedicalRecord(),
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            Appointment ap4 = new Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                MedicalRecord = CreateMedicalRecord(),
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            Appointment ap5 = new Appointment
            {
                Id = 5,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2020, 12, 8, 8, 0, 0),
                End = new DateTime(2020, 12, 8, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                MedicalRecordId = 1,
                MedicalRecord = CreateMedicalRecord(),
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            Appointment ap6 = new Appointment
            {
                Id = 6,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2021, 12, 15, 8, 0, 0),
                End = new DateTime(2021, 12, 15, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                MedicalRecordId = 1,
                MedicalRecord = CreateMedicalRecord(),
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };

            appointments.Add(ap1);
            appointments.Add(ap2);
            appointments.Add(ap3);
            appointments.Add(ap4);
            appointments.Add(ap5);
            appointments.Add(ap6);

            return appointments;
        }
    }
}