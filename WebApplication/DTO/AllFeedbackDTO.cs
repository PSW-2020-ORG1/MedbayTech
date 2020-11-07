using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class AllFeedbackDTO
    {
         public int Id { get; set; }
         public DateTime Date { get; set; }
         public string AdditionalNotes { get; set; }
         public Boolean Approved { get; set; }
         public String Name { get; set; }
         public String Surname { get; set; }
         public Boolean Anonymous { get; set; }
         public Boolean AllowedForPublishing { get; set; }
            
         public AllFeedbackDTO(int id, DateTime date, string additionalNotes, string name, string surname, Boolean approved, Boolean anonymous , Boolean allowedForPublishing)
        {
            Id = id;
            Date = date;
            AdditionalNotes = additionalNotes;
            Name = name;
            Surname = surname;
            Approved = approved;
            Anonymous = anonymous;
            AllowedForPublishing = allowedForPublishing;
        }        
    }
}
