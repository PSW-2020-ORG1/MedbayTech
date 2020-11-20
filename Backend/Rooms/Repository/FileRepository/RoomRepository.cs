/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using Model.Rooms;
using Model.Users;
using Repository.ScheduleRepository;
using Repository.UserRepository;
using Backend.Exceptions.Schedules;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.RoomRepository
{
   public class RoomRepository : JSONRepository<Room, int>,
        IRoomRepository, ObjectComplete<Room>
   {
        public IDepartmentRepository departmentRepository;
        public IAppointmentRepository appointmentRepository;

        public RoomRepository(IDepartmentRepository departmentRepository, Stream<Room> stream) : base(stream, "Room")
        {

            this.departmentRepository = departmentRepository;
        }
        public new Room Create(Room entity)
        {
            entity.Id = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public new IEnumerable<Room> GetAll()
        {
            var allRooms = base.GetAll();
            foreach (Room room in allRooms)
            {
                CompleteObject(room);
            }

            return allRooms;
        }
        public new Room GetObject(int id)
        {
            Room room = base.GetObject(id);
            CompleteObject(room);
            return room;
        }

        public new Room Update(Room entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public int GetNextID() => base.GetAll().ToList().Count + 1;

        public void SetMissingValues(Room entity)
        {
            if (entity.Department != null)
                entity.Department = new Department();
        }

        public void CompleteObject(Room entity)
        {
            if (entity.Department != null) 
                entity.Department = departmentRepository.GetObject(entity.Department.Id);

        }
    }
}