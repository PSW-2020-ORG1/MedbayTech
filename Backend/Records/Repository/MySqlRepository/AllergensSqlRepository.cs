using System;
using System.Collections.Generic;
using System.Text;
using Backend.Medications.Model;
using Repository;
using Repository.MedicalRecordRepository;

namespace Backend.Records.Repository.MySqlRepository
{
    public class AllergensSqlRepository : MySqlrepository<Allergens, int>,
        IAllergensRepository
    {
    }
}
