using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Model;

namespace PharmacyIntegration.Service
{
    public class PharmacyService
    {
        public static string GetPharmacyAPIById(string id)
        {

            return "key123";
        }

        public static bool AddPharmacyAPIKey(Pharmacy pharmacy)
        {
            return true;
        }

        public static List<Pharmacy> GetAllPharmaciesAPIKeys()
        {
            List<Pharmacy> pharmacies =  new List<Pharmacy>();
            pharmacies.Add(new Pharmacy("id123", "api123"));
            pharmacies.Add(new Pharmacy("id456", "api456"));
            return pharmacies;
        }
    }
}
