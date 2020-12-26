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
            SeedStates(context);
            SeedCities(context);
            SeedAddresses(context);
            SeedInsurancePolicy(context);
            SeedUsers(context);
            

            context.SaveChanges();
        }

        private void SeedUsers(UserDbContext context)
        {
            context.Add(new RegisteredUser
            {
                Id = "2406978890045",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "marko@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Marko",
                Surname = "Markovic",
                Username = "markic",
                Password = "marko1978",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = "."

            });
            context.SaveChanges();
        }
        private void SeedStates(UserDbContext context)
        {
            context.Add(new State { Name = "Serbia" });
            context.SaveChanges();

        }

        private void SeedCities(UserDbContext context)
        {
            context.Add(new City { Id = 21000, Name = "Novi Sad", StateId = 1 });
            context.Add(new City { Id = 11000, Name = "Beograd", StateId = 1 });
            context.SaveChanges();
        }

        private void SeedAddresses(UserDbContext context)
        {
            context.Add(new Address { Street = "Radnicka", Number = 4, CityId = 21000 });
            context.Add(new Address { Street = "Gospodara Vucica", Number = 5, CityId = 11000 });
            context.Add(new Address { Street = "Stefana Nemanje", Number = 28, CityId = 11000 });
            context.Add(new Address { Street = "Stefana Nemanje", Number = 27, CityId = 11000 });
            context.SaveChanges();
        }

        private void SeedInsurancePolicy(UserDbContext context)
        {
            context.Add(new InsurancePolicy
            {
                Company = "Dunav osiguranje d.o.o",
                Id = "policy1",
                StartTime = new DateTime(2020, 11, 1),
                EndTime = new DateTime(2020, 11, 1)
            });
            context.Add(new InsurancePolicy
            {
                Company = "Delta generali",
                Id = "policy2",
                StartTime = new DateTime(2020, 11, 1),
                EndTime = new DateTime(2021, 11, 1)
            });
            context.SaveChanges();
        }

        public bool IsAlreadyFull(UserDbContext context)
        {
            return context.States.Count() > 0;
        }
    }
}
