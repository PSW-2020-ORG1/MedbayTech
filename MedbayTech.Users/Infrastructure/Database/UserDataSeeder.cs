using MedbayTech.Common.Domain.ValueObjects;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Infrastructure.Database
{
    public class UserDataSeeder
    {
        public UserDataSeeder()
        {
        }

        public void SeedAllEntities(UserDbContext context)
        {
            SeedUsers(context);
            

            context.SaveChanges();
        }

        private void SeedUsers(UserDbContext context)
        {
            context.Add(new RegisteredUser
            {
                Id = "2406978890045",
                CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "marko@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                Name = "Marko",
                Surname = "Markovic",
                Username = "markic",
                Password = "marko1978",
                Phone = "065/123-4554",
                PlaceOfBirth = new City("Novi Sad", new State("Srbija")),
                Profession = "vodoinstalater",
                ProfileImage = "."

            });
            context.SaveChanges();
        }


        public bool IsAlreadyFull(UserDbContext context)
        {
            return context.RegisteredUsers.Count() > 0;
        }
    }
}
