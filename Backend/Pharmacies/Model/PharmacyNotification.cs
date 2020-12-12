using Backend.General.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Model
{
    public class PharmacyNotification : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Approved { get; set; }
        public string PharmacyId { get; set; }
        public PharmacyNotification() { }

        public PharmacyNotification(string content,  string pharmacyId)
        {
            this.Content = content;
            this.Approved = false;
            this.PharmacyId = pharmacyId;
        }

        public PharmacyNotification(string content)
        {
            Id = 0;
            Content = content;
            Approved = true;
        }


        public int GetId()
        {
            return this.Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}
