/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using Model.MedicalRecord;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Repository.MedicalRecordRepository;
using Repository.ReportRepository;
using Repository.RoomRepository;
using Repository.UserRepository;
using SimsProjekat.Repository;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.ScheduleRepository
{
   public class AppointmentRepository : JSONRepository<Appointment, int>,
        IAppointmentRepository, ObjectComplete<Appointment>
    {
        public IUserRepository doctorRepository;
        public IMedicalRecordRepository medicalRecordRepository;
        public IRoomRepository roomRepository;

        private const string NOT_FOUND = "Appointment with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Appointment with ID number {0} already exists!";


        public AppointmentRepository(IUserRepository userRepository, IMedicalRecordRepository medicalRecordRepository, 
            IRoomRepository roomRepository, Stream<Appointment> stream) : base(stream, "Appointment")
        {
            this.doctorRepository = userRepository;
            this.medicalRecordRepository = medicalRecordRepository;
            this.roomRepository = roomRepository;
        }

        public new Appointment Create(Appointment entity)
        {
            entity.Id = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }


        public new IEnumerable<Appointment> GetAll()
        {
            var allAppointments = base.GetAll().ToList();
            foreach (Appointment appointment in allAppointments)
            {
                CompleteObject(appointment);
            }
            return allAppointments;
        }

        public Dictionary<int, Appointment> GetAppointmentsByDate(DateTime date)
        {
            var allAppointments = stream.GetAll().ToList();
            Dictionary<int, Appointment> appointmentsByDate = new Dictionary<int, Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.StartTime.Date.CompareTo(date.Date) == 0)
                {
                    CompleteObject(appointment);
                    Doctor doctor = (Doctor)doctorRepository.GetObject(appointment.Doctor.Username);
                    appointmentsByDate.Add((new Appointment(appointment.StartTime, appointment.EndTime, doctor, TypeOfAppointment.examination)).GetHashCode(), appointment);
                }
            }
            return appointmentsByDate;
        }

        public new Appointment GetObject(int id)
        {
            var appointment = base.GetObject(id);
            CompleteObject(appointment);
            return appointment;
        }

        public new Appointment Update(Appointment entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public void SetMissingValues(Appointment entity)
        {
            entity.Room = new Room(entity.Room.RoomID);
            entity.MedicalRecord = new MedicalRecord(entity.MedicalRecord.Id);
            entity.Doctor = new Doctor(entity.Doctor.Username);
        }

        public int GetNextID() => stream.GetAll().ToList().Count + 1;


        public void CompleteObject(Appointment entity)
        {
            entity.Room = roomRepository.GetObject(entity.Room.RoomID);
            entity.MedicalRecord = medicalRecordRepository.GetObject(entity.MedicalRecord.Id);
            entity.Doctor = (Doctor)doctorRepository.GetObject(entity.Doctor.Username);
        }

        public Dictionary<int, Appointment> GetScheduledFromToday()
        {
            var allAppointments = stream.GetAll().ToList();
            Dictionary<int, Appointment> appointmentsByDate = new Dictionary<int, Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                CompleteObject(appointment);
                if (appointment.StartTime.Date.CompareTo(DateTime.Today.Date) > 0)
                {
                    appointmentsByDate.Add(appointment.GetHashCode(), appointment);
                }
            }
            return appointmentsByDate;
            
        }
    }
}