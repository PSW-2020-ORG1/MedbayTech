﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class AvailableAppointmentsDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public AvailableAppointmentsDTO() { }
    }
}
