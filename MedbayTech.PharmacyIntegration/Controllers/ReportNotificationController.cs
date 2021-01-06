using Backend.Reports.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportNotificationController : Controller
    {
        private static string url = "amqps://vmaqngrm:BHAFy2pYqDLrQxDduUD-03HH-N0ACEVW@squid.rmq.cloudamqp.com/vmaqngrm";
        private static ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri(url.Replace("amqp://", "amqps://")),
        };

        public ReportNotificationController() { }

        [HttpPost]
        public IActionResult Post(MedicationUsageReportNotification notification)
        {
            // TODO(Jovan): AMQP is temporarily down, until then, this will return OK always
            /*notification.Endpoint = "http://l4v.ddns.net:50202/api/httpfilesharing";
            notification.Message = "New usage report from MedbayTech";

            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {

                channel.ExchangeDeclare("psw", ExchangeType.Direct, true);
                channel.QueueBind("psw-usage-reports-queue", "psw", "psw.usagereports");
                string json = JsonConvert.SerializeObject(notification);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "psw", routingKey: "psw.usagereports", basicProperties: null, body: body);

                if (body == null)
                {
                    return BadRequest();
                }
                return Ok(body);*/
            return Ok();
        }

    }
}
