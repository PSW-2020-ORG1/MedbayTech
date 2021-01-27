using MedbayTech.Common.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Common.Domain.Events
{
    public class DomainEvent : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }

        public DomainEvent()
        {
            Timestamp = DateTime.Now;
        }

        public DomainEvent(int id, DateTime timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }

        public int GetId()
        {
            return Id;
        }
    }
}
