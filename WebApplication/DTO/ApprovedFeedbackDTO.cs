using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class ApprovedFeedbackDTO
    {
        public DateTime Date { get; set; }
        public string AdditionalNotes { get; set; }
        public string Username { get; set; }

        public bool Anonymous { get; set; }
        public ApprovedFeedbackDTO(DateTime date, string additionalNotes, string username, bool anonymous)
        {
            Date = date;
            AdditionalNotes = additionalNotes;
            Username = username;
            Anonymous = anonymous;
        }
    }
}
