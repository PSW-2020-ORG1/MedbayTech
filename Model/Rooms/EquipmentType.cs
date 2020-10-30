// File:    EquipmentType.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 12:41:59 AM
// Purpose: Definition of Class EquipmentType

using System;

namespace Model.Rooms
{
   public class EquipmentType
   {
        private string name;
   
        public EquipmentType(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
   }
}