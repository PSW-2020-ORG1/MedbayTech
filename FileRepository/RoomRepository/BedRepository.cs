// File:    BedRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:50:30 AM
// Purpose: Definition of Class BedRepository

using Model.Rooms;
using Repository.MedicalRecordRepository;
using Repository.ReportRepository;
using SimsProjekat.Repository;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.RoomRepository
{
   public class BedRepository : JSONRepository<Bed, int>,
        IBedRepository, ObjectComplete<Bed>
    {
        public IRoomRepository roomRepository;
        public IMedicalRecordRepository medicalRecordRepository;
        
        private const string NOT_FOUND = "Bed with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Bed with ID number {0} already exists!";

        public BedRepository(IRoomRepository roomRepository, IMedicalRecordRepository medicalRecordRepository, Stream<Bed> stream) : base(stream, "Bed")
        {
            this.roomRepository = roomRepository;
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public new Bed Create(Bed entity)
        {
            entity.BedId = GetNextId();
            SetMissingValues(entity);
            return base.Create(entity); 
        }


        public int GetNextId() => base.GetAll().ToList().Count + 1;

        public new IEnumerable<Bed> GetAll()
        {
            var allBeds = base.GetAll();
            foreach (Bed bed in allBeds)
            {
                CompleteObject(bed);
            }
            return allBeds;
        }
        public IEnumerable<Bed> GetBedsByRoomNumber(int roomNumber)
        {
            var allBeds = GetAll();
            return allBeds.Where(item => item.Room.RoomNumber == roomNumber);
        }

        public new Bed GetObject(int id)
        {
            var bed = base.GetObject(id);
            CompleteObject(bed);
            return bed;
        }

        public new Bed Update(Bed entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public void SetMissingValues(Bed entity)
        {
            entity.Room = new Room(entity.Room.RoomID);
        }

        public void CompleteObject(Bed entity)
        {
            entity.Room = roomRepository.GetObject(entity.Room.RoomID);

            foreach (Occupation occupation in entity.Occupations)
            {
                occupation.Patient = medicalRecordRepository.GetObject(occupation.Patient.IdRecord);
            }
        }
    }
}