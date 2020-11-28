using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Service
{
    public interface IHospitalEquipmentService
    {
        public List<HospitalEquipment> GetHospitalEquipmentsByNameOrId(string textBoxSearch);

        public HospitalEquipment AddEquipment(HospitalEquipment equipment);
        public HospitalEquipment UpdateEquipment(HospitalEquipment equipment);
        public bool DeleteEquipment(HospitalEquipment equipment);


        public IEnumerable<HospitalEquipment> GetEquipmentByRoomNumber(int id);
        public HospitalEquipment GetHospitalEquipment(int id);
        public HospitalEquipment UpdateAmountOfEquipment(HospitalEquipment equipment, int amount);

        public IEnumerable<HospitalEquipment> GetAllEquipment();
    }
}
