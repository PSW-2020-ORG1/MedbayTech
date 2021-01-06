using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class HospitalEquipment
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int EquipmentTypeId { get; set; }


        public HospitalEquipment()
        {
        }

        
    }
}
