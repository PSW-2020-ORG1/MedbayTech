
using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Pharmacies.Domain.Entities
{
    public class PharmacyNotification : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Approved { get; set; }
        public string PharmacyId { get; set; }
        public PharmacyNotification() { }

        public PharmacyNotification(string content, string pharmacyId)
        {
            Content = content;
            Approved = false;
            PharmacyId = pharmacyId;
        }

        public PharmacyNotification(string content)
        {
            Id = 0;
            Content = content;
            Approved = true;
        }


        public int GetId()
        {
            return Id;
        }

    }
}
