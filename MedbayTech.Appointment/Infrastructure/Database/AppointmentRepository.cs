using Application.Common.Interfaces.Persistance;
using Domain.Entities;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Repository.Repository.SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Database
{
    public class AppointmentRepository : SqlRepository<MedbayTech.Appointment.Domain.Entities.Appointment, int>,
        IAppointmentRepository
    {
        public AppointmentRepository(AppointmentDbContext context) : base(context) { }
        public Dictionary<int, Appointment> GetAppointmentsBy(DateTime date)
            => GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(date) <= 0).ToDictionary(a => a.Id);

        public List<Appointment> GetCanceledAppointmentsByPatient(string patientId)
            => GetAppointmentsByPatientId(patientId).Where(a => a.CanceledByPatient).ToList();

        public List<Appointment> GetAppointmentsByPatientId(string Id)
            => GetAll().Where(a => a.PatientId.Equals(Id)).ToList();

        public List<Appointment> GetBy(string doctorId, DateTime date)
            => GetAll().Where(a => a.DoctorId.Equals(doctorId) && a.Period.StartTime.Date.CompareTo(date.Date) == 0).ToList();

        public Dictionary<int, Appointment> GetScheduledFromToday()
            => GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(DateTime.Now) <= 0).ToDictionary(a => a.Id);
    }
}
