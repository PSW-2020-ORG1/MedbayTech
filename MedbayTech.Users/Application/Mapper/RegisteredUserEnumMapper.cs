using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites.Enums;

namespace MedbayTech.Users.Application.Mappers
{
    public class RegisteredUserEnumMapper
    {
        public static EducationLevel StringToEducationalLevel(string educationalLevel)
        {
            if (educationalLevel.ToLower().Equals("primary"))
                return EducationLevel.primary;
            else if (educationalLevel.ToLower().Equals("secondary"))
                return EducationLevel.secondar;
            else if (educationalLevel.ToLower().Equals("bachelor"))
                return EducationLevel.bachelor;
            else if (educationalLevel.ToLower().Equals("master"))
                return EducationLevel.master;
            else if (educationalLevel.ToLower().Equals("specialist"))
                return EducationLevel.specialist;
            else
                return EducationLevel.phD;
        }
        public static Gender StringToGender(string gender)
        {
            if (gender.Equals("M"))
                return Gender.MALE;
            else
                return Gender.FEMALE;
        }
    }
}
