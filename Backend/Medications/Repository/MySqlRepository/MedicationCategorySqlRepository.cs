﻿using System;
using System.Collections.Generic;
using System.Text;
using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;
using Repository;

namespace Backend.Medications.Repository.MySqlRepository
{
    public class MedicationCategorySqlRepository : MySqlrepository<MedicationCategory, int>,
        IMedicationCategoryRepository
    {
    }
}
