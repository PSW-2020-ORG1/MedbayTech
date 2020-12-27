
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common.Service
{
    public interface IHospitalEquipmentService
    {
        List<HospitalEquipment> GetHospitalEquipmentsByNameOrId(string textBoxSearch);
        HospitalEquipment AddEquipment(HospitalEquipment equipment);
        HospitalEquipment UpdateEquipment(HospitalEquipment equipment);
        bool DeleteEquipment(HospitalEquipment equipment);
        List<HospitalEquipment> GetEquipmentByRoomNumber(int id);
        HospitalEquipment GetHospitalEquipment(int id);
        HospitalEquipment UpdateAmountOfEquipment(HospitalEquipment equipment, int amount);
        List<HospitalEquipment> GetAllEquipment();
    }
}
