
using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Medications.Domain.Entities.Medications
{
    public class MedicationIngredient : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public MedicationIngredient() { }
        public MedicationIngredient(string name)
        {
            Name = name;
        }

        public int GetId()
        {
            return Id;
        }
    }
}
