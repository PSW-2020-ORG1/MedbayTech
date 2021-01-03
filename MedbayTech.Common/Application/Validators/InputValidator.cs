
using System.ComponentModel.DataAnnotations;


namespace MedbayTech.Common.Application
{
    public class InputValidator
    {
        public static void IsNameValid(string name)
        {
            if (name == null)
            {
                throw new ValidationException("Name cannot be null");
            }
        }

        public static void IsTypeValid(string type)
        {
            if (type == null)
            {
                throw new ValidationException("Type cannot be null");
            }
        }

        public static void IsMedicineValid(string medicine)
        {
            if (medicine == null)
            {
                throw new ValidationException("Medicine cannot be null");
            }
        }

        public static void IsHourlyIntakeValid(int hourlyIntake)
        {
            if (hourlyIntake < 0 || hourlyIntake > 24)
                throw new ValidationException("Enter hourly intake in valid format");
        }
    }
}
