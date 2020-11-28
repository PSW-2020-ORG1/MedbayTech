using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class SixstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Floor", "Name" },
                values: new object[] { 0, "General H1" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 0, 1, "Cardiology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 1, "Oncology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 1, "Radiology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 2, 1, "Neurology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Floor", "HospitalId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 0, 2, "General H2" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 0, 2, "Dialysis" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 2, "Gastroenterology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 2, "Hematology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 2, 2, "Rheumatology" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Floor", "HospitalId", "Name" },
                values: new object[,]
                {
                    { 12, 2, 2, "Infectous Diseases" },
                    { 13, 1, 3, "Infektivno" }
                });

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mamogram");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "X-ray");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "CT");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "MRI");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Ultra sound");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "EKG");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Holter");

            migrationBuilder.InsertData(
                table: "EquipmentType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 17, "Surgical mask" },
                    { 16, "Scissors" },
                    { 15, "Pean" },
                    { 18, "Surgical gloves" },
                    { 13, "Needle" },
                    { 12, "Suringe" },
                    { 11, "Stethoscope" },
                    { 10, "Otoscope" },
                    { 9, "Blood preasure monitor" },
                    { 8, "Gastroscope" },
                    { 20, "Bed" },
                    { 19, "Computer" },
                    { 14, "Scalpel" }
                });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressId", "Description", "Name" },
                values: new object[] { 3, "Hospital 1", "Hospital 1" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressId", "Description", "Name" },
                values: new object[] { 4, "Hospital 2", "Hospital 2" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressId", "Description", "Name" },
                values: new object[] { 1, "blablal", "Medbay" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomType",
                value: 1);

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedsCapacity", "BedsFree", "DepartmentId", "RoomLabel", "RoomNumber", "RoomType", "RoomUse" },
                values: new object[,]
                {
                    { 1221, 10, 3, 6, "2F-IC7", 21, 3, "Auxiliary room" },
                    { 1206, 10, 3, 5, "2F-N6", 6, 3, "Auxiliary room" },
                    { 1207, 10, 3, 5, "2F-N7", 7, 3, "Auxiliary room" },
                    { 1208, 10, 3, 5, "2F-N8", 8, 3, "Auxiliary room" },
                    { 1209, 10, 3, 5, "2F-N9", 9, 3, "Auxiliary room" },
                    { 1210, 10, 3, 5, "2F-N10", 10, 3, "Auxiliary room" },
                    { 1211, 10, 3, 5, "2F-N11", 11, 3, "Auxiliary room" },
                    { 1222, 10, 3, 6, "2F-IC7", 22, 3, "Auxiliary room" },
                    { 1212, 10, 3, 5, "2F-N12", 12, 3, "Auxiliary room" },
                    { 1214, 10, 3, 5, "2F-N14", 14, 4, "Storage room" },
                    { 1215, 10, 3, 6, "2F-IC1", 15, 0, "Patient room" },
                    { 1216, 10, 3, 6, "2F-IC2", 16, 0, "Patient room" },
                    { 1217, 10, 3, 6, "2F-IC3", 17, 2, "Operation room" },
                    { 1218, 10, 3, 6, "2F-IC4", 18, 0, "Patient room" },
                    { 1219, 10, 3, 6, "2F-IC5", 19, 0, "Patient room" },
                    { 1220, 10, 3, 6, "2F-IC6", 20, 2, "Operation room" },
                    { 1213, 10, 3, 5, "2F-N13", 13, 4, "Storage room" },
                    { 1205, 10, 3, 5, "2F-N5", 5, 1, "Examination room" },
                    { 1202, 10, 3, 5, "2F-N2", 2, 1, "Examination room" },
                    { 1203, 10, 3, 5, "2F-N3", 3, 1, "Examination room" },
                    { 1019, 10, 3, 2, "0F-C8", 19, 0, "Patient room" },
                    { 1018, 10, 3, 2, "0F-C7", 18, 0, "Patient room" },
                    { 1017, 10, 3, 2, "0F-C6", 17, 0, "Patient room" },
                    { 1016, 10, 3, 2, "0F-C5", 16, 0, "Patient room" },
                    { 1015, 10, 3, 2, "0F-C4", 15, 0, "Patient room" },
                    { 1014, 10, 3, 2, "0F-C3", 14, 0, "Patient room" },
                    { 1013, 10, 3, 2, "0F-c2", 13, 0, "Patient room" },
                    { 1012, 10, 3, 2, "0F-C1", 12, 0, "Patient room" },
                    { 1011, 10, 3, 1, "0F-GH11", 11, 1, "Examination room" },
                    { 1010, 10, 3, 1, "0F-GH10", 10, 3, "Auxiliary room" },
                    { 1009, 10, 3, 1, "0F-GH9", 9, 1, "Examination room" },
                    { 1008, 10, 3, 1, "0F-GH8", 8, 1, "Examination room" },
                    { 1007, 10, 3, 1, "0F-GH7", 7, 3, "Auxiliary room" },
                    { 1006, 10, 3, 1, "0F-GH6", 6, 1, "Examination room" },
                    { 1005, 10, 3, 1, "0F-GH5", 5, 1, "Examination room" },
                    { 1004, 10, 3, 1, "0F-GH4", 4, 3, "Auxiliary room" },
                    { 1003, 10, 3, 1, "0F-GH3", 3, 1, "Examination room" },
                    { 1002, 10, 3, 1, "0F-GH2", 2, 3, "Auxiliary room" },
                    { 1001, 10, 3, 1, "0F-GH1", 1, 3, "Auxiliary room" },
                    { 1020, 10, 3, 2, "0F-E1", 20, 3, "Elevator" },
                    { 1204, 10, 3, 5, "2F-N4", 4, 1, "Examination room" },
                    { 1021, 10, 3, 2, "0F-E2", 21, 3, "Elevator" },
                    { 1102, 10, 3, 3, "1F-O2", 2, 3, "Auxiliary room" },
                    { 1201, 10, 3, 5, "2F-N1", 1, 3, "Auxiliary room" },
                    { 1121, 10, 3, 4, "1F-R8", 21, 3, "Auxiliary room" },
                    { 1120, 10, 3, 4, "1F-R7", 20, 3, "Auxiliary room" },
                    { 1119, 10, 3, 4, "1F-R6", 19, 2, "Operation room" },
                    { 1118, 10, 3, 4, "1F-R5", 18, 0, "Patient room" },
                    { 1116, 10, 3, 4, "1F-R3", 16, 0, "Patient room" },
                    { 1115, 10, 3, 4, "1F-R2", 15, 0, "Patient room" },
                    { 1114, 10, 3, 4, "1F-R1", 14, 2, "Operation room" },
                    { 1113, 10, 3, 4, "1F-O13", 13, 1, "Examination room" },
                    { 1112, 10, 3, 3, "1F-O12", 12, 4, "Storage room" },
                    { 1111, 10, 3, 3, "1F-O11", 11, 4, "Storage room" },
                    { 1110, 10, 3, 3, "1F-O10", 10, 1, "Examination room" },
                    { 1109, 10, 3, 3, "1F-O9", 9, 0, "Patient room" },
                    { 1108, 10, 3, 3, "1F-O8", 8, 3, "Auxiliary room" },
                    { 1107, 10, 3, 3, "1F-O7", 7, 0, "Patient room" },
                    { 1106, 10, 3, 3, "1F-O6", 6, 0, "Patient room" },
                    { 1105, 10, 3, 3, "1F-O5", 5, 3, "Auxiliary room" },
                    { 1104, 10, 3, 3, "1F-O4", 4, 0, "Patient room" },
                    { 1103, 10, 3, 3, "1F-O3", 3, 1, "Examination room" },
                    { 1101, 10, 3, 3, "1F-O1", 1, 3, "Auxiliary room" },
                    { 1117, 10, 3, 4, "1F-R4", 17, 0, "Patient room" }
                });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 1, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 0, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 0, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 0, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 1, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 2, 1002 });

            migrationBuilder.UpdateData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 4, 1002 });

            migrationBuilder.InsertData(
                table: "HospitalEquipment",
                columns: new[] { "Id", "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[,]
                {
                    { 8, 8, 1, 3, 1002 },
                    { 9, 9, 2, 15, 1002 },
                    { 10, 10, 2, 7, 1002 },
                    { 11, 11, 2, 20, 1002 },
                    { 12, 12, 5, 100, 1002 },
                    { 13, 13, 5, 200, 1002 },
                    { 16, 16, 3, 16, 1002 },
                    { 15, 15, 3, 13, 1002 },
                    { 17, 17, 10, 500, 1002 },
                    { 18, 18, 10, 1000, 1002 },
                    { 19, 19, 3, 20, 1002 },
                    { 20, 20, 4, 5, 1002 },
                    { 14, 14, 3, 14, 1002 }
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
                columns: new[] { "Dosage", "Med", "RoomId" },
                values: new object[] { "20mg", "Xanax", 1001 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Company", "Dosage", "Med", "RoomId" },
                values: new object[] { "Hemofarm", "500mg", "Panadon", 1001 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dosage", "Med", "RoomId" },
                values: new object[] { "30mg", "Diazepam", 1001 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Dosage", "Med", "RoomId" },
                values: new object[] { "200mg", "Andol", 1001 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Dosage", "Med", "RoomId" },
                values: new object[] { "100mg", "Reglan", 1001 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Company", "Med", "RoomId" },
                values: new object[] { "Bosnalijek", "Caffetin", 1001 });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Company", "Dosage", "Med", "MedicalRecordId", "MedicationCategoryId", "MedicationId", "Quantity", "RoomId", "Status" },
                values: new object[,]
                {
                    { 29, "Hemofarm", "500mg", "Flobian", 0, 1, null, 15, 1001, 1 },
                    { 9, "Famar", "25mg", "Ambien", 0, 1, null, 15, 1001, 1 },
                    { 10, "Galenika", "200mg", "Ranisan", 0, 1, null, 15, 1001, 1 },
                    { 11, "Hemofarm", "50mg", "Vicodin", 0, 1, null, 15, 1001, 1 },
                    { 12, "Famar", "40mg", "Adderall", 0, 1, null, 15, 1001, 1 },
                    { 13, "Hemofarm", "100mg", "Hemomicin", 0, 1, null, 15, 1001, 1 },
                    { 14, "Galenika", "20mg", "Klonopin", 0, 1, null, 15, 1001, 1 },
                    { 15, "Hemofarm", "30mg", "Demerol", 0, 1, null, 15, 1001, 1 },
                    { 16, "Famar", "40mg", "OxyCotin", 0, 1, null, 15, 1001, 1 },
                    { 17, "Goodwill", "60mg", "Percocet", 0, 1, null, 15, 1001, 1 },
                    { 20, "Bosnalijek", "200mg", "Penicillin", 0, 1, null, 15, 1001, 1 },
                    { 19, "Famar", "100mg", "Eritromicin", 0, 1, null, 15, 1001, 1 },
                    { 30, "Galenika", "75mg", "Lasix", 0, 1, null, 15, 1001, 1 },
                    { 21, "Hemofarm", "150mg", "Amoksicilin", 0, 1, null, 15, 1001, 1 },
                    { 22, "Galenika", "200mg", "Cefaleksin", 0, 1, null, 15, 1001, 1 },
                    { 23, "Goodwill", "500mg", "Zoloft", 0, 1, null, 15, 1001, 1 },
                    { 24, "Famar", "40mg", "Lexilium", 0, 1, null, 15, 1001, 1 },
                    { 25, "Hemofarm", "50mg", "Bensedin", 0, 1, null, 15, 1001, 1 },
                    { 27, "Galenika", "100mg", "Letrox", 0, 1, null, 15, 1001, 1 },
                    { 28, "Famar", "25mg", "Claritin", 0, 1, null, 15, 1001, 1 },
                    { 18, "Bosnalijek", "80mg", "Ritalin", 0, 1, null, 15, 1001, 1 },
                    { 8, "Galenika", "50mg", "Plavix", 0, 1, null, 15, 1001, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DosageOfIngredient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DosageOfIngredient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HospitalEquipment",
                keyColumn: "Id",
                keyValue: 5);

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
                table: "MedicationCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1109);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1208);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1209);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1218);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1219);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1222);

            migrationBuilder.DeleteData(
                table: "SideEffects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SideEffects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Floor", "Name" },
                values: new object[] { 1, "Infektivno" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 1, 2, "Radiology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 2, "Neurology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 2, "Oncology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 1, 2, "Cardiology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Floor", "HospitalId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 1, 3, "Gastroenterology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 1, 3, "Hematology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 3, "Dialysis" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HospitalId", "Name" },
                values: new object[] { 3, "Rheumatology" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Floor", "HospitalId", "Name" },
                values: new object[] { 1, 3, "Infectous Diseases" });

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Krevet");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Metla");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Sapun");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Spric");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Papir");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Krpa");

            migrationBuilder.UpdateData(
                table: "EquipmentType",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Sljivovica za smirenje zivaca");

            migrationBuilder.InsertData(
                table: "HospitalEquipment",
                columns: new[] { "Id", "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[,]
                {
                    { 2, 2, 5, 15, 2 },
                    { 3, 3, 5, 15, 3 },
                    { 4, 4, 5, 15, 2 },
                    { 5, 5, 5, 15, 3 },
                    { 6, 6, 5, 15, 4 },
                    { 7, 7, 5, 15, 4 },
                    { 1, 1, 5, 15, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressId", "Description", "Name" },
                values: new object[] { 1, "blablal", "Medbay" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressId", "Description", "Name" },
                values: new object[] { 3, "Nebitno 1", "Hospital 1" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressId", "Description", "Name" },
                values: new object[] { 4, "Nebitno 2", "Hospital 2" });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Company", "Dosage", "Med", "MedicalRecordId", "MedicationCategoryId", "MedicationId", "Quantity", "RoomId", "Status" },
                values: new object[,]
                {
                    { 3, "Goodwill", "400mg", "Neoangin", 0, 1, null, 15, 1, 1 },
                    { 4, "Famar", "400mg", "Phlebodia", 0, 1, null, 15, 1, 1 },
                    { 5, "Goodwill", "400mg", "Sirup", 0, 1, null, 15, 1, 1 },
                    { 6, "Famar", "400mg", "Grafalon", 0, 1, null, 15, 1, 1 },
                    { 7, "Goodwill", "400mg", "Zalfija", 0, 1, null, 15, 1, 1 },
                    { 1, "Famar", "400mg", "Brufen", 0, 1, null, 10, 1, 0 },
                    { 2, "Goodwill", "400mg", "Metafex", 0, 1, null, 15, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomType",
                value: 0);

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Allergen", "MedicalRecordId", "MedicationId" },
                values: new object[,]
                {
                    { 2, "Prasina", 1, 2 },
                    { 1, "Polen", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "DosageOfIngredient",
                columns: new[] { "Id", "Amount", "MedicationId", "MedicationIngredientId" },
                values: new object[,]
                {
                    { 2, 120.0, 1, 2 },
                    { 1, 100.0, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "MedicationCategories",
                columns: new[] { "Id", "CategoryName", "MedicationId", "SpecializationId" },
                values: new object[] { 1, "Kategorija1", 1, 1 });

            migrationBuilder.InsertData(
                table: "SideEffects",
                columns: new[] { "Id", "Frequency", "MedicationId", "SideEffectsId" },
                values: new object[,]
                {
                    { 2, 1, 1, 1 },
                    { 1, 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Therapies",
                columns: new[] { "Id", "HourConsumption", "MedicalRecordId", "MedicationId" },
                values: new object[,]
                {
                    { 2, 10, 1, 2 },
                    { 1, 6, 1, 1 }
                });
        }
    }
}
