
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Domain.Entites;
using System.Collections.Generic;


namespace MedbayTech.Users.Application.Mapper
{
    public class SpecializationMapper
    {
        public static List<SpecializationDTO> ListSpecializationToListSpecializationDTO(List<Specialization> specializations)
        {
            List<SpecializationDTO> specializationDTOs = new List<SpecializationDTO>();
            foreach (Specialization specilizationIt in specializations)
            {
                SpecializationDTO specializationDTO = new SpecializationDTO { Id = specilizationIt.Id, Name = specilizationIt.SpecializationName };
                specializationDTOs.Add(specializationDTO);
            }
            return specializationDTOs;
        }
    }
}
