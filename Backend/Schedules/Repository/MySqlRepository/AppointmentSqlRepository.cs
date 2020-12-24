using Model;
using Model.Schedule;
using Repository;
using Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Schedules.Repository.MySqlRepository
{
    public class AppointmentSqlRepository : MySqlrepository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentSqlRepository(MedbayTechDbContext context) : base(context) { }
        public Dictionary<int, Appointment> GetAppointmentsBy(DateTime date)
        {
            return GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(date) <= 0).ToDictionary(a => a.Id);
        }

        public List<Appointment> GetCanceledAppointmentsByPatient(string patientId)
        {
            return GetAppointmentsByPatientId(patientId).Where(a => a.CanceledByPatient).ToList();
        }

        public List<Appointment> GetAppointmentsByPatientId(string Id)
        {
            List<Appointment> patientAppointments = new List<Appointment>();
            List<Appointment> appointments = GetAll().ToList();
            foreach (Appointment a in appointments) 
            {
                if (a.MedicalRecord.PatientId.Equals(Id)) 
                {
                    patientAppointments.Add(a);
                }
            }
            return patientAppointments;
        }

        public List<Appointment> GetBy(string doctorId, DateTime date)
        {
            return GetAll().Where(a => a.DoctorId.Equals(doctorId) && a.Start.Date.CompareTo(date.Date) == 0).ToList();
        }

        public Dictionary<int, Appointment> GetScheduledFromToday()
        {
            return GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(DateTime.Now) <= 0).ToDictionary(a => a.Id);
        }
    }
}
