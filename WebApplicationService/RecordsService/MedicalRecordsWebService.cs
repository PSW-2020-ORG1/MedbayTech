using Backend.Records.Model;
using Model.Users;
using Repository;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationService.RecordsService
{
    public class MedicalRecordsWebService
    {
        private UnitOfWork unitOfWork;

        public MedicalRecordsWebService()
        {
            unitOfWork = new UnitOfWork();
        }

        public MedicalRecord GetMedicalRecordByPatient(string id)
        {
            return unitOfWork.MedicalRecordRepository.GetMedicalRecordByPatientId(id);
        }
    }
}
