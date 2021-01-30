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
            SeedHospitals(context);
            SeedEquipmentType(context);
            SeedDepartments(context);                    
            SeedRooms(context);
            SeedHospitalEquipment(context);           
            
            

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

        private void SeedHospitalEquipment(RoomDbContext context)
        {
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 122, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 122, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 122, EquipmentTypeId = 37 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 122, EquipmentTypeId = 38 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 122, EquipmentTypeId = 21 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 122, EquipmentTypeId = 9 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 122, EquipmentTypeId = 2 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 122, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 122, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 122, EquipmentTypeId = 5 });
            context.Add(new HospitalEquipment { QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 122, EquipmentTypeId = 6 });
            context.Add(new HospitalEquipment { QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 122, EquipmentTypeId = 7 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 122, EquipmentTypeId = 8 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 122, EquipmentTypeId = 10 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 122, EquipmentTypeId = 18 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 122, EquipmentTypeId = 11 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 122, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 122, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 122, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 122, EquipmentTypeId = 16 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 67, EquipmentTypeId = 26 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 16, RoomId = 67, EquipmentTypeId = 27 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 69, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 69, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 69, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 69, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 69, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 69, EquipmentTypeId = 12 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 69, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 69, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 4, RoomId = 74, EquipmentTypeId = 25 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 74, EquipmentTypeId = 26 });

            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 86, EquipmentTypeId = 22 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 89, EquipmentTypeId = 24 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 90, EquipmentTypeId = 23 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 91, EquipmentTypeId = 24 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 92, EquipmentTypeId = 22 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 116, EquipmentTypeId = 1 });

            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 104, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 104, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 104, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 97, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 97, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 97, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 97, EquipmentTypeId = 33 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 97, EquipmentTypeId = 38 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 97, EquipmentTypeId = 21 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 30, RoomId = 97, EquipmentTypeId = 20 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 30, RoomId = 97, EquipmentTypeId = 19 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 97, EquipmentTypeId = 9 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 97, EquipmentTypeId = 2 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 97, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 97, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 97, EquipmentTypeId = 5 });
            context.Add(new HospitalEquipment { QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 97, EquipmentTypeId = 6 });
            context.Add(new HospitalEquipment { QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 97, EquipmentTypeId = 7 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 97, EquipmentTypeId = 8 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 97, EquipmentTypeId = 10 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 97, EquipmentTypeId = 18 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 97, EquipmentTypeId = 11 });

            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 23, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 23, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 23, EquipmentTypeId = 37 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 23, EquipmentTypeId = 38 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 23, EquipmentTypeId = 21 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 23, EquipmentTypeId = 9 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 23, EquipmentTypeId = 2 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 23, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 23, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 23, EquipmentTypeId = 5 });
            context.Add(new HospitalEquipment { QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 23, EquipmentTypeId = 6 });
            context.Add(new HospitalEquipment { QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 23, EquipmentTypeId = 7 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 23, EquipmentTypeId = 8 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 23, EquipmentTypeId = 10 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 23, EquipmentTypeId = 18 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 23, EquipmentTypeId = 11 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 23, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 23, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 23, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 23, EquipmentTypeId = 16 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 19, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 19, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 19, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 19, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 19, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 19, EquipmentTypeId = 12 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 19, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 19, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 40, RoomId = 19, EquipmentTypeId = 39 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 18, EquipmentTypeId = 40 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 15, EquipmentTypeId = 40 });

            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 7, EquipmentTypeId = 34 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 6, RoomId = 4, EquipmentTypeId = 35 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 7, RoomId = 58, EquipmentTypeId = 36 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 7, RoomId = 57, EquipmentTypeId = 36 });

            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 45, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 45, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 45, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 44, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 44, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 44, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 43, EquipmentTypeId = 37 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 43, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 43, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 43, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 43, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 43, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 43, EquipmentTypeId = 16 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 36, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 36, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 36, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 36, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 36, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 36, EquipmentTypeId = 33 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 36, EquipmentTypeId = 12 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 36, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 36, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 40, RoomId = 36, EquipmentTypeId = 39 });
            context.SaveChanges();
        }

        private void SeedEquipmentType(RoomDbContext context)
        {
            context.Add(new EquipmentType { Name = "Mamogram" });
            context.Add(new EquipmentType { Name = "X-ray" });
            context.Add(new EquipmentType { Name = "CT" });
            context.Add(new EquipmentType { Name = "MRI" });
            context.Add(new EquipmentType { Name = "Ultra sound" });
            context.Add(new EquipmentType { Name = "EKG" });
            context.Add(new EquipmentType { Name = "Holter" });
            context.Add(new EquipmentType { Name = "Heart rate monitor" });
            context.Add(new EquipmentType { Name = "Blood preasure monitor" });
            context.Add(new EquipmentType { Name = "Blood sugar monitor" });
            context.Add(new EquipmentType { Name = "Defibrilator" });
            context.Add(new EquipmentType { Name = "Oxygen" });
            context.Add(new EquipmentType { Name = "Respirator" });
            context.Add(new EquipmentType { Name = "Gastroscope" });
            context.Add(new EquipmentType { Name = "Colonoscope" });
            context.Add(new EquipmentType { Name = "Blood test machine" });
            context.Add(new EquipmentType { Name = "Stethoscope" });
            context.Add(new EquipmentType { Name = "Suringe" });
            context.Add(new EquipmentType { Name = "Needle" });
            context.Add(new EquipmentType { Name = "Scalpel" });
            context.Add(new EquipmentType { Name = "Pean" });
            context.Add(new EquipmentType { Name = "Scissors" });
            context.Add(new EquipmentType { Name = "Tweezers" });
            context.Add(new EquipmentType { Name = "Surgical mask" });
            context.Add(new EquipmentType { Name = "Surgical gloves" });
            context.Add(new EquipmentType { Name = "Bandage" });
            context.Add(new EquipmentType { Name = "Gauze" });
            context.Add(new EquipmentType { Name = "Cotton pad" });
            context.Add(new EquipmentType { Name = "Adhesive tape" });
            context.Add(new EquipmentType { Name = "Alcohol" });
            context.Add(new EquipmentType { Name = "Iodine" });
            context.Add(new EquipmentType { Name = "Hydrogen peroxide" });
            context.Add(new EquipmentType { Name = "Bed" });
            context.Add(new EquipmentType { Name = "Table" });
            context.Add(new EquipmentType { Name = "Chair" });
            context.Add(new EquipmentType { Name = "Computer" });
            context.Add(new EquipmentType { Name = "Examining table" });
            context.Add(new EquipmentType { Name = "Weelchair" });
            context.Add(new EquipmentType { Name = "Thermometer" });
            context.Add(new EquipmentType { Name = "Dialysis machine" });

            context.SaveChanges();
        }

        private void SeedDepartments(RoomDbContext context)
        {
            context.Add(new Department { Name = "General", Floor = 0, HospitalId = 2 });
            context.Add(new Department { Name = "Cardiology", Floor = 0, HospitalId = 2 });
            context.Add(new Department { Name = "Oncology", Floor = 1, HospitalId = 2 });
            context.Add(new Department { Name = "Radiology", Floor = 1, HospitalId = 2 });
            context.Add(new Department { Name = "Neurology", Floor = 2, HospitalId = 2 });
            context.Add(new Department { Name = "Intensive Care", Floor = 2, HospitalId = 2 });
            context.Add(new Department { Name = "Emergency", Floor = 0, HospitalId = 3 });
            context.Add(new Department { Name = "Dialysis", Floor = 0, HospitalId = 3 });
            context.Add(new Department { Name = "Gastroenterology", Floor = 1, HospitalId = 3 });
            context.Add(new Department { Name = "Hematology", Floor = 1, HospitalId = 3 });
            context.Add(new Department { Name = "Rheumatology", Floor = 2, HospitalId = 3 });
            context.Add(new Department { Name = "Infectous Diseases", Floor = 2, HospitalId = 3 });
            context.Add(new Department { Name = "Infektivno", Floor = 1, HospitalId = 1 });
            context.SaveChanges();
        }

        private void SeedHospitals(RoomDbContext context)
        {
            context.Add(new Hospital { Description = "blablal", Name = "Medbay", Address = new Address("Dunavska", 2, 2, 1, new City("Novi Sad", new State("Srbija"))) });
            context.Add(new Hospital { Description = "Hospital 1", Name = "Hospital 1", Address = new Address("Dunavska", 4, 3, 3, new City("Novi Sad", new State("Srbija"))) });
            context.Add(new Hospital { Description = "Hospital 2", Name = "Hospital 2", Address = new Address("Dunavska", 4, 3, 4, new City("Novi Sad", new State("Srbija"))) });
            context.SaveChanges();
        }


        public bool IsAlreadyFull(RoomDbContext context)
        {
            return context.Hospitals.Count() > 0;
        }

    }
}
