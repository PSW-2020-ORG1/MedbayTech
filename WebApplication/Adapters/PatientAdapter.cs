using Backend.Utils.DTO;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Adapters
{
    public class PatientAdapter
    {
        public static List<MaliciousPatientDTO> ListPatientToListMaliciousPatient(List<Patient> patients)
        {
            List<MaliciousPatientDTO> maliciousPatients = new List<MaliciousPatientDTO>();

            foreach (Patient p in patients)
            {
                string id = p.Id;
                string username = p.Username;
                string name = p.Name;
                string surname = p.Surname;

                maliciousPatients.Add(new MaliciousPatientDTO(id, username, name, surname));
            }

            return maliciousPatients;
        }
    }
}
