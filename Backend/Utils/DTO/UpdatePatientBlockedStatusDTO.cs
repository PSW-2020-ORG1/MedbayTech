using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class UpdatePatientBlockedStatusDTO
    {
        public string Id { get; set; }
        public Boolean Blocked { get; set; }

        public UpdatePatientBlockedStatusDTO() { }
        public UpdatePatientBlockedStatusDTO(string id, Boolean blocked)
        {
            Id = id;
            Blocked = blocked;

        }
    }
}
