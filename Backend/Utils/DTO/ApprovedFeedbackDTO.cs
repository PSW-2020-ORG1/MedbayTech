using SimsProjekat.Exceptions;
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
        public string Name { get; set; }

        public string Surname { get; set; }

        public bool AllowedForPublishing { get; set; }

        public bool Anonymous { get; set; }
        public ApprovedFeedbackDTO(DateTime date, string additionalNotes, string name, string surname, bool allowedForPublishing, bool anonymous)
        {
            Date = date;
            AdditionalNotes = additionalNotes;
            Name = name;
            Surname = surname;
            AllowedForPublishing = allowedForPublishing;
            Anonymous = anonymous;
        }
    }
}
