using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Feedback.Infrastructure.Persistance
{
    public class FeedbackDataSeeder
    {
        public FeedbackDataSeeder() { }

        public void SeedAllEntities(FeedbackDbContext context)
        {
            context.Add(new Domain.Entities.Feedback
            {
                AdditionalNotes = "Sve je super!",
                Approved = true,
                Date = new DateTime(),
                UserId = "2406978890045",
                Anonymous = false,
                AllowedForPublishing = true
            });
            context.Add(new Domain.Entities.Feedback
            {
                AdditionalNotes =
                    "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!",
                Approved = false,
                Date = new DateTime(),
                UserId = "2406978890045",
                Anonymous = false,
                AllowedForPublishing = true
            });

            context.Add(new Domain.Entities.Feedback
            {
                AdditionalNotes = "Predivno, ali i ruzno! Sramite se! Cestitke... <3",
                Approved = false,
                Date = new DateTime(),
                UserId = "2406978890045",
                Anonymous = false,
                AllowedForPublishing = false
            });
            context.Add(new Domain.Entities.Feedback
            {
                AdditionalNotes = "Odlicno!",
                Approved = false,
                Date = new DateTime(),
                UserId = null,
                Anonymous = false,
                AllowedForPublishing = false
            });
            context.SaveChanges();
        }

        public bool IsAlreadyFull(FeedbackDbContext context)
        {
            return context.Feedbacks.Count() > 0;
        }


    }
}
