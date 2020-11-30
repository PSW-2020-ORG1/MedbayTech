using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class DoctorAdapter
    {
        public static List<DoctorSearchDTO> ListDoctorToListDoctorSearchDTO(List<Doctor> doctors)
        {
            List<DoctorSearchDTO> searchDoctorList = new List<DoctorSearchDTO>();
            foreach(Doctor doctorIt in doctors)
            {
                DoctorSearchDTO doctor = new DoctorSearchDTO
                {
                    Id = doctorIt.Id,
                    FullName = doctorIt.Name + " " + doctorIt.Surname
                };
                searchDoctorList.Add(doctor);
            }
            return searchDoctorList;
        }
    }
}
