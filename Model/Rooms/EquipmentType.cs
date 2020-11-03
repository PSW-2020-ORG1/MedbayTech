// File:    EquipmentType.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 12:41:59 AM
// Purpose: Definition of Class EquipmentType

using System;

namespace Model.Rooms
{
    public class EquipmentType
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public EquipmentType ( string name )
        {
            this.Name = name;
        }

        public EquipmentType ( )
        {
        }
    }
}