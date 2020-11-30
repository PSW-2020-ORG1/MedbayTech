using Backend.Records.Model;
using Backend.Records.Repository.MySqlRepository;
using Backend.Records.WebApiService;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Records.WebApiController
{
    public class MedicalRecordWebController
    {
        private MedicalRecordSqlRepository medicalRecordSqlRepository = new MedicalRecordSqlRepository(new MySqlContext());
        private MedicalRecordWebService medicalRecordWebService;

        public MedicalRecordWebController()
        {
            medicalRecordWebService = new MedicalRecordWebService(medicalRecordSqlRepository);
        }

        public MedicalRecord GetMedicalRecordByPatientId(string id)
        {
            return medicalRecordWebService.GetMedicalRecordByPatientId(id);
        }

        public MedicalRecord CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            return medicalRecordWebService.CreateMedicalRecord(medicalRecord);
        }
    }
}
