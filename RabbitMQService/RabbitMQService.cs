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
using System.IO;

namespace RabbitMQService
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;

        private string url = "amqps://vmaqngrm:BHAFy2pYqDLrQxDduUD-03HH-N0ACEVW@squid.rmq.cloudamqp.com/vmaqngrm";

        private IPharmacyNotificationService _notificationService;

        public RabbitMQService(IPharmacyNotificationService notificationService)
        //public RabbitMQService()
        {
            _notificationService = notificationService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(url.Replace("amqp://", "amqps://"));
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.ExchangeDeclare("psw-exchange", ExchangeType.Direct, true);

            channel.QueueBind("psw-queue", "psw-exchange", "psw-key");

            var consumer = new EventingBasicConsumer(channel);
            bool recive = true;

            //while(recive){
            //    var reply = channel.BasicGet("psw-queue", false);
            //    if (reply != null)
            //    {
            //        var body = reply.Body.ToArray();
            //        var msg = Encoding.UTF8.GetString(body);

            //        channel.BasicAck(reply.DeliveryTag, false);
            //    }
            //    else
            //        recive = false;
            //}

            consumer.Received += (ch, ea) =>
                {
                    var body = ea.Body.ToArray();
                    try
                    {
                        var msg = Encoding.UTF8.GetString(body);
                        Console.WriteLine(msg);
                        //WriteToFile(msg);
                        _notificationService.Add(msg);
                        channel.BasicAck(ea.DeliveryTag, false);

                    }
                    catch
                    {
                        channel.BasicReject(ea.DeliveryTag, true);
                    }
                };

            channel.BasicConsume(queue: "psw-queue",
                                 autoAck: false,
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

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Msgs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Msgs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }
    }
}
