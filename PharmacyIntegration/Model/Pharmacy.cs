using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Model
{
    public class Pharmacy
    {
        private string _id {get; set;}
        private string _api_key { get; set;}

        public Pharmacy() 
        { 
        }

        public Pharmacy(string id, string api_key)
        {
            this._id = id;
            this._api_key = _api_key;
        }


    }
}
