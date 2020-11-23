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
            for (int i = 0; i < 4; i++)
            {
                DoctorSearchDTO doctor = new DoctorSearchDTO
                {
                    Id = "123",
                    FullName = "pera" + " " + "peric"
                };
                searchDoctorList.Add(doctor);
            }
            return searchDoctorList;


        }
    }
}
