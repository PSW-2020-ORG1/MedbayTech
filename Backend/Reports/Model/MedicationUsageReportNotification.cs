using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Model
{
    public class MedicationUsageReportNotification
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("filename")]
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
