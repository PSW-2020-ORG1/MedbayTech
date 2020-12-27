/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Doctor.Doctor
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Model.Users;

namespace Model.Users
{
   public class Doctor : Employee
   {
        public string LicenseNumber { get;  set; }
        public bool OnCall { get;  set; }
        public double PatientReview { get;  set; }
        public int DepartmentId { get;  set; }
        public int ExaminationRoomId { get;  set; }
        public int OperationRoomId { get;  set; }

        //public virtual Specialization Specialization { get; set; }


        public Doctor() {}

        
   }
}