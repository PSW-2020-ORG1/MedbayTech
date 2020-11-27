using Backend.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidateRegistrationInput
    {
        public static void Validate(PatientRegistrationDTO dto)
        {
            IsNameValid(dto.Name);
        }

        public static void IsNameValid(string name)
        {
            string namePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$";
            Regex regex = new Regex(namePattern);
            if (name == null)
                throw new ValidationException("Enter name");

            if (regex.IsMatch(namePattern))
                throw new ValidationException("Enter name in valid format");
        }
    }
}
