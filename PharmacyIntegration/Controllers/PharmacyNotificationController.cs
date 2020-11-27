﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyIntegration.Service;
using RabbitMQ.Client;
using Model;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyNotificationController : Controller
    {
        private MySqlContext _context;
        private IPharmacyNotificationService _notificationService;
        private static string url = "amqps://vmaqngrm:BHAFy2pYqDLrQxDduUD-03HH-N0ACEVW@squid.rmq.cloudamqp.com/vmaqngrm";
        private static ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri(url.Replace("amqp://", "amqps://")),
        };

        public PharmacyNotificationController(MySqlContext context, IPharmacyNotificationService service)
        {
            this._context = context;
            this._notificationService = service;
        }

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
                _notificationService.Add(msg);
                return Ok(Json(msg));
            }
        }

        [HttpGet("/all")]
        public IActionResult GetAll()
        {
            return Ok(_notificationService.GetAll());
        }
    }
}
