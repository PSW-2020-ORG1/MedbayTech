using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyIntegration.Service;
using RabbitMQ.Client;
using Model;
using PharmacyIntegration.Model;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyNotificationController : Controller
    {
        private MedbayTechDbContext _context;
        private IPharmacyNotificationService _notificationService;
        private static string url = "amqps://vmaqngrm:BHAFy2pYqDLrQxDduUD-03HH-N0ACEVW@squid.rmq.cloudamqp.com/vmaqngrm";
        private static ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri(url.Replace("amqp://", "amqps://")),
        };

        public PharmacyNotificationController(MedbayTechDbContext context, IPharmacyNotificationService service)
        {
            this._context = context;
            this._notificationService = service;
        }

        [HttpGet("{id?}")]
        public IActionResult Get(string id)
        {
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.ExchangeDeclare("psw", ExchangeType.Direct, true);
                channel.QueueBind("psw-special-offers-queue", "psw", "psw.specialoffers");
                var data = channel.BasicGet("psw-special-offers-queue", false);
                if (data == null) return BadRequest("No data");
                var msg = Encoding.UTF8.GetString(data.Body.ToArray());
                channel.BasicAck(data.DeliveryTag, false);
                PharmacyNotification pharmacyNotification = _notificationService.Add(msg);
                if (pharmacyNotification == null)
                    return NotFound();
                else
                    return Ok(pharmacyNotification);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_notificationService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(PharmacyIntegration.Model.PharmacyNotification pharmacyNotification)
        {
            bool isSuccessfullyAdded = _notificationService.Update(pharmacyNotification) != null;

            if (isSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_notificationService.Remove(_notificationService.Get(id)))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
