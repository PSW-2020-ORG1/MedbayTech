using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using PharmacyIntegration.Model;
using PharmacyIntegration.Service;

namespace RabbitMQService
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;

        private IPharmacyNotificationService _notificationService;

        public RabbitMQService(IPharmacyNotificationService notificationService)
        {
            _notificationService = notificationService;
        }
    
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                Message message;
                try
                {   // try deserialize with default datetime format
                    message = JsonConvert.DeserializeObject<Message>(jsonMessage);
                }
                catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                {
                    message = JsonConvert.DeserializeObject<Message>(jsonMessage, new MyDateTimeConverter());
                }
                Console.WriteLine(" [x] Received {0}", message);

                CreatePharmacyNotification(message);

            };
            channel.BasicConsume(queue: "hello",
                                    autoAck: true,
                                    consumer: consumer);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }


        private PharmacyNotification CreatePharmacyNotification(Message message)
        {
            /*int index = _notificationService.GetNotificationLastId();
            string content = message.Text;

            // TODO: Hardokodovano je
            Pharmacy pharmacy = _notificationService.GetPharmacy("Liman");

            PharmacyNotification pharmacyNotification = new PharmacyNotification(index + 1, content, true, pharmacy);

            _notificationService.AddNotification(pharmacyNotification);*/

            return null;
        }
       
    }
}
