// File:    EquipmentType.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 12:41:59 AM
// Purpose: Definition of Class EquipmentType


using MedbayTech.Common.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Rooms.Domain
{
    public class EquipmentType : IIdentifiable<int>
    {
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public EquipmentType(string name)
        {
            this.Name = name;
        }

        public EquipmentType()
        {
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}