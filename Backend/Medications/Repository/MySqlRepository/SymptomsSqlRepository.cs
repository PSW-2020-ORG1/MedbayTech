using System;
using System.Collections.Generic;
using System.Text;
using Backend.Medications.Repository.FileRepository;
using Backend.Records.Model;
using Repository;

namespace Backend.Medications.Repository.MySqlRepository
{
    class SymptomsSqlRepository : MySqlrepository<Symptoms, int>,
        ISymptomsRepository
    {
    }
}
