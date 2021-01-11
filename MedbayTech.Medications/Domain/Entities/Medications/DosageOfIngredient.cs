
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Medications.Domain.Entities.Medications
{
    public class DosageOfIngredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Amount { get; set; }
        [ForeignKey("MedicationIngredient")]
        public int MedicationIngredientId { get; set; }
        public virtual MedicationIngredient MedicationIngredient { get; set; }
        public DosageOfIngredient() { }
        public DosageOfIngredient(MedicationIngredient ingredient, double amount)
        {
            MedicationIngredient = ingredient;
            Amount = amount;
        }
    }
}
