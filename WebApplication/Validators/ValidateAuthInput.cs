using Backend.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication.Validators
{
    public class ValidateAuthInput
    {
        public static void IsNameValid(string name)
        {
            string namePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ]*$";
            Regex regex = new Regex(namePattern);
            if (name == null)
                throw new ValidationException("Enter name");

            if (!regex.IsMatch(name))
                throw new ValidationException("Enter name in valid format");
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

        public static void IsIdValid(string id)
        {
            string idPattern = "^\\d{13}$";
            Regex regex = new Regex(idPattern);

            if (id == null)
                throw new ValidationException("Please enter id");

            if (!regex.IsMatch(id))
                throw new ValidationException("Please enter id in valid format");
        }

        public static void IsDateValid(DateTime date)
        {
            if (date == null)
                throw new ValidationException("Please enter date of birth");
        }

        public static void IsEmailValid(string email)
        {
            if (email == null)
                throw new ValidationException("Please enter email");
        }

        public static void IsPhoneValid(string phone)
        {
            string phonePattern = "^[0-9]{5,12}$";
            Regex regex = new Regex(phonePattern);

            if (phone == null)
                throw new ValidationException("Please enter phone");

            if (!regex.IsMatch(phone))
                throw new ValidationException("Please enter phone in valid format");
        }

        public static void IsUsernameValid(string username)
        {
            if (username == null)
                throw new ValidationException("Please enter username");

            if (username.Length < 5)
                throw new ValidationException("Username must contain at least 5 characters");
        }

        public static void IsPasswordValid(string password, string confirmPassword)
        {
            if (password == null || confirmPassword == null)
                throw new ValidationException("Please enter password");

            if (!password.Equals(confirmPassword))
                throw new ValidationException("Password must match");

            if (password.Length < 8 || confirmPassword.Length < 8)
                throw new ValidationException("Password must contain at least 8 characters");
        }

        public static void IsProfessionValid(string profession)
        {
            if (profession == null)
                throw new ValidationException("Please enter profession");

            if (profession.Length < 3)
                throw new ValidationException("Profession must contain at least 3 characters");
        }

        public static void IsInsuranceNumberValid(string policyNumber)
        {
            if (policyNumber == null)
                throw new ValidationException("Please enter policy number");
        }

        public static void IsInsuranceCompanyValid(string company)
        {
            if (company == null)
                throw new ValidationException("Please enter company");
        }

        public static void IsCityValid(string city)
        {
            string cityPattern = "^[A-ZŠĐŽČĆa-zšđćčžA-ZŠĐŽČĆ ]*$";
            Regex regex = new Regex(cityPattern);

            if (city == null)
                throw new ValidationException("Please enter city");

            if (!regex.IsMatch(city))
                throw new ValidationException("Please enter city in valid format");
        }

        public static void IsPostalCodeValid(int postalCode)
        {
            if (postalCode < 10000 || postalCode > 99999)
                throw new ValidationException("Please postal code in valid format");
        }

        public static void IsStateValid(string state)
        {
            string statePattern = "^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$";
            Regex regex = new Regex(statePattern);

            if (state == null)
                throw new ValidationException("Please enter state");

            if (!regex.IsMatch(state))
                throw new ValidationException("Please enter state in valid format");
        }

        public static void IsStreetValid(string street)
        {
            if (street == null)
                throw new ValidationException("Please enter street");
        }

        public static void IsNumberValid(int number)
        {
            if (number < 0)
                throw new ValidationException("Please enter number in valid format");
        }

        public static void IsApartmentValid(int apartment)
        {
            if (apartment < 0 || apartment > 99999)
                throw new ValidationException("Please enter apartment in valid format");
        }

        public static void IsFloorValid(int floor)
        {
            if (floor == null)
                throw new ValidationException("Please enter floor in valid format");

            if (floor < 0 || floor > 9999)
                throw new ValidationException("Please enter floor in valid format");
        }
    }
}
