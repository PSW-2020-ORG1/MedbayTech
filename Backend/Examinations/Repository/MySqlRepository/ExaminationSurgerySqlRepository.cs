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
    class ExaminationSurgerySqlRepository : MySqlrepository<ExaminationSurgery, int>,
        IExaminationSurgeryRepository
    {
        public ExaminationSurgerySqlRepository(MySqlContext context) : base(context)
        {
        }

        public IEnumerable<ExaminationSurgery> GetAllBy(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExaminationSurgery> GetAllBy(MedicalRecord record)
        {
            throw new NotImplementedException();
        }

        public ExaminationSurgery UpdateTreatment(ExaminationSurgery examinationSurgery, Treatment treatment)
        {
            throw new NotImplementedException();
        }
    }
}
