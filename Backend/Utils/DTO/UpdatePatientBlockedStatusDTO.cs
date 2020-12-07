using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    class UpdatePatientBlockedStatusDTO
    {
        public int Id { get; set; }
        public Boolean Blocked { get; set; }

        public UpdatePatientBlockedStatusDTO() { }
        public UpdatePatientBlockedStatusDTO(int id, Boolean blocked)
        {
            Id = id;
            Blocked = blocked;

        }
    }
}
