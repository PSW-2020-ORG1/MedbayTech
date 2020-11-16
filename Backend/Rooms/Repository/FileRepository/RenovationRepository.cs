// File:    RenovationRepository.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 12:45:40 AM
// Purpose: Definition of Class RenovationRepository

using Model.Rooms;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository.RoomRepository
{
    public class RenovationRepository : JSONRepository<Renovation, int>,
        IRenovationRepository, ObjectComplete<Renovation>
    {
        public IRoomRepository roomRepository;
        public Stream<Renovation> stream;

        private const string NOT_FOUND = "Renovation with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Renovation with ID number {0} already exists!";

        public RenovationRepository(IRoomRepository roomRepository, Stream<Renovation> stream) : base(stream, "Renovation")
        {

            this.roomRepository = roomRepository;
        }

        public new Renovation Create(Renovation entity)
        {
            entity.Id = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }


        public new IEnumerable<Renovation> GetAll()
        {
            var allRenovations = base.GetAll().ToList();
            foreach (Renovation renovation in allRenovations)
            {
                CompleteObject(renovation);
            }
            return allRenovations;
        }

        public IEnumerable<Renovation> GetAllFromDate(DateTime date) => base.GetAll().Where(renovation => renovation.Period.StartTime.CompareTo(date) < 0).ToList();
        
        public int GetNextID() => base.GetAll().ToList().Count + 1;

        public new Renovation GetObject(int id)
        {
            var renovation = base.GetObject(id);
            CompleteObject(renovation);
            return renovation;
        }

        public new Renovation Update(Renovation entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public void SetMissingValues(Renovation entity)
        {
            entity.Room = new Room();
        }
        public void CompleteObject(Renovation entity)
        {
            entity.Room = roomRepository.GetObject(entity.Room.Id);
        }
    }
}