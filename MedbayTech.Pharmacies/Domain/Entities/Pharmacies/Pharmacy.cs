
using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Pharmacies.Domain.Entities.Pharmacies
{
    public class Pharmacy : IIdentifiable<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string APIKey { get; set; }
        public string APIEndpoint { get; set; }
        public bool RecieveNotificationFrom { get; set; }
        public string Email { get; set; }

        public Pharmacy() { }
        public Pharmacy(string Id, string APIKey, string APIEndpoint, string Email, bool RecieveNotificationFrom = false)
        {
            this.Id = Id;
            this.APIKey = APIKey;
            this.APIEndpoint = APIEndpoint;
            this.Email = Email;
            this.RecieveNotificationFrom = RecieveNotificationFrom;
        }

        public string GetId()
        {
            return Id;
        }

    }
}
