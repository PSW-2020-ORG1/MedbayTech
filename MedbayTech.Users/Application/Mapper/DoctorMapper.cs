using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Domain.Entites;
using System.Collections.Generic;


namespace MedbayTech.Users.Application.Mapper
{
    public class DoctorMapper
    {
        public static List<DoctorSearchDTO> ListDoctorToListDoctorSearchDTO(List<Doctor> doctors)
        {
            List<DoctorSearchDTO> searchDoctorList = new List<DoctorSearchDTO>();
            foreach (Doctor doctorIt in doctors)
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
