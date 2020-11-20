using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyIntegration.Model
{
    public class Pharmacy
    {

        // TODO(Jovan): Use Identifiable interface
        public string Id { get; set; }
        public string APIKey { get; set; }
        public string APIEndpoint { get; set; }

        public Pharmacy() { }
        public Pharmacy(string Id, string APIKey, string APIEndpoint)
        {
            this.Id = Id;
            this.APIKey = APIKey;
            this.APIEndpoint = APIEndpoint;
        }


    }
}
