using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Pharmacies.Model
{
    public class DrugSpecDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DrugSpecDTO() { }
        public DrugSpecDTO(int id,  string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
