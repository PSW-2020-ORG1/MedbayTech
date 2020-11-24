using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyIntegration.Service;
using RabbitMQ.Client;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyNotificationController : Controller
    {
        private IPharmacyNotificationService notificationService;
        private static string url = "amqps://vmaqngrm:BHAFy2pYqDLrQxDduUD-03HH-N0ACEVW@squid.rmq.cloudamqp.com/vmaqngrm";
        private static ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri(url.Replace("amqp://", "amqps://")),
        };
        [HttpGet]
        public IActionResult Get()
        {
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.ExchangeDeclare("psw-exchange", ExchangeType.Direct, true);
                channel.QueueBind("psw-queue", "psw-exchange", "psw-key");
                var data = channel.BasicGet("psw-queue", false);
                if (data == null) return BadRequest("No data");
                var msg = Encoding.UTF8.GetString(data.Body.ToArray());
                channel.BasicAck(data.DeliveryTag, false);
                return Ok(Json(msg));
            }
        }
    }
}
