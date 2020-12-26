using MedbayTech.Feedback.Domain.Enums;
using MedbayTech.Repository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Feedback.Domain.Entities
{
    public class Feedback : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalNotes { get; set; }
        public bool Approved { get; set; }
        public bool Anonymous { get; set; }
        public bool AllowedForPublishing { get; set; }

        public string UserId { get; set; }
        [NotMapped]
        public virtual User RegisteredUser { get; set; }

        public Feedback() { }

        public Feedback(int id, DateTime date, string additionalNotes, Grade grade, bool anonymous, bool allowedForPublishing)
        {
            Id = id;
            Date = date;
            AdditionalNotes = additionalNotes;
            //RegisteredUser = user;
            //RegisteredUserId = user.Id;
            Anonymous = anonymous;
            Approved = false;
            AllowedForPublishing = allowedForPublishing;
        }

        public int GetId()
        {
            return Id;
        }

    }
}
