using MedbayTech.Medications.Domain.Entities.Medications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.Medications.Infrastructure.Database.Configurations
{
    public class DosageOfIngredientConfiguration : IEntityTypeConfiguration<DosageOfIngredient>
    {
        public void Configure(EntityTypeBuilder<DosageOfIngredient> builder)
        {
            builder.ToTable("DosageOfIngredients");
            builder.OwnsOne(doi => doi.MedicationIngredient);
        }
    }
}
