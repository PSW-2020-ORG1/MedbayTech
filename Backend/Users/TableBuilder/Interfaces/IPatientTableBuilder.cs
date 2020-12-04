using Backend.Records.Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.TableBuilder.Interfaces
{
    public interface IPatientTableBuilder
    {
        Address BuildAddress(string street, int number, int floor, int apartment, int cityId);
        Address SaveAddress(string street, int number, int floor, int apartment, int cityId);
        State SaveState(string name);
        State BuildSate(string name);
        City SaveCity(int id, string name, long stateId);
        City BuildCity(int id, string name, long stateId);
        InsurancePolicy BuildInsurancePolicy(string id, string company, DateTime startPeriod, DateTime endPeriod);
        InsurancePolicy SavePolicy(string id, string Company, DateTime startTime, DateTime endTime);
        MedicalRecord BuildMedicalRecord(string patientId, string condition, string bloodType);
        MedicalRecord SaveMedicalRecord(string patientId, string condition, string bloodType);
    }
}
