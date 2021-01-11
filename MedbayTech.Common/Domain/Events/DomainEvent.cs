using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Common.Domain.Events
{
    public class DomainEvent
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
    }
}
