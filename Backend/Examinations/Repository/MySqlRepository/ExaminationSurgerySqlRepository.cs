using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Examinations.Model;
using Backend.Records.Model;
using Model;
using Model.Users;
using Repository;

namespace Backend.Examinations.Repository.MySqlRepository
{
    public class ExaminationSurgerySqlRepository : MySqlrepository<ExaminationSurgery, int>,
        IExaminationSurgeryRepository
    {
        public ExaminationSurgerySqlRepository(MedbayTechDbContext context) : base(context)
        {
        }

        public List<ExaminationSurgery> GetAllBy(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationSurgery> GetAllBy(MedicalRecord record)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationSurgery> GetReportFor(string idPatient)
        {
            return GetAll().Where(report => report.IsPatient(idPatient)).ToList();
        }

        public ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment)
        {
            throw new NotImplementedException();
        }
    }
}
