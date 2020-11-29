using Backend.Examinations.Model;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Repository.MySqlRepository
{
    public class PrescriptionsSqlRepository : MySqlrepository<Prescription, int>, IPrescriptionRepository
    {
        public PrescriptionsSqlRepository(MySqlContext context) : base(context)
        {
        }
    }
}
