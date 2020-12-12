// File:    EquipmentType.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 12:41:59 AM
// Purpose: Definition of Class EquipmentType

using Backend.General.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Rooms
{
    public class EquipmentType : IIdentifiable<int>
    {
        public string Name { get; set; }
        [Key]
        public int Id { get; set; }

        public EquipmentType ( string name )
        {
            this.Name = name;
        }

        public EquipmentType ( )
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