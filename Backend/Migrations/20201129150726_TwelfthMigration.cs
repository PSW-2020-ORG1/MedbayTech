using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class TwelfthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Heart rate monitor");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Blood shugar monitor");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Defibrilator");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Oxygen");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Respirator");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Gastroscope");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Colonoscope");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Blood test machine");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Stethoscope");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Suringe");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Needle");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Scalpel");

            migrationBuilder.InsertData(
                table: "EquipmentType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 22, "Scissors" },
                    { 21, "Pean" },
                    { 40, "Dialysis machine" },
                    { 39, "Thermometer" },
                    { 38, "Weelchair" },
                    { 36, "Computer" },
                    { 35, "Chair" },
                    { 34, "Table" },
                    { 33, "Bed" },
                    { 32, "Hydrogen peroxide" },
                    { 37, "Examining table" },
                    { 30, "Alcohol" },
                    { 29, "Adhesive tape" },
                    { 28, "Cotton pad" },
                    { 27, "Gauze" },
                    { 23, "Tweezers" },
                    { 26, "Bandage" },
                    { 25, "Surgical gloves" },
                    { 24, "Surgical mask" },
                    { 31, "Iodine" }
                });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EquipmentTypeId", "QuantityInStorage", "RoomId" },
                values: new object[] { 9, 8, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EquipmentTypeId", "QuantityInStorage", "RoomId" },
                values: new object[] { 10, 8, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EquipmentTypeId", "QuantityInStorage", "RoomId" },
                values: new object[] { 17, 5, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 18, 20, 100, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 19, 20, 100, 1003 });

            migrationBuilder.InsertData(
                table: "HospitalEquipment",
                columns: new[] { "Id", "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[,]
                {
                    { 48, 20, 3, 30, 1217 },
                    { 47, 19, 20, 100, 1217 },
                    { 46, 18, 20, 100, 1217 },
                    { 42, 8, 1, 8, 1217 },
                    { 44, 12, 1, 2, 1217 },
                    { 43, 11, 1, 2, 1217 },
                    { 38, 4, 1, 0, 1119 },
                    { 45, 13, 1, 2, 1217 },
                    { 36, 1, 1, 1, 1115 },
                    { 35, 2, 1, 0, 1114 },
                    { 34, 1, 1, 1, 1113 },
                    { 33, 3, 1, 0, 1110 },
                    { 32, 6, 1, 2, 1019 },
                    { 31, 5, 1, 4, 1019 },
                    { 27, 12, 1, 2, 1014 },
                    { 26, 11, 1, 2, 1014 },
                    { 25, 10, 4, 8, 1014 },
                    { 24, 9, 4, 8, 1014 },
                    { 23, 8, 4, 8, 1014 },
                    { 22, 7, 4, 16, 1012 },
                    { 21, 6, 1, 2, 1012 },
                    { 37, 3, 1, 0, 1116 }
                });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoomId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 19,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 20,
                column: "RoomId",
                value: 1112);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 21,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 22,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 23,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 24,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 25,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 27,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 28,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 29,
                column: "RoomId",
                value: 1213);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 30,
                column: "RoomId",
                value: 1213);

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Company", "Dosage", "Med", "MedicalRecordId", "MedicationCategoryId", "MedicationId", "Quantity", "RoomId", "Status" },
                values: new object[,]
                {
                    { 26, "Hemofarm", "50mg", "Benedril", 0, 1, null, 15, 1213, 1 },
                    { 38, "Hemofarm", "100mg", "Hemomicin", 0, 1, null, 15, 1214, 1 },
                    { 31, "Famar", "200mg", "Brufen", 0, 1, null, 10, 1214, 0 },
                    { 32, "Goodwill", "40mg", "Xanax", 0, 1, null, 15, 1214, 1 },
                    { 33, "Hemofarm", "200mg", "Panadon", 0, 1, null, 15, 1214, 1 },
                    { 34, "Famar", "60mg", "Diazepam", 0, 1, null, 15, 1214, 1 },
                    { 35, "Goodwill", "400mg", "Andol", 0, 1, null, 15, 1214, 1 },
                    { 36, "Hemofarm", "50mg", "Vicodin", 0, 1, null, 15, 1214, 1 },
                    { 37, "Famar", "80mg", "Adderall", 0, 1, null, 15, 1214, 1 },
                    { 40, "Hemofarm", "30mg", "Demerol", 0, 1, null, 15, 1214, 1 },
                    { 39, "Galenika", "20mg", "Klonopin", 0, 1, null, 15, 1214, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "null", "null" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "null", "null" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1001,
                column: "RoomLabel",
                value: "0F-GN1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1002,
                column: "RoomLabel",
                value: "0F-GN2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1003,
                column: "RoomLabel",
                value: "0F-GN3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1004,
                column: "RoomLabel",
                value: "0F-GN4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1005,
                column: "RoomLabel",
                value: "0F-GN5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1006,
                column: "RoomLabel",
                value: "0F-GN6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1007,
                column: "RoomLabel",
                value: "0F-GN7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1008,
                column: "RoomLabel",
                value: "0F-GN8");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1009,
                column: "RoomLabel",
                value: "0F-GN9");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1010,
                column: "RoomLabel",
                value: "0F-GN10");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1011,
                column: "RoomLabel",
                value: "0F-GN11");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "0F-CA1", 1, "Examination room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1013,
                column: "RoomLabel",
                value: "0F-CA2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1014,
                column: "RoomLabel",
                value: "0F-CA3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1015,
                column: "RoomLabel",
                value: "0F-CA4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1016,
                column: "RoomLabel",
                value: "0F-CA5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1017,
                column: "RoomLabel",
                value: "0F-CA6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1018,
                column: "RoomLabel",
                value: "0F-CA7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "0F-CA8", 1, "Examination room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1020,
                column: "RoomLabel",
                value: "0F-CA9");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1021,
                column: "RoomLabel",
                value: "0F-CA10");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1101,
                column: "RoomLabel",
                value: "1F-ON1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1102,
                column: "RoomLabel",
                value: "1F-ON2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1103,
                column: "RoomLabel",
                value: "1F-ON3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1104,
                column: "RoomLabel",
                value: "1F-ON4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1105,
                column: "RoomLabel",
                value: "1F-ON5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1106,
                column: "RoomLabel",
                value: "1F-ON6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1107,
                column: "RoomLabel",
                value: "1F-ON7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1108,
                column: "RoomLabel",
                value: "1F-ON8");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1109,
                column: "RoomLabel",
                value: "1F-ON9");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1110,
                column: "RoomLabel",
                value: "1F-ON10");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1111,
                column: "RoomLabel",
                value: "1F-ON11");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1112,
                column: "RoomLabel",
                value: "1F-ON12");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1113,
                column: "RoomLabel",
                value: "1F-ON13");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1114,
                column: "RoomLabel",
                value: "1F-RD1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1115,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "1F-RD2", 1, "Examination room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1116,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "1F-RD3", 1, "Examination room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1117,
                column: "RoomLabel",
                value: "1F-RD4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1118,
                column: "RoomLabel",
                value: "1F-RD5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1119,
                column: "RoomLabel",
                value: "1F-RD6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1120,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "1F-RD7", "Elevator" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1121,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "1F-RD8", "Elevator" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1201,
                column: "RoomLabel",
                value: "2F-NE1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1202,
                column: "RoomLabel",
                value: "2F-NE2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1203,
                column: "RoomLabel",
                value: "2F-NE3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1204,
                column: "RoomLabel",
                value: "2F-NE4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1205,
                column: "RoomLabel",
                value: "2F-NE5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1206,
                column: "RoomLabel",
                value: "2F-NE6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1207,
                column: "RoomLabel",
                value: "2F-NE7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1208,
                column: "RoomLabel",
                value: "2F-NE8");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1209,
                column: "RoomLabel",
                value: "2F-NE9");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1210,
                column: "RoomLabel",
                value: "2F-NE10");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1211,
                column: "RoomLabel",
                value: "2F-NE11");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1212,
                column: "RoomLabel",
                value: "2F-NE12");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1213,
                column: "RoomLabel",
                value: "2F-NE13");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1214,
                column: "RoomLabel",
                value: "2F-NE14");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1218,
                columns: new[] { "RoomType", "RoomUse" },
                values: new object[] { 2, "Operation room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1220,
                columns: new[] { "RoomType", "RoomUse" },
                values: new object[] { 0, "Patient room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1221,
                column: "RoomUse",
                value: "Elevator");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1222,
                column: "RoomUse",
                value: "Elevator");

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedsCapacity", "BedsFree", "DepartmentId", "RoomLabel", "RoomNumber", "RoomType", "RoomUse" },
                values: new object[,]
                {
                    { 2015, 10, 3, 8, "0F-DY7", 15, 3, "Elevator" },
                    { 2016, 10, 3, 8, "0F-DY8", 16, 3, "Elevator" },
                    { 2101, 10, 3, 9, "1F-GE1", 1, 1, "Examination room" },
                    { 2102, 10, 3, 9, "1F-GE2", 2, 4, "Storage room" },
                    { 2103, 10, 3, 9, "1F-GE3", 3, 4, "Storage room" },
                    { 2104, 10, 3, 9, "1F-GE4", 4, 1, "Examination room" },
                    { 2105, 10, 3, 9, "1F-GE5", 5, 1, "Examination room" },
                    { 2106, 10, 3, 9, "1F-GE6", 6, 4, "Storage room" },
                    { 2013, 10, 3, 8, "0F-DY5", 13, 2, "Operation room" },
                    { 2014, 10, 3, 8, "0F-DY6", 14, 0, "Patient room" },
                    { 2001, 10, 3, 7, "0F-EM1", 1, 1, "Examination room" },
                    { 2002, 10, 3, 7, "0F-EM2", 2, 1, "Examination room" },
                    { 2003, 10, 3, 7, "0F-EM3", 3, 3, "Auxiliary room" },
                    { 2004, 10, 3, 7, "0F-EM4", 4, 1, "Examination room" },
                    { 2005, 10, 3, 7, "0F-EM5", 5, 1, "Examination room" },
                    { 2006, 10, 3, 7, "0F-EM6", 6, 3, "Auxiliary room" },
                    { 2007, 10, 3, 7, "0F-EM7", 7, 1, "Examination room" },
                    { 2008, 10, 3, 7, "0F-EM8", 8, 1, "Examination room" },
                    { 2009, 10, 3, 8, "0F-DY1", 9, 0, "Patient room" },
                    { 2010, 10, 3, 8, "0F-DY2", 10, 2, "Operation room" },
                    { 2011, 10, 3, 8, "0F-DY3", 11, 0, "Patient room" },
                    { 2012, 10, 3, 8, "0F-DY4", 12, 0, "Patient room" },
                    { 2107, 10, 3, 9, "1F-GE7", 7, 4, "Storage room" },
                    { 2108, 10, 3, 9, "1F-GE8", 8, 1, "Examination room" },
                    { 2121, 10, 3, 10, "1F-HM7", 21, 3, "Elevator" },
                    { 2110, 10, 3, 9, "1F-GE10", 10, 3, "Auxiliary room" },
                    { 2213, 10, 3, 11, "2F-RM13", 13, 3, "Auxiliary room" },
                    { 2212, 10, 3, 11, "2F-RM12", 12, 3, "Auxiliary room" },
                    { 2211, 10, 3, 11, "2F-RM11", 11, 3, "Auxiliary room" },
                    { 2210, 10, 3, 11, "2F-RM10", 10, 1, "Examination room" },
                    { 2209, 10, 3, 11, "2F-RM9", 9, 3, "Auxiliary room" },
                    { 2208, 10, 3, 11, "2F-RM8", 8, 3, "Auxiliary room" },
                    { 2214, 10, 3, 11, "2F-RM14", 14, 0, "Patient room" },
                    { 2207, 10, 3, 11, "2F-RM7", 7, 3, "Auxiliary room" },
                    { 2205, 10, 3, 11, "2F-RM5", 5, 1, "Examination room" },
                    { 2204, 10, 3, 11, "2F-RM4", 4, 1, "Examination room" },
                    { 2203, 10, 3, 11, "2F-RM3", 3, 1, "Examination room" },
                    { 2202, 10, 3, 11, "2F-RM2", 2, 3, "Auxiliary room" },
                    { 2201, 10, 3, 11, "2F-RM1", 1, 0, "Patient room" },
                    { 2122, 10, 3, 10, "1F-HM8", 22, 3, "Elevator" },
                    { 2206, 10, 3, 11, "2F-RM6", 6, 3, "Auxiliary room" },
                    { 2109, 10, 3, 9, "1F-GE9", 9, 0, "Patient room" },
                    { 2215, 10, 3, 12, "2F-ID1", 15, 2, "Operation room" },
                    { 2217, 10, 3, 12, "2F-ID3", 17, 0, "Patient room" },
                    { 2111, 10, 3, 9, "1F-GE11", 11, 0, "Patient room" },
                    { 2112, 10, 3, 9, "1F-GE12", 12, 0, "Patient room" },
                    { 2113, 10, 3, 9, "1F-GE13", 13, 3, "Auxiliary room" },
                    { 2114, 10, 3, 9, "1F-GE14", 14, 0, "Patient room" },
                    { 2115, 10, 3, 10, "1F-HM1", 15, 0, "Patient room" },
                    { 2116, 10, 3, 10, "1F-HM2", 16, 0, "Patient room" },
                    { 2216, 10, 3, 12, "2F-ID2", 16, 0, "Patient room" },
                    { 2117, 10, 3, 10, "1F-HM3", 17, 2, "Operation room" },
                    { 2120, 10, 3, 10, "1F-HM6", 20, 0, "Patient room" },
                    { 2222, 10, 3, 12, "2F-ID8", 22, 3, "Elevator" },
                    { 2221, 10, 3, 12, "2F-ID7", 21, 3, "Elevator" },
                    { 2119, 10, 3, 10, "1F-HM5", 19, 0, "Patient room" },
                    { 2219, 10, 3, 12, "2F-ID5", 19, 0, "Patient room" },
                    { 2218, 10, 3, 12, "2F-ID4", 18, 0, "Patient room" },
                    { 2118, 10, 3, 10, "1F-HM4", 18, 2, "Operation room" },
                    { 2220, 10, 3, 12, "2F-ID6", 20, 2, "Operation room" }
                });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 22, 2, 9, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 23, 2, 11, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 24, 20, 100, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 25, 50, 200, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 26, 70, 250, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 27, 90, 300, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 28, 100, 500, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 29, 3, 6, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 30, 1, 12, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "RoomId" },
                values: new object[] { 31, 1, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 32, 1, 14, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 34, 1, 10, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 35, 3, 20, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 36, 1, 5, 1003 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "RoomId" },
                values: new object[] { 37, 1, 1003 });

            migrationBuilder.InsertData(
                table: "HospitalEquipment",
                columns: new[] { "Id", "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[,]
                {
                    { 99, 34, 3, 10, 2209 },
                    { 98, 36, 3, 5, 2208 },
                    { 97, 35, 3, 20, 2208 },
                    { 96, 34, 3, 10, 2208 },
                    { 95, 16, 2, 7, 2118 },
                    { 94, 16, 2, 7, 2117 },
                    { 93, 15, 1, 6, 2108 },
                    { 83, 10, 4, 8, 2009 },
                    { 92, 14, 1, 5, 2105 },
                    { 84, 11, 1, 2, 2009 },
                    { 117, 35, 4, 20, 2217 },
                    { 85, 12, 1, 2, 2009 },
                    { 91, 40, 4, 8, 2013 },
                    { 90, 40, 4, 8, 2010 },
                    { 86, 33, 4, 15, 2009 },
                    { 89, 39, 4, 40, 2009 },
                    { 88, 35, 4, 20, 2009 },
                    { 87, 34, 2, 10, 2009 },
                    { 49, 21, 3, 30, 1217 },
                    { 101, 36, 3, 5, 2209 },
                    { 116, 34, 2, 10, 2217 },
                    { 115, 33, 4, 15, 2217 },
                    { 114, 13, 1, 2, 2217 },
                    { 113, 12, 1, 2, 2217 },
                    { 112, 11, 1, 2, 2217 },
                    { 111, 10, 4, 8, 2217 },
                    { 110, 9, 4, 8, 2217 },
                    { 100, 35, 3, 20, 2209 },
                    { 109, 8, 4, 8, 2217 },
                    { 107, 36, 1, 5, 2210 },
                    { 106, 35, 3, 20, 2210 },
                    { 105, 34, 1, 10, 2210 },
                    { 104, 25, 50, 200, 2210 },
                    { 103, 24, 20, 100, 2210 },
                    { 82, 9, 4, 8, 2009 },
                    { 102, 17, 1, 5, 2210 },
                    { 108, 37, 1, 5, 2210 },
                    { 81, 8, 4, 8, 2009 },
                    { 118, 39, 4, 40, 2217 },
                    { 79, 36, 1, 5, 2005 },
                    { 69, 25, 50, 200, 2005 },
                    { 28, 33, 4, 15, 1014 },
                    { 29, 34, 2, 10, 1014 },
                    { 39, 34, 3, 10, 1210 },
                    { 30, 35, 4, 20, 1014 },
                    { 40, 35, 3, 20, 1210 },
                    { 65, 19, 20, 100, 2005 },
                    { 61, 9, 1, 8, 2005 },
                    { 62, 10, 1, 8, 2005 },
                    { 68, 24, 20, 100, 2005 },
                    { 63, 17, 1, 5, 2005 },
                    { 64, 18, 20, 100, 2005 },
                    { 80, 37, 1, 5, 2005 },
                    { 67, 23, 2, 11, 2005 },
                    { 66, 22, 2, 9, 2005 },
                    { 60, 32, 1, 14, 1217 },
                    { 59, 31, 1, 13, 1217 },
                    { 41, 36, 3, 5, 1210 },
                    { 57, 29, 3, 6, 1217 },
                    { 76, 32, 1, 14, 2005 },
                    { 58, 30, 1, 12, 1217 },
                    { 77, 34, 1, 10, 2005 },
                    { 78, 35, 3, 20, 2005 },
                    { 75, 31, 1, 13, 2005 },
                    { 74, 30, 1, 12, 2005 },
                    { 72, 28, 100, 500, 2005 },
                    { 71, 27, 90, 300, 2005 },
                    { 73, 29, 3, 6, 2005 },
                    { 50, 22, 2, 9, 1217 },
                    { 51, 23, 2, 11, 1217 },
                    { 52, 24, 20, 100, 1217 },
                    { 53, 25, 50, 200, 1217 },
                    { 54, 26, 70, 250, 1217 },
                    { 55, 27, 90, 300, 1217 },
                    { 56, 28, 100, 500, 1217 },
                    { 70, 26, 70, 250, 2005 }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Company", "Dosage", "Med", "MedicalRecordId", "MedicationCategoryId", "MedicationId", "Quantity", "RoomId", "Status" },
                values: new object[,]
                {
                    { 89, "Famar", "800mg", "Diazepam", 0, 1, null, 15, 2202, 1 },
                    { 85, "Hemofarm", "10mg", "Bensedin", 0, 1, null, 15, 2202, 1 },
                    { 86, "Famar", "100mg", "Brufen", 0, 1, null, 10, 2202, 0 },
                    { 87, "Goodwill", "60mg", "Xanax", 0, 1, null, 15, 2202, 1 },
                    { 88, "Hemofarm", "250mg", "Panadon", 0, 1, null, 15, 2202, 1 },
                    { 90, "Goodwill", "150mg", "Andol", 0, 1, null, 15, 2202, 1 },
                    { 98, "Goodwill", "30mg", "Percocet", 0, 1, null, 15, 2206, 1 },
                    { 92, "Bosnalijek", "200mg", "Caffetin", 0, 1, null, 15, 2206, 1 },
                    { 93, "Galenika", "100mg", "Plavix", 0, 1, null, 15, 2206, 1 },
                    { 94, "Famar", "50mg", "Ambien", 0, 1, null, 15, 2206, 1 },
                    { 95, "Galenika", "100mg", "Ranisan", 0, 1, null, 15, 2206, 1 },
                    { 96, "Hemofarm", "60mg", "Demerol", 0, 1, null, 15, 2206, 1 },
                    { 97, "Famar", "25mg", "OxyCotin", 0, 1, null, 15, 2206, 1 },
                    { 99, "Bosnalijek", "40mg", "Ritalin", 0, 1, null, 15, 2206, 1 },
                    { 100, "Famar", "100mg", "Eritromicin", 0, 1, null, 15, 2206, 1 },
                    { 101, "Bosnalijek", "100mg", "Penicillin", 0, 1, null, 15, 2206, 1 },
                    { 91, "Famar", "125mg", "Reglan", 0, 1, null, 15, 2202, 1 },
                    { 84, "Famar", "80mg", "Lexilium", 0, 1, null, 15, 2202, 1 },
                    { 79, "Galenika", "20mg", "Klonopin", 0, 1, null, 15, 2107, 1 },
                    { 82, "Galenika", "100mg", "Cefaleksin", 0, 1, null, 15, 2202, 1 },
                    { 58, "Bosnalijek", "80mg", "Ritalin", 0, 1, null, 15, 2103, 1 },
                    { 57, "Goodwill", "60mg", "Percocet", 0, 1, null, 15, 2103, 1 },
                    { 56, "Famar", "40mg", "OxyCotin", 0, 1, null, 15, 2103, 1 },
                    { 55, "Hemofarm", "30mg", "Demerol", 0, 1, null, 15, 2103, 1 },
                    { 54, "Galenika", "20mg", "Klonopin", 0, 1, null, 15, 2103, 1 },
                    { 53, "Hemofarm", "100mg", "Hemomicin", 0, 1, null, 15, 2103, 1 },
                    { 51, "Hemofarm", "50mg", "Vicodin", 0, 1, null, 15, 2103, 1 },
                    { 50, "Galenika", "200mg", "Ranisan", 0, 1, null, 15, 2102, 1 },
                    { 49, "Famar", "25mg", "Ambien", 0, 1, null, 15, 2102, 1 },
                    { 48, "Galenika", "50mg", "Plavix", 0, 1, null, 15, 2102, 1 },
                    { 47, "Bosnalijek", "400mg", "Caffetin", 0, 1, null, 15, 2102, 1 },
                    { 46, "Famar", "100mg", "Reglan", 0, 1, null, 15, 2102, 1 },
                    { 45, "Goodwill", "200mg", "Andol", 0, 1, null, 15, 2102, 1 },
                    { 44, "Famar", "30mg", "Diazepam", 0, 1, null, 15, 2102, 1 },
                    { 43, "Hemofarm", "500mg", "Panadon", 0, 1, null, 15, 2102, 1 },
                    { 42, "Goodwill", "20mg", "Xanax", 0, 1, null, 15, 2102, 1 },
                    { 41, "Famar", "400mg", "Brufen", 0, 1, null, 10, 2102, 0 },
                    { 59, "Famar", "100mg", "Eritromicin", 0, 1, null, 15, 2103, 1 },
                    { 83, "Goodwill", "200mg", "Zoloft", 0, 1, null, 15, 2202, 1 },
                    { 60, "Bosnalijek", "200mg", "Penicillin", 0, 1, null, 15, 2103, 1 },
                    { 62, "Galenika", "200mg", "Cefaleksin", 0, 1, null, 15, 2106, 1 },
                    { 81, "Hemofarm", "250mg", "Amoksicilin", 0, 1, null, 15, 2107, 1 },
                    { 80, "Hemofarm", "30mg", "Demerol", 0, 1, null, 15, 2107, 1 },
                    { 78, "Hemofarm", "100mg", "Hemomicin", 0, 1, null, 15, 2107, 1 },
                    { 77, "Famar", "80mg", "Adderall", 0, 1, null, 15, 2107, 1 },
                    { 76, "Hemofarm", "50mg", "Vicodin", 0, 1, null, 15, 2107, 1 },
                    { 75, "Goodwill", "400mg", "Andol", 0, 1, null, 15, 2107, 1 },
                    { 74, "Famar", "60mg", "Diazepam", 0, 1, null, 15, 2107, 1 },
                    { 73, "Hemofarm", "200mg", "Panadon", 0, 1, null, 15, 2107, 1 },
                    { 72, "Goodwill", "40mg", "Xanax", 0, 1, null, 15, 2107, 1 },
                    { 71, "Famar", "200mg", "Brufen", 0, 1, null, 10, 2106, 0 },
                    { 70, "Galenika", "75mg", "Lasix", 0, 1, null, 15, 2106, 1 },
                    { 69, "Hemofarm", "500mg", "Flobian", 0, 1, null, 15, 2106, 1 },
                    { 68, "Famar", "25mg", "Claritin", 0, 1, null, 15, 2106, 1 },
                    { 67, "Galenika", "100mg", "Letrox", 0, 1, null, 15, 2106, 1 },
                    { 65, "Hemofarm", "50mg", "Bensedin", 0, 1, null, 15, 2106, 1 },
                    { 64, "Famar", "40mg", "Lexilium", 0, 1, null, 15, 2106, 1 },
                    { 63, "Goodwill", "500mg", "Zoloft", 0, 1, null, 15, 2106, 1 },
                    { 61, "Hemofarm", "150mg", "Amoksicilin", 0, 1, null, 15, 2106, 1 },
                    { 52, "Famar", "40mg", "Adderall", 0, 1, null, 15, 2103, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2004);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2006);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2007);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2008);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2011);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2012);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2014);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2015);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2016);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2104);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2109);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2110);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2111);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2112);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2113);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2114);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2115);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2116);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2119);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2120);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2121);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2122);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2201);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2203);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2204);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2205);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2207);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2211);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2212);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2213);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2214);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2215);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2216);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2218);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2219);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2220);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2221);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2222);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2005);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2009);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2010);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2013);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2102);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2103);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2105);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2106);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2107);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2108);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2117);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2118);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2202);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2206);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2208);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2209);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2210);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2217);

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Gastroscope");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Otoscope");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Stethoscope");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Suringe");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Needle");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Scalpel");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Pean");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Scissors");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Surgical mask");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Surgical gloves");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Computer");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Bed");

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EquipmentTypeId", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 1, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EquipmentTypeId", "QuantityInStorage", "RoomId" },
                values: new object[] { 2, 0, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EquipmentTypeId", "QuantityInStorage", "RoomId" },
                values: new object[] { 3, 0, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 4, 1, 0, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 5, 1, 1, 1002 });

            migrationBuilder.InsertData(
                table: "HospitalEquipment",
                columns: new[] { "Id", "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[,]
                {
                    { 12, 12, 5, 100, 1002 },
                    { 13, 13, 5, 200, 1002 },
                    { 11, 11, 2, 20, 1002 },
                    { 7, 7, 1, 4, 1002 },
                    { 10, 10, 2, 7, 1002 },
                    { 20, 20, 4, 5, 1002 },
                    { 19, 19, 3, 20, 1002 },
                    { 18, 18, 10, 1000, 1002 },
                    { 17, 17, 10, 500, 1002 },
                    { 16, 16, 3, 16, 1002 },
                    { 15, 15, 3, 13, 1002 },
                    { 14, 14, 3, 14, 1002 },
                    { 9, 9, 2, 15, 1002 },
                    { 6, 6, 1, 2, 1002 },
                    { 8, 8, 1, 3, 1002 }
                });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 19,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 20,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 21,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 22,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 23,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 24,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 25,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 27,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 28,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 29,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 30,
                column: "RoomId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "F2-G3", "Soba za pregledanje" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "F1-C3", "Soba za pregledanje" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1001,
                column: "RoomLabel",
                value: "0F-GH1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1002,
                column: "RoomLabel",
                value: "0F-GH2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1003,
                column: "RoomLabel",
                value: "0F-GH3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1004,
                column: "RoomLabel",
                value: "0F-GH4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1005,
                column: "RoomLabel",
                value: "0F-GH5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1006,
                column: "RoomLabel",
                value: "0F-GH6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1007,
                column: "RoomLabel",
                value: "0F-GH7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1008,
                column: "RoomLabel",
                value: "0F-GH8");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1009,
                column: "RoomLabel",
                value: "0F-GH9");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1010,
                column: "RoomLabel",
                value: "0F-GH10");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1011,
                column: "RoomLabel",
                value: "0F-GH11");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "0F-C1", 0, "Patient room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1013,
                column: "RoomLabel",
                value: "0F-c2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1014,
                column: "RoomLabel",
                value: "0F-C3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1015,
                column: "RoomLabel",
                value: "0F-C4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1016,
                column: "RoomLabel",
                value: "0F-C5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1017,
                column: "RoomLabel",
                value: "0F-C6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1018,
                column: "RoomLabel",
                value: "0F-C7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "0F-C8", 0, "Patient room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1020,
                column: "RoomLabel",
                value: "0F-E1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1021,
                column: "RoomLabel",
                value: "0F-E2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1101,
                column: "RoomLabel",
                value: "1F-O1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1102,
                column: "RoomLabel",
                value: "1F-O2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1103,
                column: "RoomLabel",
                value: "1F-O3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1104,
                column: "RoomLabel",
                value: "1F-O4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1105,
                column: "RoomLabel",
                value: "1F-O5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1106,
                column: "RoomLabel",
                value: "1F-O6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1107,
                column: "RoomLabel",
                value: "1F-O7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1108,
                column: "RoomLabel",
                value: "1F-O8");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1109,
                column: "RoomLabel",
                value: "1F-O9");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1110,
                column: "RoomLabel",
                value: "1F-O10");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1111,
                column: "RoomLabel",
                value: "1F-O11");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1112,
                column: "RoomLabel",
                value: "1F-O12");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1113,
                column: "RoomLabel",
                value: "1F-O13");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1114,
                column: "RoomLabel",
                value: "1F-R1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1115,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "1F-R2", 0, "Patient room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1116,
                columns: new[] { "RoomLabel", "RoomType", "RoomUse" },
                values: new object[] { "1F-R3", 0, "Patient room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1117,
                column: "RoomLabel",
                value: "1F-R4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1118,
                column: "RoomLabel",
                value: "1F-R5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1119,
                column: "RoomLabel",
                value: "1F-R6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1120,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "1F-R7", "Auxiliary room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1121,
                columns: new[] { "RoomLabel", "RoomUse" },
                values: new object[] { "1F-R8", "Auxiliary room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1201,
                column: "RoomLabel",
                value: "2F-N1");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1202,
                column: "RoomLabel",
                value: "2F-N2");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1203,
                column: "RoomLabel",
                value: "2F-N3");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1204,
                column: "RoomLabel",
                value: "2F-N4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1205,
                column: "RoomLabel",
                value: "2F-N5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1206,
                column: "RoomLabel",
                value: "2F-N6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1207,
                column: "RoomLabel",
                value: "2F-N7");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1208,
                column: "RoomLabel",
                value: "2F-N8");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1209,
                column: "RoomLabel",
                value: "2F-N9");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1210,
                column: "RoomLabel",
                value: "2F-N10");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1211,
                column: "RoomLabel",
                value: "2F-N11");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1212,
                column: "RoomLabel",
                value: "2F-N12");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1213,
                column: "RoomLabel",
                value: "2F-N13");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1214,
                column: "RoomLabel",
                value: "2F-N14");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1218,
                columns: new[] { "RoomType", "RoomUse" },
                values: new object[] { 0, "Patient room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1220,
                columns: new[] { "RoomType", "RoomUse" },
                values: new object[] { 2, "Operation room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1221,
                column: "RoomUse",
                value: "Auxiliary room");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1222,
                column: "RoomUse",
                value: "Auxiliary room");

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedsCapacity", "BedsFree", "DepartmentId", "RoomLabel", "RoomNumber", "RoomType", "RoomUse" },
                values: new object[,]
                {
                    { 4, 10, 3, 4, "F1-R5", 4, 1, "Soba za pregledanje" },
                    { 6, 10, 3, 6, "F1-G1", 6, 1, "Soba za pregledanje" },
                    { 7, 10, 3, 7, "F2-C2", 7, 1, "Soba za pregledanje" },
                    { 8, 10, 3, 8, "F1-R2", 8, 1, "Soba za pregledanje" },
                    { 3, 10, 3, 3, "F1-C5", 3, 1, "Soba za pregledanje" },
                    { 5, 10, 3, 5, "F2-C4", 5, 1, "Soba za pregledanje" }
                });
        }
    }
}
