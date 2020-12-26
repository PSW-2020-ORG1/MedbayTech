using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Feedback.Domain.Entities
{
    public class User
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        [Column("Surname")]
        public string Surname { get; set; }
    }
}
