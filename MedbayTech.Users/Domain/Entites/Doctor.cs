/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Doctor.Doctor
 ***********************************************************************/


namespace MedbayTech.Users.Domain.Entites
{
   public class Doctor : Employee
   {
        public string LicenseNumber { get;  set; }
        public bool OnCall { get;  set; }
        public double PatientReview { get;  set; }
        public int DepartmentId { get;  set; }
        public int ExaminationRoomId { get;  set; }
        public int OperationRoomId { get;  set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }


        public Doctor() {}

        public void UpdateDoctor(Doctor doctor)
        {
            LicenseNumber = doctor.LicenseNumber;
            OnCall = doctor.OnCall;
            PatientReview = doctor.PatientReview;
            DepartmentId = doctor.DepartmentId;         
            ExaminationRoomId = doctor.ExaminationRoomId;
            OperationRoomId = doctor.OperationRoomId;           
            Specialization = null;
        }


    }
}