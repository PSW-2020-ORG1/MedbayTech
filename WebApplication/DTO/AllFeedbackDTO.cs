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
         public String Username { get; set; }
         public AllFeedbackDTO(int id, DateTime date, string additionalNotes, string username, Boolean approved)
        {
            Id = id;
            Date = date;
            AdditionalNotes = additionalNotes;
            Username = username;
            Approved = approved;
            
        }        
    }
}
