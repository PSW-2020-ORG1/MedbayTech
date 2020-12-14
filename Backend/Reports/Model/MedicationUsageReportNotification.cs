using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Model
{
    public class MedicationUsageReportNotification
    {
        public string Endpoint { get; set; }
        public string Message { get; set; }
        public string Filename { get; set; }

        public MedicationUsageReportNotification() { }

        public MedicationUsageReportNotification(string endpoint, string message, string filename)
        {
            Endpoint = endpoint;
            Message = message;
            Filename = filename;
        }
    }
}
