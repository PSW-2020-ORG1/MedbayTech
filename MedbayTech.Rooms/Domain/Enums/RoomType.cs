/***********************************************************************
 * Module:  RoomType.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Schedule.RoomType
 ***********************************************************************/

using System;

namespace MedbayTech.Rooms.Domain
{
    public enum RoomType
    {
        PatientRoom,
        ExaminationRoom,
        OperationRoom,
        AuxiliaryRoom,
        StorageRoom
    }
}