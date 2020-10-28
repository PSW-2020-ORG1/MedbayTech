using SimsProjekat.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimsProjekat.View
{
    public class Validations
    {
        private const string UNDERAGE = "User underage! You have to be {0} or older.";
        private const string INCORRECT_ID_NUMBER = "Incorrect identification number! It has to be 13 characters long.";
        private const string INCORRECT_INSURANCE_NUMBER = "Incorrect insurance number! It has to be 13 characters long.";
        private const string INCORRECT_LICENSE_NUMBER = "Incorrect license number! It has to be 13 characters long.";
        private const string INCORRECT_EMAIL_ADDRESS = "Incorrect email address! It has format like email123@mail.com.";
        private const string INCORRECT_NAME = "Incorrect name format! It has format like Name";
        private const string INCORRECT_USERNAME = "Incorrect username format! It has format like username123";
        private const string INCORRECT_SURNAME = "Incorrect surname format! It has format like Surname";
        private const string INCORRECT_PASSWORD = "Incorrect password format! It needs to have at least 8 characters, have at least one upper case char and at least one number!";

        private int underageNumber;

        public Validations(int underageNumber)
        {
            this.underageNumber = underageNumber;
        }
        public bool IsUsernameValid(string username)
        {
            var sUserNameAllowedRegEx = new Regex(@"^[a-zA-Z]{1}[a-zA-Z0-9\._\-]{0,23}[^.-]$", RegexOptions.Compiled);
            if (!sUserNameAllowedRegEx.IsMatch(username) || string.IsNullOrEmpty(username))
            {
                return false;
            }

            return true;
        }
        public bool IsNameValid(string name)
        {
            var sNameAllowedRegEx = new Regex(@"[A-Z]{1}[a-z]+", RegexOptions.Compiled);
            if (!sNameAllowedRegEx.IsMatch(name) || string.IsNullOrEmpty(name))
            {
                throw new IncorrectNameFormat(INCORRECT_NAME);
            }

            return true;
        }
        public bool IsSurnameValid(string surname)
        {
            var sSurnameAllowedRegEx = new Regex(@"[A-Z]{1}[a-z]+", RegexOptions.Compiled);
            if (!sSurnameAllowedRegEx.IsMatch(surname) || string.IsNullOrEmpty(surname))
            {
                throw new IncorrectSurnameFormat(INCORRECT_SURNAME);
            }

            return true;
        }

        public bool IsPasswrodValid(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password))
            {
                return true;
            }
            throw new IncorrectPasswordFormat(INCORRECT_PASSWORD);
        }

        public bool IsIdentificationNumberValid(string id)
        {
            var correctOrder = new Regex(@"[0-9]{13,13}");
            if (correctOrder.IsMatch(id))
            {
                return true;
            }
            throw new IncorrectIdentificationNumberFormat(INCORRECT_ID_NUMBER);
        }

        public bool IsInsuranceNumberValid(string insuranceNumber)
        {
            var correctOrder = new Regex(@"[A-Z]{3,5}[0-9]{2,5}");
            if (correctOrder.IsMatch(insuranceNumber))
            {
                return true;
            }
            throw new IncorrectInsuranceNumber(INCORRECT_INSURANCE_NUMBER);
        }

        public bool IsLicenseNumberValid(string licenseNumber)
        {
            var correctOrder = new Regex(@"[A-Z]{3,5}[0-9]{2,5}");
            if (correctOrder.IsMatch(licenseNumber))
            {
                return true;
            }
            throw new IncorrectInsuranceNumber(INCORRECT_LICENSE_NUMBER);
        }
        public bool IsEmailValid(string email)
        {
            var correctOrder = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (correctOrder.IsMatch(email))
            {
                return true;
            }
            throw new IncorrectEmailAddress(INCORRECT_EMAIL_ADDRESS);
        }
        public bool IsUnderAge(DateTime dateOfBirth)
        {
            if ((DateTime.Today.Year - dateOfBirth.Year) < underageNumber)
                throw new UnderageException(string.Format(UNDERAGE, underageNumber));
            return false;
        }
    }
}
