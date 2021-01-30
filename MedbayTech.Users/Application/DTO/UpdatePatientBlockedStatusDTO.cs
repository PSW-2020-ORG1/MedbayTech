using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Application.DTO
{
    public class UpdatePatientBlockedStatusDTO
    {
        public string Id { get; set; }

        public UpdatePatientBlockedStatusDTO() { }
        public UpdatePatientBlockedStatusDTO(string id)
        {
            Id = id;
        }
    }
}
