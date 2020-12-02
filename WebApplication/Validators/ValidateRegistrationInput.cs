using Backend.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidateRegistrationInput : ValidateAuthInput
    {
        public static void Validate(PatientRegistrationDTO dto)
        {
            IsNameValid(dto.Name);
            IsSurnameValid(dto.Surname);
            IsIdValid(dto.Id);
            IsDateValid(dto.DateOfBirth);
            IsEmailValid(dto.Email);
            IsPhoneValid(dto.Phone);
            IsUsernameValid(dto.Username);
            IsPasswordValid(dto.Password, dto.ConfirmPassword);
            IsProfessionValid(dto.Profession);
            IsInsuranceNumberValid(dto.PolicyNumber);
            IsInsuranceCompanyValid(dto.Company);
            IsDateValid(dto.PolicyStart);
            IsDateValid(dto.PolicyEnd);
            IsCityValid(dto.CityOfBirth);
            IsPostalCodeValid(dto.PostalCodeBirth);
            IsStateValid(dto.State);
            IsStreetValid(dto.Street);
            IsNumberValid(dto.Number);
            IsApartmentValid(dto.Apartment);
            IsFloorValid(dto.Floor);
        }

        
    }
}
