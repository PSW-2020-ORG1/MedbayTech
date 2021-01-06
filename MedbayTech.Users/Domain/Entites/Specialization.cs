using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Users.Domain.Entites
{
    public class Specialization : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public Specialization(int id, string name)
        {
            Id = id;
            SpecializationName = name;
        }

        public Specialization()
        {
        }
        public int GetId()
        {
            return Id;
        }
    }
}
