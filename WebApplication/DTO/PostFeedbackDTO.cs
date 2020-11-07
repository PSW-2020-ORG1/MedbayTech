using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PostFeedbackDTO
    {
        public string AdditionalNotes { get; set; }
        public Boolean Anonymous { get; set; }
        public Boolean AllowedForPublishing { get; set; }
        public string UserId { get; set; }

        public PostFeedbackDTO() { }
        public PostFeedbackDTO(string additionalNotes, Boolean anonymous, Boolean allowed, string userid)
        {
            AdditionalNotes = additionalNotes;
            Anonymous = anonymous;
            AllowedForPublishing = allowed;
            UserId = userid;
        }
    }
}
