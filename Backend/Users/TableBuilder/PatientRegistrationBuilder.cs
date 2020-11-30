using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Backend.Records.WebApiController;
using Backend.Users.WebApiController;
using Backend.Utils;
using Backend.Utils.EnumMapper;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication.ObjectBuilder
{
    public class PatientRegistrationBuilder
    {

        WebAddressController addressController;
        WebStateController stateController;
        WebCityController cityController;
        WebInsuranceController insuranceController;
        MedicalRecordWebController medicalRecordController;
        public PatientRegistrationBuilder()
        {
            addressController = new WebAddressController();
            stateController = new WebStateController();
            cityController = new WebCityController();
            insuranceController = new WebInsuranceController();
            medicalRecordController = new MedicalRecordWebController();
        }
        private Address BuildAddress(string street, int number, int floor, int apartment, int cityId)
        {
            return new Address { Street = street, Number = number, Floor = floor, Apartment = apartment, CityId = cityId };
        }
        public Address SaveAddress(string street, int number, int floor, int apartment, int cityId)
        {
            Address address = BuildAddress(street, number, floor, apartment, cityId);
            return addressController.Save(address);
        }
        public State SaveState(string name)
        {
            State state = BuildSate(name);
            State savedState = stateController.Save(state);
            return savedState;
        }
        private State BuildSate(string name)
        {
            return new State { Name = name };
        }
        public City SaveCity(int id, string name, long stateId)
        {
            City city = BuildCity(id, name, stateId);
            return cityController.Save(city);
        }
        private City BuildCity(int id, string name, long stateId)
        {
            return new City { Id = id, Name = name, StateId = stateId };
        }
        private InsurancePolicy BuildInsurancePolicy(string id, string company, DateTime startPeriod, DateTime endPeriod )
        {
            return new InsurancePolicy { Id = id, Company = company, StartTime = startPeriod, EndTime = endPeriod };
        }
        public InsurancePolicy SavePolicy(string id, string Company, DateTime startTime, DateTime endTime)
        {
            InsurancePolicy policy = BuildInsurancePolicy(id, Company, startTime, endTime);
            return insuranceController.SavePolicy(policy);
        }
        private MedicalRecord BuildMedicalRecord(string patientId, string condition, string bloodType)
        {
            MedicalRecord medicalRecord = new MedicalRecord
            {
                PatientId = patientId,
                CurrHealthState = PatientEnumMapper.StringToCondition(condition),
                BloodType = PatientEnumMapper.StringToBloodType(bloodType)

            };

            return medicalRecord;
        }
        public MedicalRecord SaveMedicalRecord(string patientId, string condition, string bloodType)
        {
            MedicalRecord medicalRecord = BuildMedicalRecord(patientId, condition, bloodType);
            return medicalRecordController.CreateMedicalRecord(medicalRecord);
        }

    }
}
