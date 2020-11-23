using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Model
{
    public class PharmacyNotification
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Approved { get; set; }
        public string PharmacyID { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }

        public PharmacyNotification() { }

        public PharmacyNotification(int id, string content, bool apprved, Pharmacy pharmacy)
        {
            Id = id;
            Content = content;
            Approved = apprved;
            Pharmacy = pharmacy;
            PharmacyID = pharmacy.Id;
        }
    }
}
