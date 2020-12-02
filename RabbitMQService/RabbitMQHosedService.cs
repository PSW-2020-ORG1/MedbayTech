using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Model;
using PharmacyIntegration.Service;

namespace RabbitMQService
{
    public class RabbitMQHosedService : IHostedService
    {
        private readonly IServiceScopeFactory scopeFactory;
        IConnection connection;
        IModel channel;
        private IPharmacyNotificationService _notificationService;

        private string url = "amqps://vmaqngrm:BHAFy2pYqDLrQxDduUD-03HH-N0ACEVW@squid.rmq.cloudamqp.com/vmaqngrm";

        public RabbitMQHosedService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var MySQLContext = scope.ServiceProvider.GetRequiredService<MySqlContext>();
                _notificationService = scope.ServiceProvider.GetRequiredService<IPharmacyNotificationService>();

                var factory = new ConnectionFactory
                {
                    Uri = new Uri(url.Replace("amqp://", "amqps://"))
                };
                connection = factory.CreateConnection();
                channel = connection.CreateModel();

                channel.ExchangeDeclare("psw-exchange", ExchangeType.Direct, true);

                channel.QueueBind("psw-queue", "psw-exchange", "psw-key");

                var consumer = new EventingBasicConsumer(channel);

                bool recive = true;

                while(recive){
                    var reply = channel.BasicGet("psw-queue", false);
                    if (reply != null)
                    {
                        var body = reply.Body.ToArray();
                        try
                        {
                            var msg = Encoding.UTF8.GetString(body);
                            
                            _notificationService.Add(msg);
                            Console.WriteLine(msg);
                            Thread.Sleep(10000);
                            channel.BasicAck(reply.DeliveryTag, false);
                        }
                        catch
                        {
                            channel.BasicReject(reply.DeliveryTag, true);
                        }
                    }
                    else
                        recive = false;
                }

                /* For future development
                consumer.Received += (ch, ea) =>
                {
                    var body = ea.Body.ToArray();
                    try
                    {
                        var msg = Encoding.UTF8.GetString(body);
                        Console.WriteLine(msg);
                        //WriteToFile(msg);
                        _notificationService.Add(msg);
                        Thread.Sleep(10000);
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
                */
                return StartAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return StopAsync(cancellationToken);
        }
    }
}
