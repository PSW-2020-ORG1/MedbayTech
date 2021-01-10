using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Common.Domain.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public Specialization(int id, string name)
        {
            Id = id;
            SpecializationName = name;
        }

        public Specialization()
        {
        }
    }
}
