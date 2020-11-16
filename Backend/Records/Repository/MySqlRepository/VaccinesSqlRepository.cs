using System;
using System.Collections.Generic;
using System.Text;
using Backend.Records.Model;
using Repository;
using Repository.MedicalRecordRepository;

namespace Backend.Records.Repository.MySqlRepository
{
    public class VaccinesSqlRepository : MySqlrepository<Vaccines, int>,
        IVaccinesRepository
    {
    }
}
