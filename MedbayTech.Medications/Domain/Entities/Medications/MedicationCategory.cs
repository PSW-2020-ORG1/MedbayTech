using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Medications.Domain.Entities.Medications
{
    public class MedicationCategory : IIdentifiable<int>
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public MedicationCategory() { }
        public MedicationCategory(string categoryName)
        {
            CategoryName = categoryName;
        }

        public int GetId()
        {
            return Id;
        }
    }
}
