using Backend.Utils.DTO;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Adapters
{
    public class SpecializationAdapter
    {
        public static List<SpecializationDTO> ListSpecializationToListSpecializationDTO(List<Specialization> specializations)
        {
            List<SpecializationDTO> specializationDTOs = new List<SpecializationDTO>();
            foreach(Specialization specilizationIt in specializations)
            {
                SpecializationDTO specializationDTO = new SpecializationDTO { Id = specilizationIt.Id, Name = specilizationIt.SpecializationName };
                specializationDTOs.Add(specializationDTO);
            }
            return specializationDTOs;
        }
    }
}
