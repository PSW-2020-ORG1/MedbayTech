// File:    Occupation.cs
// Author:  Vlajkov
// Created: Thursday, April 23, 2020 7:27:04 PM
// Purpose: Definition of Class Occupations


using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Rooms.Domain
{
    public class Occupation
    {

        [NotMapped]
        public Period Period { get; protected set; }
        public string PatientId { get; protected set; }
        public int BedId { get; protected set; }
        public virtual Bed Bed { get; protected set; }
        public int MedicalRecordId { get; protected set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public Occupation()
        {
        }

        public Occupation(Period period, Bed bed, MedicalRecord medicalRecord)
        {
            Period = period;
            Bed = bed;
            BedId = bed.Id;
            MedicalRecordId = medicalRecord.Id;
            MedicalRecord = medicalRecord;
        }

    }
}