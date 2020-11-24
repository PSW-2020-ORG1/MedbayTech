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

        public PharmacyNotification() { }

        public PharmacyNotification(string Content)
        {
            this.Content = Content;
            this.Approved = false;
        }

        public PharmacyNotification(int id, string content, bool apprved)
        {
            Id = id;
            Content = content;
            Approved = apprved;
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
