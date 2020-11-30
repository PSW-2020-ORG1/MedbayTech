using System;
using System.Collections.Generic;

using Backend.Examinations.Exceptions;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication.Validators
{
    public class ValidateAdvancedSearchInput
    {
        public static void IsMedicationValid(string medication)
        {
            string medicationPattern = "[a-zšđćčžA-ZŠĐŽČĆ]+$";
            Regex regex = new Regex(medicationPattern);

            if (medication == null)
                throw new ValidationException("Please enter medication name");

            if (!regex.IsMatch(medication))
                throw new ValidationException("Please enter medication name in valid format");
        }

        public static void IsDiagnosisValid(string diagnosis)
        {
            string diagnosisPattern = "[a-zšđćčžA-ZŠĐŽČĆ]+$";
            Regex regex = new Regex(diagnosisPattern);

            if (diagnosis == null)
                throw new ValidationException("Please enter medication name");

            if (!regex.IsMatch(diagnosis))
                throw new ValidationException("Please enter medication name in valid format");
        }

        public static void IsAllergenValid(string allergen)
        {
            string allergenPattern = "[a-zšđćčžA-ZŠĐŽČĆ]+$";
            Regex regex = new Regex(allergenPattern);

            if (allergen == null)
                throw new ValidationException("Please enter medication name");

            if (!regex.IsMatch(allergen))
                throw new ValidationException("Please enter medication name in valid format");
        }

        public static void IsHourlyIntakeValid(string hourlyIntake)
        {
            string hourlyIntakePattern = "([1-9]|1[0-9]|2[0-4])";
            Regex regex = new Regex(hourlyIntakePattern);

            if (hourlyIntake == null)
                throw new ValidationException("Please enter hourly intake");

            if (!regex.IsMatch(hourlyIntake))
                throw new ValidationException("Please enter hourly intake in valid format");
        }

        public static void IsNameValid(string name)
        {
            string namePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ]*$";
            Regex regex = new Regex(namePattern);
            if (name == null)
                throw new ValidationException("Please enter name");

            if (!regex.IsMatch(name))
                throw new ValidationException("Please enter name in valid format");
        }

        public static void IsSurnameValid(string surname)
        {
            string surnamePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ]*$";
            Regex regex = new Regex(surnamePattern);

            if (surname == null)
                throw new ValidationException("Please enter surname");

            if (!regex.IsMatch(surname))
                throw new ValidationException("Please enter surname in valid format");
        }

        public static void IsDateValid(string date)
        {
            if (date == null)
                throw new ValidationException("Please enter date of examination");
        }
    }
    
}
