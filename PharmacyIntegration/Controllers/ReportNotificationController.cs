using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Post()
        {
            //https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                //channel.ExchangeDeclare("psw-exchange", ExchangeType.Direct, true);
                //channel.QueueBind("psw-queue", "psw-exchange", "psw-key");

                channel.QueueDeclare("isa-queue", false, false, false, null);
                String message = "New medication usage report from hospital";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "psw-key", null, body);

                if (body == null)
                {
                    return BadRequest();
                }
                return Ok(body);
            }
        }

    }
}
