using System.Linq;
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Infrastructure.Database
{
    public class RoomDataSeeder
    {
        public RoomDataSeeder() { }
        public void SeedAllEntities(RoomDbContext context)
        {
            SeedRooms(context);
        } 

        public void SeedRooms(RoomDbContext context)
        {
                context.Add(new Room { RoomNumber = 1, RoomLabel = "", RoomUse = "", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 2, RoomLabel = "", RoomUse = "", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 1, RoomLabel = "0F-GN1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 2, RoomLabel = "0F-GN2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 3, RoomLabel = "0F-GN3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 4, RoomLabel = "0F-GN4", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 5, RoomLabel = "0F-GN5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 6, RoomLabel = "0F-GN6", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 7, RoomLabel = "0F-GN7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 8, RoomLabel = "0F-GN8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 9, RoomLabel = "0F-GN9", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 10, RoomLabel = "0F-GN10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 11, RoomLabel = "0F-GN11", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 12, RoomLabel = "0F-CA1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 13, RoomLabel = "0F-CA2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 14, RoomLabel = "0F-CA3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 15, RoomLabel = "0F-CA4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 16, RoomLabel = "0F-CA5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 17, RoomLabel = "0F-CA6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 18, RoomLabel = "0F-CA7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 19, RoomLabel = "0F-CA8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 20, RoomLabel = "0F-CA9", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 21, RoomLabel = "0F-CA10", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 1, RoomLabel = "1F-ON1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 2, RoomLabel = "1F-ON2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 3, RoomLabel = "1F-ON3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 4, RoomLabel = "1F-ON4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 5, RoomLabel = "1F-ON5", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 6, RoomLabel = "1F-ON6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 7, RoomLabel = "1F-ON7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 8, RoomLabel = "1F-ON8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 9, RoomLabel = "1F-ON9", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 10, RoomLabel = "1F-ON10", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 11, RoomLabel = "1F-ON11", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 12, RoomLabel = "1F-ON12", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 13, RoomLabel = "1F-ON13", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 14, RoomLabel = "1F-RD1", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 15, RoomLabel = "1F-RD2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 16, RoomLabel = "1F-RD3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 17, RoomLabel = "1F-RD4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 18, RoomLabel = "1F-RD5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 19, RoomLabel = "1F-RD6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 20, RoomLabel = "1F-RD7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 21, RoomLabel = "1F-RD8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });

                context.Add(new Room { RoomNumber = 1, RoomLabel = "2F-NE1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 2, RoomLabel = "2F-NE2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 3, RoomLabel = "2F-NE3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 4, RoomLabel = "2F-NE4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 5, RoomLabel = "2F-NE5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 6, RoomLabel = "2F-NE6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 7, RoomLabel = "2F-NE7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 8, RoomLabel = "2F-NE8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 9, RoomLabel = "2F-NE9", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });

                context.Add(new Room { RoomNumber = 10, RoomLabel = "2F-NE10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 11, RoomLabel = "2F-NE11", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 12, RoomLabel = "2F-NE12", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 13, RoomLabel = "2F-NE13", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 14, RoomLabel = "2F-NE14", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 15, RoomLabel = "2F-IC1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 16, RoomLabel = "2F-IC2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 17, RoomLabel = "2F-IC3", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 18, RoomLabel = "2F-IC4", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 19, RoomLabel = "2F-IC5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 20, RoomLabel = "2F-IC6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 21, RoomLabel = "2F-IC7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 22, RoomLabel = "2F-IC8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });

                context.Add(new Room { RoomNumber = 1, RoomLabel = "0F-EM1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 2, RoomLabel = "0F-EM2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 3, RoomLabel = "0F-EM3", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 4, RoomLabel = "0F-EM4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 5, RoomLabel = "0F-EM5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 6, RoomLabel = "0F-EM6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 7, RoomLabel = "0F-EM7", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 8, RoomLabel = "0F-EM8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 9, RoomLabel = "0F-DY1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 10, RoomLabel = "0F-DY2", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 11, RoomLabel = "0F-DY3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 12, RoomLabel = "0F-DY4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 13, RoomLabel = "0F-DY5", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 14, RoomLabel = "0F-DY6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 15, RoomLabel = "0F-DY7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 16, RoomLabel = "0F-DY8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });

                context.Add(new Room { RoomNumber = 1, RoomLabel = "1F-GE1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 2, RoomLabel = "1F-GE2", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 3, RoomLabel = "1F-GE3", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 4, RoomLabel = "1F-GE4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 5, RoomLabel = "1F-GE5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 6, RoomLabel = "1F-GE6", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 7, RoomLabel = "1F-GE7", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 8, RoomLabel = "1F-GE8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 9, RoomLabel = "1F-GE9", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 10, RoomLabel = "1F-GE10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 11, RoomLabel = "1F-GE11", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 12, RoomLabel = "1F-GE12", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 13, RoomLabel = "1F-GE13", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 14, RoomLabel = "1F-GE14", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 15, RoomLabel = "1F-HM1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });

                context.Add(new Room { RoomNumber = 16, RoomLabel = "1F-HM2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 17, RoomLabel = "1F-HM3", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 18, RoomLabel = "1F-HM4", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 19, RoomLabel = "1F-HM5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 20, RoomLabel = "1F-HM6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 21, RoomLabel = "1F-HM7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 22, RoomLabel = "1F-HM8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });

                context.Add(new Room { RoomNumber = 1, RoomLabel = "2F-RM1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 2, RoomLabel = "2F-RM2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 3, RoomLabel = "2F-RM3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 4, RoomLabel = "2F-RM4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 5, RoomLabel = "2F-RM5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 6, RoomLabel = "2F-RM6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 7, RoomLabel = "2F-RM7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 8, RoomLabel = "2F-RM8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 9, RoomLabel = "2F-RM9", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 10, RoomLabel = "2F-RM10", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 11, RoomLabel = "2F-RM11", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 12, RoomLabel = "2F-RM12", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 13, RoomLabel = "2F-RM13", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 14, RoomLabel = "2F-RM14", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 15, RoomLabel = "2F-ID1", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 16, RoomLabel = "2F-ID2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 17, RoomLabel = "2F-ID3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 18, RoomLabel = "2F-ID4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 19, RoomLabel = "2F-ID5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 20, RoomLabel = "2F-ID6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 21, RoomLabel = "2F-ID7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
                context.Add(new Room { RoomNumber = 22, RoomLabel = "2F-ID8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });

                context.SaveChanges();
           
        }

        public bool IsAlreadyFull(RoomDbContext context)
        {
            return context.Rooms.Count() > 0;
        }

    }
}
