using Backend.General.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyIntegration.Model
{
    public class Pharmacy : IIdentifiable<string>
    {
        [Key]
        public string Id { get; set; }
        public string APIKey { get; set; }
        public string APIEndpoint { get; set; }
        public bool RecieveNotificationFrom { get; set; }

        public Pharmacy() { }
        public Pharmacy(string Id, string APIKey, string APIEndpoint, bool RecieveNotificationFrom = false )
        {
            this.Id = Id;
            this.APIKey = APIKey;
            this.APIEndpoint = APIEndpoint;
            this.RecieveNotificationFrom = RecieveNotificationFrom;
        }

        public string GetId()
        {
            return this.Id;
        }

        public void SetId(string id)
        {
            this.Id = id;
        }
    }
}
