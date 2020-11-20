using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class UpdateFeedbackStatusDTO
    {
        public int Id { get; set; }
        public Boolean Approved { get; set; }

        public UpdateFeedbackStatusDTO() { }
        public UpdateFeedbackStatusDTO(int id, Boolean approved)
        {
            Id = id;
            Approved = approved;

        }
    }
}
