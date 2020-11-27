using Backend.Medications.Service;
using Service.RoomService;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor
{
    public sealed class Services
    {
        private static Services instance = null;
        public RoomService roomService;
        public MedicationService medicationService;
        public HospitalEquipmentService hospitalEquipmentService;

        private Services()
        {
            roomService = new RoomService(new Model.MySqlContext());
            medicationService = new MedicationService(new Model.MySqlContext());
            hospitalEquipmentService = new HospitalEquipmentService(new Model.MySqlContext());
        }
        public static Services getService()
        {
            if(instance==null)
            {
                instance = new Services();
            }
            return instance;
        }
    }
}
