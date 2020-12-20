using Backend.Records.Model;
using Backend.Records.Service.Interfaces;
using Backend.Users.Service.Interfaces;
using Backend.Users.TableBuilder.Interfaces;
using Backend.Utils.EnumMapper;
using Model.Users;
using System;


namespace WebApplication.ObjectBuilder
{
    public class PatientTableBuilder : IPatientTableBuilder
    {

        IAddressService _addressService;
        IStateService _stateService;
        ICityService _cityService;
        IInsurancePolicyService _insurancePolicyService;
        IMedicalRecordService _medicalRecordService;
        public PatientTableBuilder(IAddressService addressService, IStateService stateService, ICityService cityService, IInsurancePolicyService insurancePolicyService, IMedicalRecordService medicalRecordService)
        {
            _addressService = addressService;
            _stateService = stateService;
            _cityService = cityService;
            _insurancePolicyService = insurancePolicyService;
            _medicalRecordService = medicalRecordService;
        }
        public Address BuildAddress(string street, int number, int floor, int apartment, int cityId)
        {
            return new Address { Street = street, Number = number, Floor = floor, Apartment = apartment, CityId = cityId };
        }
        public Address SaveAddress(string street, int number, int floor, int apartment, int cityId)
        {
            Address address = BuildAddress(street, number, floor, apartment, cityId);
            return _addressService.Save(address);
        }
        public State SaveState(string name)
        {
            State state = BuildSate(name);
            State savedState = _stateService.Save(state);
            return savedState;
        }
        public State BuildSate(string name)
        {
            return new State { Name = name };
        }
        public City SaveCity(int id, string name, long stateId)
        {
            City city = BuildCity(id, name, stateId);
            return _cityService.Save(city);
        }
        public City BuildCity(int id, string name, long stateId)
        {
            return new City { Id = id, Name = name, StateId = stateId };
        }
        public InsurancePolicy BuildInsurancePolicy(string id, string company, DateTime startPeriod, DateTime endPeriod )
        {
            return new InsurancePolicy { Id = id, Company = company, StartTime = startPeriod, EndTime = endPeriod };
        }
        public InsurancePolicy SavePolicy(string id, string Company, DateTime startTime, DateTime endTime)
        {
            InsurancePolicy policy = BuildInsurancePolicy(id, Company, startTime, endTime);
            return _insurancePolicyService.SavePolicy(policy);
        }
        public MedicalRecord BuildMedicalRecord(string patientId, string condition, string bloodType)
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
            return _medicalRecordService.CreateMedicalRecord(medicalRecord);
        }

    }
}
