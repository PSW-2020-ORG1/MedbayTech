// File:    HospitalRepository.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 9:27:08 PM
// Purpose: Definition of Class HospitalRepository

using Model.Users;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public class HospitalRepository : JSONRepository<Hospital, int>,
        IHospitalRepository
   {
        public HospitalRepository(Stream<Hospital> stream) : base(stream, "Hospital")
        {
            this.stream = stream;
        }
        public new Hospital Create(Hospital entity)
        {
            entity.Id = GetNextID();
            return base.Create(entity);
        }

        public int GetNextID() => stream.GetAll().ToList().Count + 1;
    }
}