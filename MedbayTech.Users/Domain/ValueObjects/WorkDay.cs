
using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend.Users.Model
{
    public class WorkDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

    }
}
