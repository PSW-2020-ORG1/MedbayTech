using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication.Validators
{
    public class ValidateSearchInput
    {
        public static void IsDoctorNameValid(string name)
        {
            string namePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ]*$";
            Regex regex = new Regex(namePattern);

            if (!regex.IsMatch(name))
                throw new ValidationException("Enter name in valid format");
        }

        public static void IsTypeValid(string type)
        {
            string typePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ]*$";
            Regex regex = new Regex(typePattern);

            if (!regex.IsMatch(type))
                throw new ValidationException("Enter type in valid format");
        }

        public static void IsMedicineValid(string medicine)
        {
            string medicinePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ]*$";
            Regex regex = new Regex(medicinePattern);

            if (!regex.IsMatch(medicine))
                throw new ValidationException("Enter medicine in valid format");
        }

        public static void IsHourlyIntakeValid(int hourlyIntake)
        { 
            if (hourlyIntake < 0 || hourlyIntake > 24 )
                throw new ValidationException("Enter hourly intake in valid format");
        }
    }
}
